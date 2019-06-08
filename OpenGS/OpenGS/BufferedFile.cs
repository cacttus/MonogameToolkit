using System;
using System.IO;
namespace OpenGS
{
    /// <summary>
    /// Reads a file in chunks.
    /// 1/12/19
    /// </summary>
    public class BufferedFile : IDisposable
    {
        BinaryReader Reader;
        string _strCurChunk = "";
        int _iChunkPos = 0;
        int _iChunkSize = 8192;
        long ReaderPos = 0;//Caching these seems to imporve perf.
        long ReaderLen = 0;
        const char EOF_C = (char)0;

        public int ChunkSize
        {
            get { return _iChunkSize; }
            set
            {
                _iChunkSize = value;
                if (_iChunkSize < 1)
                {
                    _iChunkSize = 1;
                }
            }
        }

        #region Public:Methods
        public BufferedFile(string str)
        {
            Reader = new BinaryReader(File.Open(str, FileMode.Open));
            ReaderLen = Reader.BaseStream.Length;
        }
        public void Dispose()
        {
            Reader.Dispose();
        }
        public bool eof()
        {
            if (ReaderLen == ReaderPos)
            {
                if (_iChunkPos >= _strCurChunk.Length)
                {
                    return true;
                }
            }
            return false;
        }
        private void FillBuf()
        {
            //Make sure we have a chunk, or, EOF
            if (_iChunkPos >= _strCurChunk.Length)
            {
                if (!eof())
                {
                    byte[] bytes = Reader.ReadBytes(_iChunkSize);
                    ReaderPos = Reader.BaseStream.Position;

                    _strCurChunk = System.Text.Encoding.Default.GetString(bytes);
                    _iChunkPos = 0;
                }
            }
        }
        public char at()
        {
            FillBuf();

            if (eof())
            {
                return (char)EOF_C;
            }
            char c = _strCurChunk[_iChunkPos];
            return c;
        }
        public char get()
        {
            char c = at();

            _iChunkPos++;

            return c;
        }
        public bool eatWs()
        {
            while (Char.IsWhiteSpace(at()))
            {    // is char is alphanumeric
                if (get() == -1)
                {
                    return false;    // inc pointer
                }
            }

            return true;
        }
        public string getTok()
        {
            string ret = "";

            if (!eatWs())
            {
                return ret;
            }

            char c = at();
            while (!char.IsWhiteSpace(at()) && !eof())
            {
                c = get();

                if (c == EOF_C)
                {
                    return ret;//eof
                }

                ret += c;
            }

            return ret;
        }
        public static float strToFloat(string str)
        {
            float res = 0;
            if (!float.TryParse(str, out res))
            {
                throw new Exception("Failed to parse float value.");
            }
            return res;
        }
        public static int strToInt(string str)
        {
            int res = 0;
            if (!int.TryParse(str, out res))
            {
                throw new Exception("Failed to parse int value.");
            }
            return res;
        }
        public bool eatLine()
        {
            if (!eatTo('\n'))
            {
                return false;
            }

            while ((at() == '\r') || (at() == '\n'))
            {
                get();
            }

            return true;
        }
        // - eats until character (increments buffer pointer)
        public bool eatTo(char k)
        {
            char c;
            while (!eof() && (c = at()) != k)
            {
                if (get() == -1)
                {
                    return false;    // inc pointer
                }
            }

            return true;
        }
        public string getTokSameLineOrReturnEmpty()
        {
            string ret = "";

            if (!eatWsExceptNewline())
            {
                return ret;
            }

            char c = at();
            if (c == '\n')
            {
                return "";
            }

            while (!char.IsWhiteSpace(at()) && !eof())
            {
                c = get();

                if (c == -1)
                    return ret;//eof

                ret += c;
            }

            return ret;
        }
        public bool eatWsExceptNewline()
        {
            while (isWsExceptNewline(at()))    // is char is alphanumeric
                if (get() == -1)
                    return false;    // inc pointer

            return true;
        }
        public bool isWsExceptNewline(char c)
        {
            return (
                (c == ' ') ||
                (c == '\t') ||
                (c == '\r')
                );
        }

