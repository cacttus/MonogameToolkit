using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public struct v3n3x2
    {
        public vec3 v;
        public vec3 n;
        public vec2 x;
        public static int ByteSize()
        {
            int siz = System.Runtime.InteropServices.Marshal.SizeOf(default(v3n3x2));
            return siz;
        }
    }

    public struct v3c4
    {
        public vec3 v;
        public float _pad0;
        public vec4 c;
        public static int ByteSize()
        {
            int siz = System.Runtime.InteropServices.Marshal.SizeOf(default(v3c4));
            return siz;
        }
    }

    public struct Quad_Vert
    {
        public vec3 v0;
        public uint _pickColor;//Pickable color.
        public vec3 v1;
        public uint _color;//byte color r,g,b 0-255
        public vec2 t0;
        public vec2 t1;

        public static int ByteSize()
        {
            int siz = System.Runtime.InteropServices.Marshal.SizeOf(default(Quad_Vert));
            return siz;
        }

        public static void BindAttribs()
        {
            int bytesize = Quad_Vert.ByteSize();

            int v2 = vec2.ByteSize;
            int v3 = vec3.ByteSize;
            int ui = sizeof(uint);

            //Vertex Attributes
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0));

            GL.EnableVertexAttribArray(1);
            GL.VertexAttribIPointer(1, 1, VertexAttribIntegerType.UnsignedInt, bytesize, (IntPtr)(0 + v3));

            GL.EnableVertexAttribArray(2);
            GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0 + v3 + ui));

            GL.EnableVertexAttribArray(3);
            GL.VertexAttribIPointer(3, 1, VertexAttribIntegerType.UnsignedInt, bytesize, (IntPtr)(0 + v3 + ui + v3));

            GL.EnableVertexAttribArray(4);
            GL.VertexAttribPointer(4, 2, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0 + v3 + ui + v3 + ui));

            GL.EnableVertexAttribArray(5);
            GL.VertexAttribPointer(5, 2, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0 + v3 + ui + v3 + ui + v2));
        }
    }

}
