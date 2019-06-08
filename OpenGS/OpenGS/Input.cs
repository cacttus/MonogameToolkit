using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGS
{
    public class Input
    {
        private vec3 LastMousePosProjected = new vec3(0, 0, 0);
        private vec2 MouseClick;
        private bool MouseMMBIsDown = false;

        public Input(Engine engine)
        {
            GLControl ctl = engine.GLControl;
            Renderer rd = engine.Renderer;
            ctl.MouseWheel += (s, e) =>
            {
                if ((GLControl.ModifierKeys & Keys.Control) == Keys.Control)
                {
                    if (rd.Camera != null)
                    {
                        if (e.Delta > 0)
                        {
                            rd.Camera.Zoom(1.0f);
                        }
                        else
                        {
                            rd.Camera.Zoom(-1.0f);
                        }
                    }

                }
            };
            ctl.MouseDown += (s, e) =>
            {
                if(e.Button == System.Windows.Forms.MouseButtons.Middle)
                {
                    MouseMMBIsDown = true;
                    PickRay pr = rd.Camera.ProjectPoint(new vec2(e.X, e.Y));
                    LastMousePosProjected = pr.Origin + pr.Dir;
                    ctl.Cursor = System.Windows.Forms.Cursors.SizeAll;
                }

            };
            ctl.MouseLeave += (s, e) =>
            {
                
                MouseMMBIsDown = false;
                ctl.Cursor = System.Windows.Forms.Cursors.Arrow;
                
            };
            ctl.MouseUp += (s, e) =>
            {
                MouseMMBIsDown = false;
                ctl.Cursor = System.Windows.Forms.Cursors.Arrow;
            };
            ctl.MouseMove += (s, e) =>
            {
                if (MouseMMBIsDown)
                {
                    if (rd.Camera != null)
                    {
                        PickRay pr = rd.Camera.ProjectPoint(new vec2(e.X, e.Y));
                        vec3 proj = pr.Origin + pr.Dir;
                        vec3 dv = proj - LastMousePosProjected;

                        rd.Camera.Pan(-dv);

                        LastMousePosProjected = proj;
                    }
                }

            };
        }
    }
}
