using System;
using System.Collections.Generic;
using System.Linq;
using mat2 = OpenTK.Matrix2;
using mat3 = OpenTK.Matrix3;
using mat4 = OpenTK.Matrix4;

namespace OpenGS
{
    /**
    *    @class ObjFile
    *    @brief Imports OBJ files STRICTLY FOR BRO.
    *       Simpler version of ObjFile
    *           Imports only Vertex, Normal, TCoord
    *           Exported from blender with export script
    *       For more generic .OBJ importing use ObjFile.
    *       Note - that's kind of messed up right now
    *
    *   This time we load directly into mesh specs, and compile a mesh spec hierarchy.
    *   No need for the conversion overhead.
    */
    public class ObjFile
    {
        public List<Mesh> Meshes { get; private set; } = new List<Mesh>();
        public bool DebugDisableVertexCompression { get; set; } = false;

        #region Private: MEmbers    
        const int MissingIndexValue = -1;
        private Mesh _pCurrentSpec = null;
        private mat4 _matLocalMatrix;
        private List<vec3> _vecVerts = new List<vec3>();
        private List<vec3> _vecNormals = new List<vec3>();
        private List<vec2> _vecTCoords = new List<vec2>();
        private int _iCurrentLine = 0;
        private string _sFileName;
        private Dictionary<ivec3, int> _mapVertexCache = new Dictionary<ivec3, int>(new ivec3EqualityComparer());
        private List<v3n3x2> _vecMeshVerts = new List<v3n3x2>();
        private List<int> _vecMeshIndexes = new List<int>();
        private bool _bFlipWinding = false;
        #endregion

        #region Public: Methods
        public ObjFile()//**Set this to false to disable compressed vertexes (optimized meshes)
        {
            _iCurrentLine = 0;
        }

        public void Load(string strFilePath, bool flipWinding)
        {
            // BufferedFile bufferedFile;
            _sFileName = strFilePath;
            _bFlipWinding = flipWinding;

            using (BufferedFile br = new BufferedFile(strFilePath))
            {
                loadObjFileContents(br);
            }


            addCurrentSpec();
        }
        #endregion

        #region Private: Methods
        private vec3 readVec3(BufferedFile br)
        {
            vec3 ret;
            ret.x = BufferedFile.strToFloat(br.getTok());
            ret.y = BufferedFile.strToFloat(br.getTok());
            ret.z = BufferedFile.strToFloat(br.getTok());
            return ret;
        }
        private vec2 readVec2(BufferedFile br)
        {
            vec2 ret;
            ret.x = BufferedFile.strToFloat(br.getTok());
            ret.y = BufferedFile.strToFloat(br.getTok());
            return ret;
        }
        private void loadObjFileContents(BufferedFile pBufferedFile)
        {
            string tok;

            while (!pBufferedFile.eof())
            {
                tok = pBufferedFile.getTok(); // plows through whitespace.

                if (tok.Equals("mtllib"))
                {
                    //20160509 Not Supported
                }
                else if (tok.Equals("usemtl"))
                {
                    //20160509 Not Supported
                }
                else if (tok.Equals("v"))
                {
                    _vecVerts.Add(readVec3(pBufferedFile));
                }
                else if (tok.Equals("vn"))
                {
                    _vecNormals.Add(readVec3(pBufferedFile));
                }
                else if (tok.Equals("vt"))
                {
                    _vecTCoords.Add(readVec2(pBufferedFile));
                }
                else if (tok.Equals("g"))
                {
                    parseGeom(pBufferedFile, tok);
                }
                else if (tok.Equals("f"))
                {
                    parseFace(pBufferedFile, tok);
                }
                else if (tok.Equals("mat"))
                {
                    Globals.LogWarn("Mesh Spec Local Matrix is deprectaed. Freeze all matrices before exporting meshes.");
                    _matLocalMatrix = parseMat4(pBufferedFile);
                }
                _iCurrentLine++;

                // - Eat to the next line, that is eat \r\n
                pBufferedFile.eatLine();
            }

        }
        private void parseGeom(BufferedFile pBufferedFile, string tok)
        {
            tok = pBufferedFile.getTokSameLineOrReturnEmpty();

            if (tok.Length > 0)
            {
                addCurrentSpec();
                _pCurrentSpec = new Mesh();
            }
        }
        private void parseFace(BufferedFile pBufferedFile, string tok)
        {
            if (_pCurrentSpec == null)
            {
                //The user missed a "g" directive before "f" 
                //Manually add it here.
                _pCurrentSpec = new Mesh();
            }

            List<string> strVec = new List<string>();
            int iComp;
            int[] indices = new int[3];

            // - Parse face groups x,y,z:  x/x/x  y/y/y  z/z/z
            for (int igroup = 0; igroup < 3; ++igroup)
            {
                tok = pBufferedFile.getTok();
                int strlind = 0; // last index of '/' + 1 (one char after it)

                tok = tok.Trim();// StringUtil::trim(tok);
                strVec = tok.Split('/').ToList();// StringUtil::split(tok, '/', strVec);

                //Parse face indexes x1/x2/x3
                for (iComp = 0; iComp < (int)strVec.Count; ++iComp)
                {
                    indices[iComp] = parseFaceComponent(tok, ref strlind, iComp);
                }

                addFaceVertex(indices[0], indices[1], indices[2]);//v, x, n

                strVec.Clear();
            }
        }
        private int parseFaceComponent(string tok, ref int strlind, int iComponent)
        {
            int /*size_t*/ strind = 0;// current index of '/'
            int idx; // parsed vertex face index
            string rt;

            strind = tok.IndexOf('/', strlind);
            if (strind < 0)
            {
                //Last item in the 3 element list.
                strind = tok.Length;
            }

            // Get the value of the face index
            if ((strind - strlind) == 0)
            {
                // - we have a xx//yy, If we have a missing index component then we just set the index to missing.
                //idx = MissingIndexValue;

                //20160509 we don't allow varied formats.
                //You're missing Tex Coords, Or Normals
                throw new Exception("Invalid object file format.  Missing face index." + iComponent + " at line " + _iCurrentLine);
            }
            else
            {
                rt = tok.Substring(strlind, strind - strlind);
                idx = BufferedFile.strToInt(rt);
            }

            strlind = (int)strind + 1; // cut out the '//'

            return idx;
        }
        private void addFaceVertex(int iVertex, int iTCoord, int iNormal)
        {
            int vi = iVertex - 1;
            int ni = iNormal - 1;
            int xi = iTCoord - 1;

            if (vi < 0)
                throw new Exception("Vertex buffer underflow at line " + _iCurrentLine);
            if (ni < 0)
                throw new Exception("Normal buffer underflow at line " + _iCurrentLine);
            if (xi < 0)
                throw new Exception("TCoord buffer underflow at line " + _iCurrentLine);
            if (vi >= (int)_vecVerts.Count)
                throw new Exception("Vertex buffer overflow at line " + _iCurrentLine);
            if (ni >= (int)_vecNormals.Count)
                throw new Exception("Normal buffer overflow at line " + _iCurrentLine);
            if (xi >= (int)_vecTCoords.Count)
                throw new Exception("TCoord buffer overflow at line " + _iCurrentLine);

            int newIndex = 0;

            //We're using this "vertex cache" to reduce vertex size by referenced face components in the OBJ
            newIndex = findCachedVertex(vi, xi, ni);
            if (newIndex < 0 || DebugDisableVertexCompression)
            {
                newIndex = addNewMeshVertex(vi, xi, ni);
            }

            _vecMeshIndexes.Add(newIndex);
        }
        private int addNewMeshVertex(int vi, int xi, int ni)
        {
            int newIndex;
            v3n3x2 vx;

            vx.v = _vecVerts[vi];
            vx.n = _vecNormals[ni];
            vx.x = _vecTCoords[xi];
            // vx.c = vec4(1, 1, 1, 1);

            newIndex = (int)_vecMeshVerts.Count;

            _vecMeshVerts.Add(vx);

            if (!DebugDisableVertexCompression)
            {
                addCachedVertex(newIndex, vi, xi, ni);
            }

            return newIndex;
        }
        private void addCurrentSpec()
        {
            if (_pCurrentSpec != null)
            {
                // Copy  spec vertexes.
                copySpecFragments(_pCurrentSpec);

                Meshes.Add(_pCurrentSpec);

                _vecMeshVerts.Clear();
                _vecMeshIndexes.Clear();
                clearVertexCache();
            }
            _matLocalMatrix = mat4.Identity;
            _pCurrentSpec = null;
        }

