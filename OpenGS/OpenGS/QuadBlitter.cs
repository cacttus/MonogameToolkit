using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    /// <summary>
    /// Draws quads on the x/y plane
    /// </summary>
    public class QuadBuffer : IDisposable
    {
        private int _intVboId = 0;
        private int _intVaoId = 0;
        private List<Quad_Vert> _objQuads = new List<Quad_Vert>();

        public List<Quad_Vert> Quads
        {
            get { return _objQuads; }
            set
            {
                _objQuads = value;
                Dirty = true;
            }
        }
        public bool Dirty { get; set; } = true;

        #region Public: Methods
        public QuadBuffer()
        {
            CreateBuffer();
        }
        public void Update()
        {
            if (Dirty)
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);
                GL.BufferData(
                    BufferTarget.ArrayBuffer,
                    (IntPtr)(Quads.Count * Quad_Vert.ByteSize()),
                    Quads.ToArray(),
                    BufferUsageHint.StaticDraw
                    );
            }
        }
        public void Render(bool clear)
        {
            //*Texture should already be bound.
            GL.BindVertexArray(_intVaoId);
            GL.DrawArrays(PrimitiveType.Points, 0, Quads.Count);
            GL.BindVertexArray(0);

            if (clear)
            {
                if (Quads.Count > 0)
                {
                    //The block above prevents Dirty from being flagged in empty quad sets.
                    Quads.Clear();
                }
            }
        }
        public void Dispose()
        {
            GL.DeleteBuffer(_intVboId);
            GL.DeleteVertexArray(_intVaoId);
        }
        #endregion

        #region Private: Methods
        private void CreateBuffer()
        {
            _intVboId = GL.GenBuffer();
            _intVaoId = GL.GenVertexArray();

            GL.BindVertexArray(_intVaoId);
            GL.BindBuffer(BufferTarget.ArrayBuffer, _intVboId);

            Quad_Vert.BindAttribs();

            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        #endregion

    }
    public class QuadBlitter
    {
        public Dictionary<Texture2D, QuadBuffer> Buffers { get; private set; } = new Dictionary<Texture2D, QuadBuffer>();
        private Shader QuadBlitShader = null;

        #region Public: Methods
        public QuadBlitter()
        {
            QuadBlitShader = new Shader();

            QuadBlitShader.Create(
                Shaders.QuadBlitter_Vertex_1,
                Shaders.QuadBlitter_Geom_1,
                Shaders.QuadBlitter_Fragment_1
                );
        }
        public void Add(Texture2D tex, Quad_Vert quad)
        {
            QuadBuffer qb = null;
            if (!Buffers.TryGetValue(tex, out qb))
            {
                qb = new QuadBuffer();
                Buffers.Add(tex, qb);
            }

            qb.Quads.Add(quad);
        }
        public void Update()
        {
            foreach (Texture2D tex in this.Buffers.Keys)
            {
                QuadBuffer qb = null;
                if (Buffers.TryGetValue(tex, out qb))
                {
                    qb.Update();
                }
            }
        }
        public void Render(Camera cam, bool clear = false)
        {
            GL.Disable(EnableCap.CullFace);
            QuadBlitShader.Bind(cam);
            foreach (Texture2D tex in this.Buffers.Keys)
            {
                tex.Bind();
                QuadBuffer qb = null;
                if (Buffers.TryGetValue(tex, out qb))
                {
                    qb.Render(clear);
                }
                tex.Unbind();
            }
            QuadBlitShader.Unbind();
        }
        public void Dispose()
        {
            foreach (Texture2D tex in this.Buffers.Keys)
            {
                tex.Dispose();
                QuadBuffer qb = null;
                if (Buffers.TryGetValue(tex, out qb))
                {
                    qb.Dispose();
                }
            }

            QuadBlitShader.Dispose();
        }
        #endregion

    }
}