        #endregion

    }

    //    public class BufferedFile
    //    {
    //        const int file_eof = -1;
    //        //typedef int t_filepos;
    //        string _data;

    //        int iFilePos;
    //        //////////////////////////////////////////////////////////////////////////
    //        //char* ptr() { return getBuffer(); }

    //        //********WRITE***********
    //        //********WRITE***********
    //        //********WRITE***********
    //        //void writeInt32(int in)
    //        //{
    //        //    *((int*)getBuffer()) = in;
    //        //    iFilePos += sizeof(int);
    //        //}
    //        //void writeString(string& in)
    //        //{
    //        //    memcpy((void*)in.c_str(), (void*)getBuffer(), in.length());
    //        //    iFilePos += in.length();
    //        //}
    //        //void writeByte(t_byte in)
    //        //{
    //        //    *((t_byte*)getBuffer()) = in;
    //        //    iFilePos += sizeof(t_byte);
    //        //}
    //        //void writeBytes(t_byte* in, int length)
    //        //{
    //        //    if (iFilePos + length > _data.count())
    //        //        BroThrowException("The buffered file tried to write too much data.");
    //        //
    //        //    memcpy((void*)in, (void*)((char*)getBuffer() + iFilePos), length);
    //        //    iFilePos += length;
    //        //}




    //        //*******READ********
    //        //*******READ********
    //        //*******READ********
    //        //int readFloat() {
    //        //    float data = *((float*)getBuffer());
    //        //
    //        //    iFilePos += sizeof(float);
    //        //
    //        //    return data;
    //        //}
    //        //int readInt32(){
    //        //    int data = *((int*)getBuffer());
    //        //
    //        //    iFilePos += sizeof(int);
    //        //
    //        //    return data;
    //        //}
    //        //string readString(int length){
    //        //    string data = string((char*)getBuffer(), length);
    //        //
    //        //    iFilePos += length;
    //        //
    //        //    return data;
    //        //}
    //        //t_byte readByte(){
    //        //    t_byte data = *((t_byte*)getBuffer());
    //        //
    //        //    iFilePos += sizeof(t_byte);
    //        //
    //        //    return data;
    //        //}

    //        //OutSize = size of output buffer we're copying to
    //        //readCount - number of bytes we're reading from this BufferedFile.
    //        void validateRead(int outSize, int readCount)
    //        {
    //            //AssertOrThrow2(getBuffer() != NULL);
    //            //AssertOrThrow2(iFilePos < getBufferSize());

    //            //int offSize = readCount;
    //            //int outBufSize = outSize;
    //            //if (outSize < readCount)
    //            //{
    //            //    BroThrowException(
    //            //        "Buffer read overrun. Input buffer of size "
    //            //        , outSize
    //            //        , " could not hold file of size "
    //            //        , getBufferSize()
    //            //    );
    //            //}

    //            //int myOff = iFilePos + readCount;
    //            //if (myOff > getBufferSize())
    //            //{
    //            //    BroThrowException("Buffer read overrun. Tried to read past end of buffer.");
    //            //}
    //        }
    //        //void readToEnd(StaticBuffer* pbuf)
    //        //{
    //        //    AssertOrThrow2(pbuf != NULL);
    //        //    int iReadCount = getBuffe r()->byteSize() - iFilePos;
    //        //
    //        //    //Handles most validation
    //        //    validateRead(pbuf->byteSize(), iReadCount);
    //        //
    //        //    readBytes(pbuf->ptr(), pbuf->byteSize(), iReadCount);
    //        //}
    //        /**
    //        *    @fn readBytes
    //        *    @brief Read some bytes from the file in the buffer.
    //        *    @param din [out] - pointer to a data buffer to
    //        *    @param in_sz size of the input buffer din
    //        *    @param read_sz number of bytes to read.
    //*/
    //        //void readBytes(void* pOutBuf, int in_sz, int read_sz)
    //        //{
    //        //    //Handles most validation
    //        //    validateRead(in_sz, read_sz);
    //        //
    //        //    char* pMyPtr = getBufferPtrOff(iFilePos);
    //        //
    //        //    memcpy_s(pOutBuf, in_sz, pMyPtr, read_sz);
    //        //
    //        //    iFilePos += read_sz;
    //        //}
    //        // - Rewind the file pointer
    //        void rewind() { iFilePos = 0; }

