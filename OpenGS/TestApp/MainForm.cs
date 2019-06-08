using System;
using System.Drawing;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace TestApp
{
    public partial class MainForm : Form
    {
        ImageEditControl _objImageControl;
        ModelViewControl _objModelControl;

        public MainForm()
        {
            InitializeComponent();
        }
        public PictureBox Loaded { get { return _pbLoaded; } }
        private void MainForm_Load(object sender, EventArgs e)
        {
            Globals.MainForm = this;
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            _objImageControl = new ImageEditControl();
            OpenGS.Globals.SwapControl(_pnlScene1, _objImageControl.Engine.GLControl);

            _objModelControl = new ModelViewControl();
            _objModelControl.GetZoom = () => {
                return (float)trackBar2.Value / (float)trackBar2.Maximum * 4;
            };
            OpenGS.Globals.SwapControl(_pnlScene2, _objModelControl.Engine.GLControl);
        }
        public void Log(string s)
        {
            BeginInvoke((Action)(() =>
            {
                string st = DateTime.Now.ToString() + " >> " + s + Environment.NewLine;
                _txtErrors.AppendText(st);
            }));
        }

        public void ShaderLog(string s)
        {
            Globals.MainForm.BeginInvoke((Action)(() =>
            {
                string st = DateTime.Now.ToString() + " >> " + s + Environment.NewLine;
                _txtShaderLog.AppendText(st);
            }));
        }
        private void _pnlScene_Paint(object sender, PaintEventArgs e)
        {
            //int n = OpenTK.Graphics.OpenGL.AtiMeminfo.TextureFreeMemoryAti;
            //int n = OpenTK.Graphics.OpenGL.;
            //int dat = 0;
            //GL.GetInteger(GetPName.vbo AtiMeminfo.VboFreeMemoryAti, out dat);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_objImageControl.Engine.Pause)
            {
                _objImageControl.Engine.Tick();
            }
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (_objModelControl.Engine.Pause)
            {
                _objModelControl.Engine.Tick();
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _objImageControl.Engine.Dispose();
        }

        private void _btnPause1_Click(object sender, EventArgs e)
        {
            _objImageControl.Engine.Pause = !_objImageControl.Engine.Pause;
            _btnPause1.Text = _objImageControl.Engine.Pause ? "Resume" : "Pause";
        }

        private void _btnPause2_Click(object sender, EventArgs e)
        {
            _objModelControl.Engine.Pause = !_objModelControl.Engine.Pause;
            _btnPause1.Text = _objModelControl.Engine.Pause ? "Resume" : "Pause";
        }

        private void _btnLoadModel_Click(object sender, EventArgs e)
        {
            string[] files = OpenGS.Globals.GetValidOpenSaveUserFile(null, false, "OBJ|*.obj", "*.obj", "./");

            if (files.Length > 0)
            {
                string f = files[0];

                 //All Engine specific actions must be executed in the engine context
                _objModelControl.Engine.Exec(() => {
                    _objModelControl.LoadModel(f);
                });
            }

        }

        private void _btnLoadImage_Click(object sender, EventArgs e)
        {
            string[] files = OpenGS.Globals.GetValidOpenSaveUserFile(null, false, "PNG|*.png", "*.png", "./");

            if (files.Length > 0)
            {
                string f = files[0];

                //All Engine specific actions must be executed in the engine context
                _objImageControl.Engine.Exec(() => {
                    _objImageControl.LoadImage(f);
                });
            }

        }
    }
}
