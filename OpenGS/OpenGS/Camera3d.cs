using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public class Camera3D : Camera
    {
        float _f_hfov;//horiz fov
        float _f_tan_fov_2;

        public float FOV
        {
            get { return _f_hfov; }
            set
            {
                _f_hfov = value;
                _f_tan_fov_2 = (float)Math.Tan((double)_f_hfov / 2.0);
            }
        }
        public Camera3D()
        {
            FOV = (float)Math.PI / (float)6;	// - Horizontal Field of view
        }
        public override void SetupProjectionMatrix()
        {
            float a = (float)Viewport.Width / (float)Viewport.Height;
            ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(_f_hfov, a, Near, Far);
        }
        public override PickRay ProjectPoint(vec2 screenPoint)
        {
            throw new NotImplementedException();
        }
        public override void Pan(vec3 panDelta)
        {
            throw new NotImplementedException();
        }

    }
}