    //        // - Return true if the file is at eof.
    //        bool eof() { return iFilePos >= _data.Length || iFilePos == -1; }

    //        // - returns 0 on EOF
    //        // - Eat Whitespace (ALSO EATS \n, \r and spaces!!!)
    //        bool eatWs()
    //        {
    //            while (Char.IsWhiteSpace(at()))    // is char is alphanumeric
    //                if (get() == -1)
    //                    return false;    // inc pointer

    //            return true;
    //        }
    //        bool isWsExceptNewline(char c)
    //        {
    //            return (
    //                (c == ' ') ||
    //                (c == '\t') ||
    //                (c == '\r')
    //                );
    //        }
    //        // - same as eatWs except it returns at newline.
    //        bool eatWsExceptNewline()
    //        {
    //            while (isWsExceptNewline(at()))    // is char is alphanumeric
    //                if (get() == -1)
    //                    return false;    // inc pointer

    //            return true;
    //        }
    //        // - Eats the line past the carraige return
    //        //
    //        bool eatLine()
    //        {
    //            if (!eatTo('\n')) return 0;

    //            while ((at() == '\r') || (at() == '\n'))
    //                get();

    //            return 1;
    //        }
    //        // - eats until character (increments buffer pointer)
    //        bool eatTo(char k)
    //        {
    //            char c;
    //            while ((c = at()) != k)
    //                if (get() == -1) return false;    // inc pointer

    //            return true;
    //        }
    //        //- Return the next whitespace separated token
    //        string getTok()
    //        {
    //            string ret = "";

    //            if (!eatWs())
    //                return ret;

    //            char c = at();
    //            while (!char.IsWhiteSpace(at()) && !eof())
    //            {
    //                c = get();

    //                if (c == -1)
    //                    return ret;//eof

    //                ret += c;
    //            }

    //            return ret;
    //        }
    //        /// - Returns empty string if we hit a newline character.
    //        string getTokSameLineOrReturnEmpty()
    //        {
    //            string ret = "";

    //            if (!eatWsExceptNewline())
    //                return ret;

    //            char c = at();
    //            if (c == '\n')
    //                return "";

    //            while (!char.IsWhiteSpace(at()) && !eof())
    //            {
    //                c = get();

    //                if (c == -1)
    //                    return ret;//eof

    //                ret += c;
    //            }

    //            return ret;
    //        }
    //        // returns character at pos
    //        char at()
    //        {
    //            if (eof())
    //                return Encoding.ASCII.GetString(new byte[] { -1 })[0];
    //            return _data[iFilePos];// (char)(*(getData().ptr() + iFilePos));
    //        }
    //        char at(int _pos)
    //        {
    //            if (eof())
    //                return -1;
    //            return _data[iFilePos];
    //        }
    //        // Returns a character or also file_eof
    //        int get()
    //        {
    //            if (iFilePos == -1 || iFilePos == _data.Length)
    //                return (int)(iFilePos = -1);
    //            return _data[iFilePos];// (int)(*(getData().ptr() + iFilePos++));
    //        }
    //        bool loadFromDisk(string fileLoc, bool bAddNull)
    //        {
    //            return loadFromDisk(fileLoc, 0, -1, bAddNull);
    //        }
    //        bool loadFromDisk(string fileLoc, int offset, int length, bool bAddNull)
    //        {
    //            //DiskFile df;
    //            //df.openForRead(fileLoc);

    //            //df.close();
    //            rewind();
    //            _data = System.IO.File.ReadAllText(fileLoc);

    //            // BroLogInfo("Reading File ", fileLoc);

