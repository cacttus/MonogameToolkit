using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class ImageEditControl
    {
        public OpenGS.Engine Engine { get; private set; } = null;


        public ImageEditControl()
        {
            Init();
        }
        private void Init()
        {
            Globals.MainForm.Log("Creating Engine");
            Engine = new OpenGS.Engine();
            Engine.OnError = (code, str) =>
            {
                Globals.MainForm.Log(str + Environment.NewLine + code.ToString());
            };
            Engine.OnWarn = (str) =>
            {
                Globals.MainForm.Log(str);
            };
            Engine.OnShaderLog = (st) =>
            {
                Globals.MainForm.ShaderLog(st);
            };

            Globals.MainForm.Log("Init Engine");
            Engine.Init();
            Engine.Renderer.Camera = new OpenGS.Camera2D();
            Engine.Renderer.Camera.Pos = new OpenGS.vec3(0, 0, 1000);
            Engine.Renderer.Camera.View = new OpenGS.vec3(0, 0, -1);
            Engine.Renderer.ShowAxis = true;
            Engine.Renderer.ShowGrid = true;

            Engine.OnUpdate = (dt) =>
            {

            };
            Engine.OnDraw = (renderer, dt) =>
            {
                //renderer.FlatShader.Bind(renderer.Camera);
                //foreach (OpenGS.Texture2D m in Engine.QuadBlitter.Buffers.Keys)
                //{
                //    renderer.DrawBox(m.BoundBox, new OpenGS.vec4(1, 1, 0, 1));
                //}
                //renderer.FlatShader.Unbind();
            };

            Globals.MainForm.Log("Run Engine");
            Engine.Run();

            LoadImage("./rsc/TestImage.png");
        }

        public void LoadImage(string img)
        {
            //Draw a quad.
            try
            {
                string full = System.IO.Path.GetFullPath(img);

                Bitmap b = new Bitmap(full);

                float pct = (float)b.Width / (float)b.Height;

                OpenGS.Texture2D tex = new OpenGS.Texture2D(b);
                OpenGS.Quad_Vert quad = new OpenGS.Quad_Vert();

                OpenGS.Camera2D c2 = this.Engine.Renderer.Camera as OpenGS.Camera2D;

                //The Z value must be within the near/far plane [1, 1000]
                float Z = 500;
                float rh = (float)b.Height / c2.Height();
                quad.v0 = new OpenGS.vec3(0, 0, Z);
                quad.v1 = new OpenGS.vec3(70, 70, Z);

                quad.t0.x = 0;
                quad.t0.y = 1;
                quad.t1.x = 1;
                quad.t1.y = 0;

                quad._pickColor = 1;
                quad._color = rgba(255, 255, 255, 255);

                Engine.QuadBlitter.Buffers.Clear();
                Engine.QuadBlitter.Add(tex, quad);

                //Set the Winforms preview image for debug comparison
                Globals.MainForm.Loaded.Image = b;
            }
            catch (Exception ex)
            {
                Globals.MainForm.Log(ex.ToString());
            }
        }
        public uint rgba(byte r, byte g, byte b, byte a)
        {
            return
                (((uint)r << 24) & 0xFF000000) | 
                (((uint)g << 16) & 0x00FF0000) | 
                (((uint)b << 8) & 0x0000FF00) | 
                (((uint)a << 0) & 0x000000FF);
        }







    }//end class


}
