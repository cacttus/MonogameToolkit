using System;
using OpenTK.Graphics.OpenGL;

using mat2 = OpenTK.Matrix2;
using mat3 = OpenTK.Matrix3;
using mat4 = OpenTK.Matrix4;

namespace OpenGS
{
    public abstract class Camera : Node
    {
        public vec3 Up { get; private set; }
        public vec3 Right { get; private set; }
        public vec3 View { get; set; }
        public Viewport Viewport { get; private set; } = null;
        public float Near { get; private set; } = 1.0f;
        public float Far { get; private set; } = 1000.0f;

        public mat4 ViewMatrix;
        public mat4 ProjMatrix;
        public Camera() 
        {
            Viewport = new Viewport(Globals.Engine.GLControl.Width, Globals.Engine.GLControl.Height);
            Pos = new vec3(5,5,5);
            View = -Pos.Normalized();
        }
        public void Setup()
        {
            GL.Scissor(Viewport.X, Viewport.Y, Viewport.Width, Viewport.Height);
            GL.Viewport(Viewport.X, Viewport.Y, Viewport.Width, Viewport.Height); // Use all of the glControl painting area

            SetupProjectionMatrix();

            vec3 lookAtPos = Pos + View;

            Right = View.Cross(new vec3(0, 1, 0));
            Up = Right.Cross(View);

            ViewMatrix = mat4.LookAt(Pos.ToOpenTK(), lookAtPos.ToOpenTK(), Up.ToOpenTK());
        }
        public void Zoom(float amt)
        {
            float len = Pos.Len();
            len += amt;
            if (len <= 2.0f)
            {
                len = 2.0f;
            }

            Pos = View * -len;

        }

        public abstract void Pan(vec3 panDelta);
        public abstract void SetupProjectionMatrix();
        public abstract PickRay ProjectPoint(vec2 screenPoint);
        public override void Resize(Viewport vp) { }
        public override void Update() { }
        public override void Render() { }
        public override void Dispose() { }
        public override void UpdateBoundBox()
        {
            //BoundBox._vmax = BoundBox._vmin = Pos;
            //BoundBox._vmax.x += Volume.r;
            //BoundBox._vmax.y += Volume.r;
            //BoundBox._vmax.z += Volume.r;
            //BoundBox._vmin.x += -Volume.r;
            //BoundBox._vmin.y += -Volume.r;
            //BoundBox._vmin.z += -Volume.r;
        }


    }
}