    //            //char* bufRet;
    //            //uint size;
    //            //int ret;
    //            //ret = FileSystem::SDLFileRead(fileLoc, bufRet, size, bAddNull);
    //            //if (ret != 0)
    //            //{
    //            //    //Failure
    //            //    BroLogError("Failure, could not read file", fileLoc, " returned ", ret);
    //            //    Gu::debugBreak();
    //            //    return false;
    //            //    // BroThrowException("Failure, could not read file", fileLoc, " returned ", ret);
    //            //}

    //            //if (length == -1)
    //            //{
    //            //    length = size;
    //            //}

    //            //AssertOrThrow2((int)size <= length);

    //            //_data._alloca(length + 1);
    //            //memcpy(_data.ptr(), bufRet, length);
    //            //FileSystem::SDLFileFree(bufRet);

    //            //*(getData().ptr() + length) = 0;

    //            return true;
    //        }


    //        //int getSize()
    //        //{
    //        //    AssertOrThrow2(getBuffer() != NULL);
    //        //    return getBufferSize();
    //        //}
    //        string toString()
    //        {

    //            return _data;
    //        }
    //        //////////////////////////////////////////////////////////////////////////
    //        void readBool(ref bool val, int offset)
    //        {
    //            char b;
    //            readByte(b, offset);
    //            val = b > 0;
    //        }
    //        void readByte(char& val, int offset)
    //        {
    //            int readSize = sizeof(char);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readInt16(int16_t& val, int offset)
    //        {
    //            int readSize = sizeof(int16_t);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readInt32(int& val, int offset)
    //        {
    //            int readSize = sizeof(int);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readFloat(float& val, int offset)
    //        {
    //            int readSize = sizeof(float);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readInt64(int64_t& val, int offset)
    //        {
    //            int readSize = sizeof(int64_t);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readUint32(uint& val, int offset)
    //        {
    //            int readSize = sizeof(uint);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readVec2(vec2& val, int offset)
    //        {
    //            int readSize = sizeof(vec2);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readVec3(vec3& val, int offset)
    //        {
    //            int readSize = sizeof(vec3);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readVec4(vec4& val, int offset)
    //        {
    //            int readSize = sizeof(vec4);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readVec3i(ivec3& val, int offset)
    //        {
    //            int readSize = sizeof(ivec3);
    //            read((char*)&val, readSize, readSize, offset == memsize_max ? iFilePos : offset);
    //            iFilePos += readSize;
    //        }
    //        void readString(string& val, int offset)
    //        {
    //            int16_t iStringLen = 0;
    //            readInt16(iStringLen);

    //            if (iStringLen > 0)
    //            {
    //                char* buf = new char[iStringLen + 1];
    //                read(buf, iStringLen, iStringLen, iFilePos);
    //                buf[iStringLen] = 0;//null terminate
    //                val.assign(buf);
    //                delete[] buf;
    //                iFilePos += iStringLen;
    //            }
    //            else
    //            {
    //                val = "";
    //            }
    //        }
    //        void readMat4(mat4& val, int offset)
    //        {
    //            //This must correspond to the same order in mat4..
    //            readFloat(val._m11);
    //            readFloat(val._m12);
    //            readFloat(val._m13);
    //            readFloat(val._m14);
    //            readFloat(val._m21);
    //            readFloat(val._m22);
    //            readFloat(val._m23);
    //            readFloat(val._m24);
    //            readFloat(val._m31);
    //            readFloat(val._m32);
    //            readFloat(val._m33);
    //            readFloat(val._m34);
    //            readFloat(val._m41);
    //            readFloat(val._m42);
    //            readFloat(val._m43);
    //            readFloat(val._m44);
    //        }
    //        void read(const char* buf, int readSize, int offset) {
    //    read((char*) buf, readSize, readSize, offset == memsize_max? iFilePos : offset);
    //        iFilePos += readSize;
    //}
    //    RetCode read(const char* buf, int count, int bufcount, int offset)
    //    {
    //        AssertOrThrow2((offset >= 0) || (offset == memsize_max));

    //        if (count > bufcount)
    //        {
    //            BroThrowException("DataBuffer - out of bounds.");
    //        }
    //        if (offset == memsize_max)
    //        {
    //            offset = 0;
    //        }

