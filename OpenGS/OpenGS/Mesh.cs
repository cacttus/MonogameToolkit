using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public class Mesh : Node
    {
        private int _intVboId = 0;
        private int _intIboId = 0;
        private int _intVaoId = 0;

        int NumIndexes = 0;
        int NumVertexes = 0;
        string LoadPath = "";
        public Mesh()
        {

        }
        public override void Update()
        {
        }
        public override void Resize(Viewport vp)
        {
        }
        public override void UpdateBoundBox()
        {
        }
        public override void Dispose()
        {
            GL.DeleteBuffer(_intVboId);
            GL.DeleteBuffer(_intIboId);
            GL.DeleteVertexArray(_intVaoId);
        }
        public override void Render()
        {
            GL.BindVertexArray(_intVaoId);
            Globals.CheckGpuErrorsDbg();

            GL.DrawElements(PrimitiveType.Triangles, NumIndexes, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Globals.CheckGpuErrorsDbg();
            GL.BindVertexArray(0);

            Globals.CheckGpuErrorsDbg();
        }
        public void AllocMesh(List<v3n3x2> verts, List<int> indexes, string loadPath="")
        {
            NumIndexes = indexes.Count;
            NumVertexes = verts.Count;
            LoadPath = loadPath;

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            _intVboId = GL.GenBuffer();
            _intIboId = GL.GenBuffer();
            _intVaoId = GL.GenVertexArray();

            GL.BindVertexArray(_intVaoId);
            Globals.CheckGpuErrorsRt();

            GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _intIboId);

            int bytesize = v3n3x2.ByteSize();

            //Vertex Attributes
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0));
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0 + 16));
            //GL.EnableVertexAttribArray(2);
            //GL.VertexAttribPointer(2, 2, VertexAttribPointerType.Float, false, bytesize, (IntPtr)(0 + 32));
            Globals.CheckGpuErrorsRt();

            GL.BindVertexArray(0);

            //Copy Data to GPU
            GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);
            GL.BufferData(
                BufferTarget.ArrayBuffer,
                (IntPtr)(verts.Count * v3n3x2.ByteSize()),
                verts.ToArray(),
                BufferUsageHint.StaticDraw
                );
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            Globals.CheckGpuErrorsRt();

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _intIboId);
            GL.BufferData(
                BufferTarget.ElementArrayBuffer,
                (IntPtr)(indexes.Count * sizeof(int)),
                indexes.ToArray(),
                BufferUsageHint.StaticDraw
                );
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
            Globals.CheckGpuErrorsRt();

        }
        public void ComputeBox()
        {
            try
            {
                //Grab verts from GPU
                v3n3x2[] verts = new v3n3x2[NumVertexes];

                GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);
                IntPtr VideoMemoryIntPtr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.ReadOnly);
                unsafe
                {
                    fixed (v3n3x2* SystemMemory = &verts[0])
                    {
                        v3n3x2* VideoMemory = (v3n3x2*)VideoMemoryIntPtr.ToPointer();
                        for (int i = 0; i < verts.Length; i++)
                        {
                            verts[i] = VideoMemory[i];
                        }
                    }
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

                //Calc box
                BoundBox.GenResetExtents();
                foreach (v3n3x2 v in verts)
                {
                    BoundBox.ExpandByPoint(v.v);
                }
            }
            catch (Exception ex)
            {
                Globals.LogWarn(ex.ToString());
            }
        }

    }
}
