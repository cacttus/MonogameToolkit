using OpenTK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using OpenTK.Graphics.OpenGL;
namespace OpenGS
{

    /// <summary>
    /// OpenGS - Main class to use.
    /// </summary>
    public class Engine : IDisposable
    {
        private Timer _objUpdateTimer = null;
        private Stopwatch _objStopwatch = new Stopwatch();

        //  public OpenTK.Graphics.IGraphicsContext GraphicsContext = null;
        public GLControl GLControl { get; set; } = null;
        public Renderer Renderer { get; set; } = null;
        public Action<ErrorCode, string> OnError = null;
        public Action<string> OnShaderLog = null;
        public Action<float> OnUpdate = null;//pararm = delta time (s)
        public Action<Renderer,float> OnDraw = null;
        public Action<string> OnWarn = null;
        public Action OnDispose = null;
        public Action OnPick = null;
        public QuadBlitter QuadBlitter { get; private set; } = null;
        private OpenTK.Graphics.GraphicsMode GraphicsMode { get; set; } = null;

        private List<Action> ContextActions = new List<Action>();

        public void Exec(Action a)
        {
            ContextActions.Add(a);
        }

        public bool Debug_Thread_Locked { get; private set; } = false;

        private Input Input { get; set; }
        public bool Pause { get; set; } = false;

        public Engine()
        {
            GraphicsMode = new OpenTK.Graphics.GraphicsMode(new OpenTK.Graphics.ColorFormat(8, 8, 8, 8), 24);

            //OpenTK.Graphics.GraphicsMode mode = OpenTK.Graphics.GraphicsMode.Default;
            GLControl = new GLControl(GraphicsMode, 4, 4, OpenTK.Graphics.GraphicsContextFlags.Debug | OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible);

            //https://stackoverflow.com/questions/40578910/opentk-multiple-glcontrol-with-a-single-context
            //GraphicsContext = new OpenTK.Graphics.GraphicsContext(GraphicsMode, GLControl.WindowInfo);
            //GraphicsContext.MakeCurrent(GLControl.WindowInfo);

            GLControl.MakeCurrent();
            Globals.SetEngine(this);//Must come after MakeCurrent

            Renderer = new Renderer();
        }

        public void Init()
        {
            int major = 0;
            GL.GetInteger(GetPName.MajorVersion, out major);
            int minor = 0;
            GL.GetInteger(GetPName.MajorVersion, out minor);

            GL.Enable(EnableCap.DebugOutput);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.CullFace);
            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.DebugOutputSynchronous);

            Globals.LogShader("OpenGL v" + major.ToString() + "." + minor.ToString());

            Renderer.Init();
            QuadBlitter = new QuadBlitter();
            Input = new Input(this);
        }

        public void Run()
        {
            _objUpdateTimer = new Timer();
            //https://stackoverflow.com/questions/13738059/how-can-i-get-a-c-sharp-timer-to-execute-on-the-same-thread-that-created-it
            _objUpdateTimer.SynchronizingObject = GLControl;//Keep on the same thread. 
            _objUpdateTimer.Interval = 1;//ASAP
            _objUpdateTimer.Elapsed += (o, e) =>
            {
                if (Pause == false)
                    Tick();
            };
            _objUpdateTimer.Start();
        }
        public void Dispose()
        {
            _objUpdateTimer.Stop();

            OnDispose?.Invoke();

            QuadBlitter?.Dispose();
            Renderer?.Dispose();
        }
        public void Tick()
        {
            Debug_Thread_Locked = true;

            GLControl.MakeCurrent();

            //Make sure we execute these things in the correct GL context.
            foreach(Action a in ContextActions)
            {
                a();
            }
            ContextActions.Clear();

            float dt = DeltaTime();

            QuadBlitter?.Update();
            OnUpdate?.Invoke(dt);

            Renderer.Begin();
            {
                QuadBlitter?.Render(Renderer.Camera, false);
                OnDraw?.Invoke(Renderer, dt);
            }
            Renderer.End();

            GLControl.SwapBuffers();

            //Single RT error checking at the end of the loop
            Globals.CheckGpuErrorsRt();

            Debug_Thread_Locked = false;
        }
        private float DeltaTime()
        {
            float dt = 0;//Init 0 to prevent crazy init values.
            if (_objStopwatch == null)
            {
                _objStopwatch = new Stopwatch();
                _objStopwatch.Start();
            }
            else
            {
                _objStopwatch.Stop();
                dt = _objStopwatch.ElapsedMilliseconds / 1000.0f;
                _objStopwatch.Restart();
            }
            return dt;
        }

    }
}
