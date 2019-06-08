using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public class Renderer : IDisposable
    {
        public Shader FlatShader { get; private set; } = null;
        public Shader MeshShader { get; private set; } = null;
        public Int64 FrameStamp { get; private set; } = 0;
        public Camera Camera { get; set; } = null;

        public bool ShowGrid { get; set; } = true;
        public bool ShowAxis { get; set; } = false;
        public Axis Axis { get; set; } = null;
        public InlineWire InlineWire { get; set; } = null;

        public Renderer()
        {
            Globals.Engine.GLControl.Resize += (s, e) => { Resize(); };
        }
        public void SetClearColor(vec4 color)
        {
            GL.ClearColor(color.x, color.y, color.z, color.w);
        }
        public void Init()
        {
            GL.CullFace(CullFaceMode.Back);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.ActiveTexture(TextureUnit.Texture0);
           // GL.Enable(EnableCap.Texture2D);
           // GL.Enable(EnableCap.DepthTest);
           // GL.Enable(EnableCap.ScissorTest);
            SetClearColor(new vec4(.4f, .4f, .4f, 1));

            FlatShader = new Shader();
            FlatShader.Create(
                Shaders.Flat_V,
                string.Empty,
                Shaders.Flat_F
                );
            MeshShader = new Shader();
            MeshShader.Create(
                Shaders.MeshDrawer_v3n3_v,
                string.Empty,
                Shaders.MeshDrawer_v3n3_f
                );

            Axis = new Axis(1.0f);
            InlineWire = new InlineWire();
        }
        public void Resize()
        {
            if (Camera != null && Camera.Viewport != null)
            {
                Camera.Viewport.Width = Globals.Engine.GLControl.Width;
                Camera.Viewport.Height = Globals.Engine.GLControl.Height;
            }
        }
        public void Begin()
        {
            Globals.CheckGpuErrorsRt();

            //Clear, set matrix
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Camera setup
            if (Camera != null)
            {
                Camera.Setup();
            }
        }

        public void End()
        {
            FrameStamp++;
            FlatShader.Bind(Camera);
            Axis.Render(this);
            FlatShader.Unbind();
        }
        public void DrawBox(box3 b, vec4 color)
        {
            vec3 i = b._vmin;
            vec3 a = b._vmax;

            vec3 p0 = new vec3(i.x, i.y, i.z);
            vec3 p1 = new vec3(a.x, i.y, i.z);
            vec3 p2 = new vec3(i.x, a.y, i.z);
            vec3 p3 = new vec3(a.x, a.y, i.z);
            vec3 p4 = new vec3(i.x, i.y, a.z);
            vec3 p5 = new vec3(a.x, i.y, a.z);
            vec3 p6 = new vec3(i.x, a.y, a.z);
            vec3 p7 = new vec3(a.x, a.y, a.z);

            List<v3c4> vt = new List<v3c4>();
            Action<vec3, vec3> doline = (va, vb) =>
            {
                vt.Add(new v3c4() { v = va, c = color });
                vt.Add(new v3c4() { v = vb, c = color });
            };

            doline(p0, p1);
            doline(p1, p3);
            doline(p3, p2);
            doline(p2, p0);

            doline(p5, p4);
            doline(p4, p6);
            doline(p6, p7);
            doline(p7, p5);

            doline(p0, p4);
            doline(p1, p5);
            doline(p2, p6);
            doline(p3, p7);

            InlineWire.SetData(vt);

            InlineWire.Render(this);
        }

        void RenderGrid(float r, float g, float b, int nSlices, float fSliceWidth, vec3 center)
        {
            GL.PushAttrib(AttribMask.AllAttribBits);

            GL.Disable(EnableCap.CullFace);

            float gridWidth_2 = nSlices * fSliceWidth / 2.0f;

            GL.LineWidth(1.0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(r, g, b);
            //Horiz lines
            for (int i = 0; i < nSlices + 1; ++i)
            {
                GL.Vertex3(center.x - (gridWidth_2),
                    center.y - 0,
                    center.z - (gridWidth_2) + (fSliceWidth * (float)i)
                    );
                GL.Vertex3(center.x + (gridWidth_2),
                    center.y - 0,
                    center.z - (gridWidth_2) + (fSliceWidth * (float)i)
                    );
            }
            for (int i = 0; i < nSlices + 1; ++i)
            {
                GL.Vertex3(center.x- (gridWidth_2) + (fSliceWidth * (float)i),
                    center.y - 0,
                    center.z - (gridWidth_2)
                    );
                GL.Vertex3(center.x - (gridWidth_2) + (fSliceWidth * (float)i),
                    center.y - 0,
                    center.z + (gridWidth_2)
                    );
            }
            GL.End();

            GL.PopAttrib();

        }

        public void Dispose()
        {
            Axis.Dispose();
        }
    }
}
