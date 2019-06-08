using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Diagnostics;
using mat2 = OpenTK.Matrix2;
using mat3 = OpenTK.Matrix3;
using mat4 = OpenTK.Matrix4;

namespace OpenGS
{
    public enum ShaderLoadState
    {
        None,
        Loading,
        Failed,
        Success
    }

    public class Shader
    {
        private List<int> _textureBindings = new List<int>();

        private int _vertexShaderHandle = -1;
        private int _fragmentShaderHandle = -1;
        private int _geomShaderHandle = -1;

        private int _modelMatrixLocation = -1;
        private int _projMatrixLocation = -1;
        private int _viewMatrixLocation = -1;

        private int _shaderProgramHandle = -1;

        private List<string> _shaderErrors = new List<string>();
        private ShaderLoadState _loadState = ShaderLoadState.None;

        public bool IsLoaded { get { return _loadState == ShaderLoadState.Success; } }

        #region Public:Methods
        public void Create(string vsSrc, string gsSrc, string psSrc)
        {
            Globals.CheckGpuErrorsDbg();
            {
                _loadState = ShaderLoadState.Loading;
                Globals.LogShader("Creating New Shader...");
                CreateShaders(vsSrc, gsSrc, psSrc);
                CreateProgram();
                if (_loadState != ShaderLoadState.Failed)
                {
                    GL.UseProgram(_shaderProgramHandle);
                    QueryMatrixLocations();

                    _loadState = ShaderLoadState.Success;
                }
                else
                {
                    Globals.LogShader("Failed to create shader program.\r\n" + String.Join("\r\n", _shaderErrors.ToArray()));
                }
                Globals.LogShader("...Done Creating Shader");
            }
            Globals.CheckGpuErrorsDbg();
        }
        public void Bind(Camera cam)
        {
            if (_loadState == ShaderLoadState.Success)
            {
                GL.UseProgram(_shaderProgramHandle);

                //Bind all textures (regardless)
                int i = 0;
                foreach(int loc in this._textureBindings)
                {
                    GL.Uniform1(loc, i);
                    i++;
                }

                //Bind matrixes
                if (_projMatrixLocation > -1)
                {
                    GL.UniformMatrix4(_projMatrixLocation, false, ref cam.ProjMatrix);
                }
                if (_viewMatrixLocation > -1)
                {
                    GL.UniformMatrix4(_viewMatrixLocation, false, ref cam.ViewMatrix);
                }
                if (_modelMatrixLocation > -1)
                {
                    mat4 def = mat4.Identity;
                    GL.UniformMatrix4(_modelMatrixLocation, false, ref def);
                }
            }
        }
        public void Unbind()
        {
            if(_loadState == ShaderLoadState.Success)
            {
                GL.UseProgram(0);
            }
        }
        public void Dispose()
        {
            if (GL.IsProgram(this._shaderProgramHandle))
            {
                GL.DeleteProgram(this._shaderProgramHandle);
            }

            DisposeShader(_geomShaderHandle);
            DisposeShader(_vertexShaderHandle);
            DisposeShader(_fragmentShaderHandle);
        }
        public void DisposeShader(int shader)
        {
            if (GL.IsShader(shader))
            {
                GL.DeleteShader(shader);
            }
        }
        #endregion

        #region Private: Methods
        private void CreateShaders(string vsSrc, string gsSrc, string psSrc)
        {
            Globals.CheckGpuErrorsDbg();

            CompileShader("Vertex Shader", ShaderType.VertexShader, vsSrc, ref _vertexShaderHandle);
            CompileShader("Geom Shader", ShaderType.GeometryShader, gsSrc, ref _geomShaderHandle);
            CompileShader("Frag Shader", ShaderType.FragmentShader, psSrc, ref _fragmentShaderHandle);
        }
        private void CompileShader(string typeName, ShaderType type, string source, ref int handle)
        {
            if (source != "")
            {
                handle = GL.CreateShader(type);
                Globals.CheckGpuErrorsDbg();
                GL.ShaderSource(handle, source);
                Globals.CheckGpuErrorsDbg();
                GL.CompileShader(handle);
                Globals.CheckGpuErrorsDbg();

                int success = 0;
                GL.GetShader(handle, ShaderParameter.CompileStatus, out success);
                if (success == 0)
                {
                    string log = FormatShaderLog(GL.GetShaderInfoLog(handle));
                    Globals.LogShader(typeName + " Output:\r\n" + log);
                }
                else
                {
                    Globals.LogShader(typeName + " Compiled Successfully.");
                }
            }
        }
        private void AttachShader(int shader)
        {
            if (GL.IsShader(shader))
            {
                GL.AttachShader(_shaderProgramHandle, shader);
                Globals.CheckGpuErrorsDbg();
            }
        }
        private void CreateProgram()
        {
            Globals.CheckGpuErrorsDbg();

            _shaderProgramHandle = GL.CreateProgram();

            AttachShader(_vertexShaderHandle);
            AttachShader(_geomShaderHandle);
            AttachShader(_fragmentShaderHandle);

            GL.LinkProgram(_shaderProgramHandle);
            Globals.CheckGpuErrorsDbg();

            string programInfoLog;
            GL.GetProgramInfoLog(_shaderProgramHandle, out programInfoLog);
            _shaderErrors = programInfoLog.Split('\n').ToList();
            Globals.LogShader(programInfoLog);

            int isLinked = 0;
            GL.GetProgram(_shaderProgramHandle, GetProgramParameterName.LinkStatus, out isLinked);
            if (isLinked == 0)
            {
                _loadState = ShaderLoadState.Failed;
            }

            Globals.CheckGpuErrorsDbg();
        }
        private void QueryMatrixLocations()
        {
            Globals.CheckGpuErrorsDbg();

            _projMatrixLocation = GL.GetUniformLocation(_shaderProgramHandle, "_proj");
            Globals.CheckGpuErrorsDbg();
            _modelMatrixLocation = GL.GetUniformLocation(_shaderProgramHandle, "_model");
            Globals.CheckGpuErrorsDbg();
            _viewMatrixLocation = GL.GetUniformLocation(_shaderProgramHandle, "_view");
            Globals.CheckGpuErrorsDbg();
        }
        private void QueryTextureLocations()
        {
            for(int n=0; n<20; ++n)
            {
                int loc = GL.GetUniformLocation(_shaderProgramHandle, "_ufTexture" + n);
                if (loc != -1)
                {
                    _textureBindings.Add(loc);
                }
            }
        }

        private string FormatShaderLog(string st)
        {
            st = st.Replace("\n", "\r\n");
            return st;
        }
   
        #endregion


    }
}
