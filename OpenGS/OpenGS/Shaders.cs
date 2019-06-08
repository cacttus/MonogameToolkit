using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGS
{
    public class Shaders
    {
        #region MeshDrawer
        public static string MeshDrawer_v3n3_v = @"
#version 330 core

layout(location = 0) in vec3 _v;//rect
layout(location = 1) in vec3 _n;//pick color

uniform mat4 _view;    
uniform mat4 _proj;

out vec3 _nOut;
void main() {
    _nOut = _n;

	gl_Position =  _proj * _view * vec4(_v, 1);	
}
";
        public static string MeshDrawer_v3n3_f = @"
#version 330 core
in vec3 _nOut;
out vec4 _gColorOut;

void main() {
    vec3 light = -normalize(vec3(-10,-10,-10));
    vec4 color = vec4(1,0,0,1);

    _gColorOut = dot(light, _nOut) * color;
}
";
        #endregion

        #region QuadBlitter
        public static string QuadBlitter_Vertex_1 = @"
#version 330 core

layout(location = 0) in vec3 _p0;
layout(location = 1) in uint _pick;//pick color
layout(location = 2) in vec3 _p1;
layout(location = 3) in uint _color;
layout(location = 4) in vec2 _t0;//tex
layout(location = 5) in vec2 _t1;

out vec3 _p0VS;
out vec3 _p1VS;
out vec2 _t0VS;
out vec2 _t1VS;

flat out uint _colorVS;
flat out uint _pickVS;

uniform mat4 _view;    
uniform mat4 _proj;

void main() {
    _p0VS = (_proj * _view * vec4(_p0,1)).xyz;
    _p1VS = (_proj * _view * vec4(_p1,1)).xyz;
    _t0VS = _t0;
    _t1VS = _t1;
     _colorVS = _color;
     _pickVS = _pick;	
}
                    ";
        public static string QuadBlitter_Geom_1 = @"
#version 330 core

layout(points) in;
layout(triangle_strip, max_vertices=4) out;

in vec3 _p0VS[];
in vec3 _p1VS[];
in vec2 _t0VS[];
in vec2 _t1VS[];
flat in uint _colorVS[];
flat in uint _pickVS[];

out vec3 _vertGS;
out vec2 _texGS;
flat out uint _pickGS;
flat out uint _colorGS;

void setGS() {
    _pickGS  = _pickVS[0];
    _colorGS  = _colorVS[0];
}

void main() {
    /*
    0x0y                   1x0y
        0------------ ----2
        |          /      |
        |  /              |
        1 ----------------3
    0x1y                   1x1y
    */
   
    float Z = _p0VS[0].z;


    setGS();
    _texGS            = vec2(_t0VS[0].x, _t0VS[0].y);
    _vertGS           = vec3(_p0VS[0].x, _p0VS[0].y, Z);
    gl_Position       = vec4(_p0VS[0].x, _p0VS[0].y, Z, 1);
    EmitVertex();
    
    setGS();
    _texGS            = vec2(_t0VS[0].x, _t1VS[0].y);
    _vertGS           = vec3(_p0VS[0].x, _p1VS[0].y, Z);
    gl_Position       = vec4(_p0VS[0].x, _p1VS[0].y, Z, 1);
    EmitVertex();

    setGS();
    _texGS            = vec2(_t1VS[0].x, _t0VS[0].y);
    _vertGS           = vec3(_p1VS[0].x, _p0VS[0].y, Z);
    gl_Position       = vec4(_p1VS[0].x, _p0VS[0].y, Z, 1);
    EmitVertex();

    setGS();
    _texGS            = vec2(_t1VS[0].x, _t1VS[0].y);
    _vertGS           = vec3(_p1VS[0].x, _p1VS[0].y, Z);
    gl_Position       = vec4(_p1VS[0].x, _p1VS[0].y, Z, 1);
    EmitVertex();

    
    EndPrimitive();
}
";

        public static string QuadBlitter_Fragment_1 = @"
#version 330 core

layout(location = 0) out vec4 _gColorOut;
//layout(location = 1) out vec4 _gPickOut;

uniform sampler2D _ufTexture0;

in vec3 _vertGS;
in vec2 _texGS;
flat in uint _pickGS;
flat in uint _colorGS;

void main(){
	vec4 tx = texture(_ufTexture0, vec2(_texGS));
    if(tx.a == 0) {
        discard;
    }
    float r = float((_colorGS>>24) & 0xFF) / 255.0f;
    float g = float((_colorGS>>16) & 0xFF) / 255.0f;
    float b = float((_colorGS>>8) & 0xFF) / 255.0f;
    float a = float((_colorGS>>0) & 0xFF) / 255.0f;
   
    _gColorOut = tx * vec4(r,g,b,a);
    //_gPickOut = _pickGS;
}
                    ";

        #endregion

        #region Flat
        public static string Flat_V = @"
#version 330 core

layout(location = 0)in vec3 _v301; //_vertex;
layout(location = 1)in vec4 _c401; //_color;
          
uniform mat4 _view;    
uniform mat4 _proj;

out vec4 _colorInOut;

void main() {
	_colorInOut = _c401;

	// peanut vendor man
	gl_Position = _proj * _view * vec4(_v301, 1);
}
";
        public static string Flat_F = @"
#version 330 core

in vec4 _colorInOut;

layout(location = 0) out vec4 _gColorOut;

void main() {
	_gColorOut = _colorInOut;
   
}
";


        #endregion

        #region Renderer
        public static string Renderer_VertexShaderSource = @"
#version 400
 
uniform mat4 _model;            
uniform mat4 _proj;

layout(location = 0)in vec3 _v;
layout(location = 1)in vec4 _c;
layout(location = 2)in vec3 _n;
layout(location = 3)in vec2 _x;

out vec3 _vsNormal;
out vec2 _vsTcoords;
out vec3 _vsVertex;
out vec4 _vsColor;
void main(void)
{
    //not a proper transformation if modelview_matrix involves non-uniform scaling
    _vsNormal = normalize(( modelview_matrix * vec4( _n, 0 ) ).xyz);
    _vsTcoords = _x;
    _vsColor = _c;
    gl_Position = projection_matrix * modelview_matrix * vec4( _v, 1.0f );
    _vsVertex = gl_Position.xyz;
}
";

        public static string Renderer_FragmentShaderSource = @"
#version 400

uniform sampler2D _ufTextureId_i0;

in vec3 _vsNormal;
in vec2 _vsTcoords;
in vec3 _vsVertex;
in vec4 _vsColor;

out vec4 _psColorOut;
 
void main(void)
{
    vec3 light = vec3(0, 0, 10);
    vec3 surface = light - _vsVertex;
    vec4 diffuseTex = texture(_ufTextureId_i0, vec2(_vsTcoords));

    vec3 lightedTexel = diffuseTex.xyz  * clamp(dot(_vsNormal, surface),0,1) * _vsColor.rgb;

    _psColorOut.xyz = lightedTexel;
    _psColorOut.w = 1.0f;
}
";

        #endregion

    }
}