    //        _data.copyTo(buf, count, offset, 0);

    //        return GR_OK;
    //    }
    //    //////////////////////////////////////////////////////////////////////////
    //    void writeBool(bool&& val, int offset)
    //    {
    //        char b = (val > 0) ? 1 : 0;
    //        writeByte(std::move(b), offset);
    //    }
    //    void writeByte(char&& val, int offset)
    //    {
    //        int writeSize = sizeof(char);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeInt16(int16_t&& val, int offset)
    //    {
    //        int writeSize = sizeof(int16_t);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeInt32(int&& val, int offset)
    //    {
    //        int writeSize = sizeof(int);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeFloat(const float&& val, int offset)
    //    {
    //        int writeSize = sizeof(float);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeInt64(int64_t&& val, int offset)
    //    {
    //        int writeSize = sizeof(int64_t);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeUint32(uint&& val, int offset)
    //    {
    //        int writeSize = sizeof(uint);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeVec2(vec2&& val, int offset)
    //    {
    //        int writeSize = sizeof(vec2);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeVec3(vec3&& val, int offset)
    //    {
    //        int writeSize = sizeof(vec3);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeVec4(vec4&& val, int offset)
    //    {
    //        int writeSize = sizeof(vec4);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeVec3i(ivec3&& val, int offset)
    //    {
    //        int writeSize = sizeof(ivec3);
    //        write((char*)&val, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    void writeString(string&& val, int offset)
    //    {
    //        writeInt16((int16_t)val.length());

    //        if (val.length() > 0)
    //        {
    //            write(val.c_str(), val.length(), val.length(), iFilePos);
    //            iFilePos += val.length();
    //        }
    //    }
    //    void writeMat4(mat4&& val, int offset)
    //    {
    //        //This must correspond to the same order in mat4..
    //        writeFloat(std::move(val._m11));
    //        writeFloat(std::move(val._m12));
    //        writeFloat(std::move(val._m13));
    //        writeFloat(std::move(val._m14));
    //        writeFloat(std::move(val._m21));
    //        writeFloat(std::move(val._m22));
    //        writeFloat(std::move(val._m23));
    //        writeFloat(std::move(val._m24));
    //        writeFloat(std::move(val._m31));
    //        writeFloat(std::move(val._m32));
    //        writeFloat(std::move(val._m33));
    //        writeFloat(std::move(val._m34));
    //        writeFloat(std::move(val._m41));
    //        writeFloat(std::move(val._m42));
    //        writeFloat(std::move(val._m43));
    //        writeFloat(std::move(val._m44));
    //    }
    //    void write(const char* buf, int writeSize, int offset)
    //    {
    //        write(buf, writeSize, writeSize, offset == memsize_max ? iFilePos : offset);
    //        iFilePos += writeSize;
    //    }
    //    RetCode write(const char* buf, int count, int bufcount, int offset)
    //    {
    //        AssertOrThrow2((offset >= 0) || (offset == memsize_max));

    //        if (count > bufcount)
    //        {
    //            BroThrowException("DataBuffer - out of bounds.");
    //        }
    //        if (offset == memsize_max)
    //        {
    //            offset = 0;
    //        }

    //        //Dynamically reallocate.
    //        if (_data.count() < offset + count)
    //        {
    //            _data.realloca(offset + count);
    //        }
    //        _data.copyFrom(buf, count, offset, 0);

    //        return GR_OK;
    //    }
    //    //////////////////////////////////////////////////////////////////////////
    //    //////////////////////////////////////////////////////////////////////////
    //    //////////////////////////////////////////////////////////////////////////
    //    bool writeToDisk(string fileLoc)
    //    {
    //        if (FileSystem::SDLFileWrite(fileLoc, _data.ptr(), _data.count()) == 0)
    //        {
    //            return true;
    //        }
    //        return false;
    //        //DiskFile df;
    //        //df.openForWrite(DiskLoc(fileLoc), FileWriteMode::Truncate);
    //        //df.write((char*)_data.ptr(), _data.count());
    //        //df.close();
    //    }

    //}


}