        private void copySpecFragments(Mesh pSpec)
        {
            if (_bFlipWinding)
            {
                for (int /*size_t*/ iInd = 0; iInd < _vecMeshIndexes.Count; iInd += 3)
                {
                    int t = _vecMeshIndexes[iInd + 1];
                    _vecMeshIndexes[iInd + 1] = _vecMeshIndexes[iInd + 2];
                    _vecMeshIndexes[iInd + 2] = t;
                }
            }
            pSpec.AllocMesh(_vecMeshVerts, _vecMeshIndexes, _sFileName);
            pSpec.ComputeBox();
        }
        private int findCachedVertex(int vi, int xi, int ni)
        {
            ivec3 v = new ivec3();
            v.x = vi;
            v.y = xi;
            v.z = ni;

            int ind = 0;
            if (_mapVertexCache.TryGetValue(v, out ind))
            {
                return ind;
            }
            return -1;
        }
        private void addCachedVertex(int newIndex, int vi, int xi, int ni)
        {
            ivec3 v = new ivec3();
            v.x = vi;
            v.y = xi;
            v.z = ni;

            System.Diagnostics.Debug.Assert(findCachedVertex(vi, xi, ni) == -1);

            _mapVertexCache.Add(v, newIndex);
        }
        private void clearVertexCache()
        {
            _mapVertexCache.Clear();
        }
        private mat4 parseMat4(BufferedFile bf)
        {
            // - Parse csv matrix string.
            string mat_str = bf.getTok();
            mat4 mOut = new mat4();
            parse_mat4(mat_str, ref mOut);
            return mOut;
        }
        private bool parse_mat4(string tok, ref mat4 mOut)
        {
            // - Parse csv matrix string.
            int n = 0;
            char c;
            float[] mat = new float[16];
            string val = "";
            int mat_ind = 0;

            while (n < tok.Length)
            {
                c = tok[n++];
                if (c == ',' || c == '\n' || n == tok.Length)
                {
                    mat[mat_ind++] = BufferedFile.strToFloat(val);
                    val = "";
                }
                else if (char.IsLetterOrDigit(c) || c == '-' || c == '.' || c == '+' || c == 'e')
                {
                    val += c;
                }
            }

            mOut = new mat4(
                mat[0],
                mat[1],
                mat[2],
                mat[3],
                mat[4],
                mat[5],
                mat[6],
                mat[7],
                mat[8],
                mat[9],
                mat[10],
                mat[11],
                mat[12],
                mat[13],
                mat[14],
                mat[15]);

            return true;
        }
        #endregion


    }
}
