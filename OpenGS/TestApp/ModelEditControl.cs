using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class ModelViewControl
    {
        public OpenGS.Engine Engine { get; private set; } = null;
        public float rotate_speed = 0.5f;

        List<OpenGS.Mesh> Meshes = new List<OpenGS.Mesh>();
        public Func<float> GetZoom = null;
        public ModelViewControl()
        {
            Init();
        }
        private void Init()
        {
            Globals.MainForm.Log("Creating Engine");
            Engine = new OpenGS.Engine();
            Engine.OnError = 
                (code, str) =>
            {
                string st = code.ToString();// 
                Globals.MainForm.BeginInvoke((Action)(() =>
                {
                    Globals.MainForm.Log(st);
                    if (str.Length > 0)
                    {
                        Globals.MainForm.Log(str);
                    }
                }));
            };
            Engine.OnWarn = (str) =>
            {
                Globals.MainForm.BeginInvoke((Action)(() =>
                {
                    Globals.MainForm.Log(str);
                }));
            };

            Engine.OnShaderLog = (st) =>
            {
                Globals.MainForm.BeginInvoke((Action)(() =>
                {
                    Globals.MainForm.ShaderLog(st);
                }));
            };

            Globals.MainForm.Log("Init Engine");
            Engine.Init();
            Engine.Renderer.Camera = new OpenGS.Camera3D();
            Engine.Renderer.ShowAxis = true;
            Engine.Renderer.ShowGrid = true;

            LoadModel("./rsc/Monkey.obj");
            float theta = 0, r = 5;
            Engine.OnUpdate = (dt) =>
            {
                float TwoPi = (float)Math.PI * 2;
                theta = (theta + TwoPi * dt * rotate_speed) % TwoPi; //360/sec

                float d = GetZoom == null ? 0.25f : GetZoom();// (float)((double)Globals.MainForm.tb.Value / (double)Globals.MainForm.tb.Maximum);

                Engine.Renderer.Camera.Pos = new OpenGS.vec3(
                    (float)Math.Cos((double)theta) * r * d,
                    Engine.Renderer.Camera.Pos.y,
                    (float)Math.Sin((double)theta) * r * d);

                Engine.Renderer.Camera.View = -Engine.Renderer.Camera.Pos.Normalized();
            };
            Engine.OnDraw = (renderer, dt) =>
            {
                //Engine.Renderer.Camera.Pos
                Engine.Renderer.MeshShader.Bind(Engine.Renderer.Camera);
                foreach(OpenGS.Mesh m in Meshes)
                {
                    m.Render();
                }
                Engine.Renderer.MeshShader.Unbind();

                renderer.FlatShader.Bind(renderer.Camera);
                foreach (OpenGS.Mesh m in Meshes)
                {
                    renderer.DrawBox(m.BoundBox, new OpenGS.vec4(1, 1, 0, 1));
                }
                renderer.FlatShader.Unbind();
            };
            Engine.OnDispose = () => {
                foreach (OpenGS.Mesh m in Meshes)
                {
                    m.Dispose();
                }
            };

            Globals.MainForm.Log("Run Engine");
            Engine.Run();
        }

        public void LoadModel(string path)
        {
            foreach(OpenGS.Mesh m in Meshes)
            {
                m.Dispose();
            }
            Meshes.Clear();

            try
            {
                OpenGS.ObjFile obfile = new OpenGS.ObjFile();
                obfile.Load(path, false);
                Meshes = obfile.Meshes;
            }
            catch (Exception ex)
            {
                Globals.MainForm.BeginInvoke((Action)(() =>
                {
                    Globals.MainForm.ShaderLog(ex.ToString());
                }));
            }


        }

    }
}
