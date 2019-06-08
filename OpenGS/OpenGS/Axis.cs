using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    /// <summary>
    /// Draws an axis.
    /// </summary>
    public class Axis : IDisposable
    {
        int _intVaoId = 0;
        int _intVboId = 0;
        int VertexCount = 0;

        public Axis(float length = 1)
        {
            List<v3c4> verts = new List<v3c4>();
            verts.Add(new v3c4() { v = new vec3(0, 0, 0), c = new vec4(1, 0, 0, 1) });
            verts.Add(new v3c4() { v = new vec3(length, 0, 0), c = new vec4(1, 0, 0, 1) });
            verts.Add(new v3c4() { v = new vec3(0, 0, 0), c = new vec4(0, 1, 0, 1) });
            verts.Add(new v3c4() { v = new vec3(0, length, 0), c = new vec4(0, 1, 0, 1) });
            verts.Add(new v3c4() { v = new vec3(0, 0, 0), c = new vec4(0, 0, 1, 1) });
            verts.Add(new v3c4() { v = new vec3(0, 0, length), c = new vec4(0, 0, 1, 1) });

            VertexCount = verts.Count;

            int byteSize = v3c4.ByteSize();

             _intVaoId = GL.GenVertexArray();
            GL.BindVertexArray(_intVaoId);

             _intVboId = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(verts.Count * byteSize),
                verts.ToArray(),
                BufferUsageHint.StaticDraw
                );

            //Vertex Attributes
            int attr_v_location = 0;//These are the layout=x locations in glsl
            GL.EnableVertexAttribArray(attr_v_location);
            GL.VertexAttribPointer(attr_v_location, 3, VertexAttribPointerType.Float, false, byteSize, (IntPtr)(0));

            int attr_c_location = 1;//These are the layout=x locations in glsl
            GL.EnableVertexAttribArray(attr_c_location);
            GL.VertexAttribPointer(attr_c_location, 4, VertexAttribPointerType.Float, false, byteSize, (IntPtr)(0 + 16));

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);

            Globals.CheckGpuErrorsDbg();
        }

        public void Render(Renderer r)
        {
            GL.BindVertexArray(_intVaoId);
            GL.DrawArrays(PrimitiveType.Lines, 0, VertexCount);
            GL.BindVertexArray(0);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(_intVboId);
            GL.DeleteVertexArray(_intVaoId);
        }
    }
}
