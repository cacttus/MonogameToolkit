using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    /// <summary>
    /// This probably isn't needed.
    /// Our environment is gonig to remain 3D.
    /// </summary>
    public class Camera2D : Camera
    {
        public Camera2D() 
        {
        }
       // public bool OverrideOrthoWidthWithViewportWidth { get; set; } = false;
        public float OrthoWidth { get; set; } = 90;//The width (in units) of ortho view.  Set to Viewport

        public float Height()
        {
            float spct = (float)Viewport.Height / (float)Viewport.Width;
            float h = OrthoWidth * spct;
            return h;
        }

        public override void SetupProjectionMatrix()
        {
           // float w = OrthoWidth;
           // if (OverrideOrthoWidthWithViewportWidth)
           // {
           //     w = Viewport.Width;
           // }



            ProjMatrix = Matrix4.CreateOrthographic(OrthoWidth, Height(), Near, Far);
        }
        public override PickRay ProjectPoint(vec2 screenPoint)
        {
            PickRay pt = new PickRay();
            vec2 screen = screenPoint;

            //translate to center
            screen.x -= (float)Viewport.Width / 2.0f;
            screen.y = (float)Viewport.Height / 2.0f - screen.y;

            //Get up /rioght
            vec3 right = View.Cross(Up);
            vec3 up = Up;

            // Get screen world center position
            vec3 ncPos = Pos + View * Near;

            pt.Origin = ncPos + right * screen.x + up * screen.y;
            pt._length = Far;

            pt.Dir = View;
            pt.Opt();

            return pt;
        }
        public override void Pan(vec3 v)
        {
            //v is in viewport coordinates, convert to orthographic space


            float wpct = OrthoWidth / Viewport.Width;

            float hpct = Height() / Viewport.Height;

            Pos = new vec3(Pos.x + v.x * wpct, Pos.y + v.y * hpct, Pos.z);
        }
    }
}
