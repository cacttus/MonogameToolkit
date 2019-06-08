using System;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public class Viewport
    {
        public int X { get;  set; } = 0;
        public int Y { get;  set; } = 0;
        public int Width { get;  set; } = 800;
        public int Height { get;  set; } = 600;

        public Viewport(int w, int h)
        {
            Width = w;
            Height = h;
        }
    }
}
