using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;

namespace OpenGS
{
    public static class Globals
    {
        private static Dictionary<OpenTK.Graphics.IGraphicsContext, Engine> Engines = new Dictionary<OpenTK.Graphics.IGraphicsContext, Engine>();

        public static void LogWarn(string str)
        {
            Engine.OnWarn?.Invoke(str);
        }
        public static Engine Engine {
            get {
                //Get the engine for the currently active context
                OpenTK.Graphics.IGraphicsContext c = OpenTK.Graphics.GraphicsContext.CurrentContext;

                Engine val = null;
                if(!Engines.TryGetValue(c, out val))
                {
                    throw new Exception("No engine existed for current OpenGL context.");
                }
                return val;
            }
        }
        public static void SetEngine(Engine e)
        {
            if (e.GLControl == null)
            {
                throw new Exception("Tried to set engine before GLControl was created");
            }
            if (e.GLControl.Context == null)
            {
                throw new Exception("GLControl context doesn't exist.");
            }

            Engines.Add(e.GLControl.Context, e);
        }
        public static void SwapControl(Control toRemove, Control toAdd)
        {
            toAdd.Top = toRemove.Top;
            toAdd.Left = toRemove.Left;
            toAdd.Width = toRemove.Width;
            toAdd.Height = toRemove.Height;
            toAdd.Dock = toRemove.Dock;
            toAdd.Anchor = toRemove.Anchor;
            Control parent = toRemove.Parent;
            if (parent != null)
            {
                parent.Controls.Remove(toRemove);
                parent.Controls.Add(toAdd);
            }
        }
        public static void ShowMessage(string cap, string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, cap);
        }
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        public static void CheckGpuErrorsRt()
        {
            ErrorCode c = GL.GetError();
            if (c != ErrorCode.NoError)
            {
                string s = PrintDebugLog();
                Engine.OnError?.Invoke(c, s);
            }
        }
        public static string PrintDebugLog()
        {
            string log = "";
            
            for (int i = 0; i < 1000; ++i)
            {
                DebugSource Source;
                DebugType Type;
                DebugSeverity Severity;
                int id;
                int length;

                int bufsiz = 2048;
                string buf  = new string(' ', bufsiz);

                int numFound = GL.GetDebugMessageLog(1, bufsiz, out Source, out Type, out id, out Severity, out length, out buf);

                if (numFound == 0)
                {
                    break;
                }
                else
                {
                    log += buf.Trim();
                    continue;
                }
            }
            return log;
        }
        public static void LogShader(string st)
        {
            Engine.OnShaderLog?.Invoke(st);
        }
        public static void CheckGpuErrorsDbg()
        {
#if DEBUG
            CheckGpuErrorsRt();
#endif
        }
        //public static void CopyDataServerClient<T>(BufferTarget target, int bufferId, T[] Array_Pre_Allocated)
        //{
        //    IntPtr VideoMemoryIntPtr = GL.MapBuffer(BufferTarget.ArrayBuffer, BufferAccess.ReadOnly);
        //    unsafe
        //    {
        //        fixed (T* SystemMemory = &Array_Pre_Allocated[0])
        //        {
        //            T* VideoMemory = (v3n3x2*)VideoMemoryIntPtr.ToPointer();
        //            for (int i = 0; i < verts.Length; i++)
        //            {
        //                verts[i] = VideoMemory[i];
        //            }
        //        }
        //    }
        //    GL.UnmapBuffer(BufferTarget.ElementArrayBuffer);
        //}
        public static string[] GetValidOpenSaveUserFile(IWin32Window owner, bool bSave, 
            string filter, string defaultext, string initialdir, bool multiple = false, string defaultName = "")
        {
            return GetValidOpenSaveUserFile(owner, bSave,
             filter, filter, defaultext, initialdir, multiple, defaultName);
        }
        public static string[] GetValidOpenSaveUserFile(IWin32Window owner, bool bSave, string saveFilter,
            string loadFilter, string defaultext, string initialdir, bool multiple = false, string defaultName = "")
        {
            int num = 0;
            FileDialog fileDialog;
            string str;
            if (!bSave)
            {
                fileDialog = (FileDialog)new OpenFileDialog();
                str = loadFilter;
                (fileDialog as OpenFileDialog).Multiselect = multiple;
            }
            else
            {
                fileDialog = (FileDialog)new SaveFileDialog();
                str = saveFilter;
            }
            string fullPath = Path.GetFullPath(initialdir);
            fileDialog.InitialDirectory = fullPath;
            fileDialog.DefaultExt = defaultext;
            fileDialog.Filter = str;
            fileDialog.FilterIndex = num;
            if (string.IsNullOrEmpty(defaultName) == false)
            {
                fileDialog.FileName = defaultName + defaultext;
            }
            if (fileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return new string[0];
            }
            if (!bSave && !File.Exists(fileDialog.FileName))
            {
                return new string[0];
            }
            return fileDialog.FileNames;
        }
    }


}
