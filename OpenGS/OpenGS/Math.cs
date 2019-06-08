using System;
using System.Collections.Generic;

using mat2 = OpenTK.Matrix2;
using mat3 = OpenTK.Matrix3;
using mat4 = OpenTK.Matrix4;

namespace OpenGS
{
    public static class MathUtils
    {
        public static mat4 m4f16(float[] mv)
        {
            if (mv.Length != 16)
            {
                throw new Exception("matrix was not 16 elements wide.");
            }
            return new mat4(
                  mv[0],
                  mv[1],
                  mv[2],
                  mv[3],
                  mv[4],
                  mv[5],
                  mv[6],
                  mv[7],
                  mv[8],
                  mv[9],
                  mv[10],
                  mv[11],
                  mv[12],
                  mv[13],
                  mv[14],
                  mv[15]
                  );
        }
    }

    public class Plane2f
    {
        public Plane2f() { }
        public float D;
        public vec2 N;
        public Plane2f(vec2 n, vec2 pt)
        {
            D = -n.Dot(pt);
            N = n;
        }
        public float IntersectLine(vec2 p1, vec2 p2)
        {
            float t = -(N.Dot(p1) + D) / ((p2 - p1).Dot(N));
            return t;
        }
    }

    public class vec2EqualityComparer : IEqualityComparer<vec2>
    {
        public bool Equals(vec2 x, vec2 y)
        {
            return x.x == y.x && x.y == y.y;
        }

        public int GetHashCode(vec2 x)
        {
            return x.x.GetHashCode() + x.y.GetHashCode();
        }
    }

    public class ivec2EqualityComparer : IEqualityComparer<ivec2>
    {
        public bool Equals(ivec2 x, ivec2 y)
        {
            return x.x == y.x && x.y == y.y;
        }

        public int GetHashCode(ivec2 x)
        {
            return x.x.GetHashCode() + x.y.GetHashCode();
        }
    }
    public class ivec3EqualityComparer : IEqualityComparer<ivec3>
    {
        public bool Equals(ivec3 x, ivec3 y)
        {
            return (x.x == y.x) && (x.y == y.y) && (x.z == y.z);
        }

        public int GetHashCode(ivec3 x)
        {
            int h = x.GetHashCode() ;
            return h;
        }
    }
    public struct vec2
    {
        public float x, y;

        public static int ByteSize { get { return System.Runtime.InteropServices.Marshal.SizeOf(default(vec2)); } }
        public void Construct(float a, float b) { x = a; y = b; }
        public vec2(vec2 dxy) { x = dxy.x; y = dxy.y; }
        public vec2(float dx, float dy) { x = dx; y = dy; }
        public vec2(System.Drawing.Point p)
        {
            x = (float)p.X;
            y = (float)p.Y;
        }
        public float Len() { return (float)Math.Sqrt((x * x) + (y * y)); }

        public vec2 Perp()
        {
            //Perpendicular
            return new vec2(y, -x);
        }
        public void Normalize()
        {
            float l = Len();
            if (l != 0)
            {
                x /= l;
                y /= l;
            }
            else
            {
                x = 0; y = 0;
            }

        }
        public vec2 Normalized()
        {
            vec2 v = new vec2(this);
            v.Normalize();
            return v;

        }
        public float Len2() { return Dot(this, this); }
        //  public Vector2 toXNA() { return new Vector2(x, y); }


        static public implicit operator vec2(float f)
        {
            return new vec2(f, f);
        }
        //public static vec2 operator =(vec2 a, float f)
        //{
        //    return new vec2(f, f);
        //}
        public static float Dot(vec2 a, vec2 b)
        {
            return (a.x * b.x) + (a.y * b.y);
        }
        public float Dot(vec2 b)
        {
            return (x * b.x) + (y * b.y);
        }
        public static vec2 operator -(vec2 d)
        {
            return new vec2(-d.x, -d.y);
        }
        public static vec2 operator +(vec2 a, vec2 b)
        {
            return new vec2(a.x + b.x, a.y + b.y);
        }
        public static vec2 operator -(vec2 a, vec2 b)
        {
            return new vec2(a.x - b.x, a.y - b.y);
        }
        public static vec2 operator *(vec2 a, float b)
        {
            return new vec2(a.x * b, a.y * b);
        }
        public static vec2 operator *(vec2 a, vec2 b)
        {
            return new vec2(a.x * b.x, a.y * b.y);
        }
        public static vec2 operator /(vec2 a, float b)
        {
            return new vec2(a.x / b, a.y / b);
        }
        public static vec2 operator -(vec2 a, float f)
        {
            return new vec2(a.x - f, a.y - f);
        }
        public static vec2 Minv(vec2 a, vec2 b)
        {
            vec2 ret = new vec2();
            ret.x = (float)Math.Min(a.x, b.x);
            ret.y = (float)Math.Min(a.y, b.y);

            return ret;
        }
        public static vec2 Maxv(vec2 a, vec2 b)
        {
            vec2 ret = new vec2();
            ret.x = (float)Math.Max(a.x, b.x);
            ret.y = (float)Math.Max(a.y, b.y);
            return ret;
        }

    }

    public struct vec3
    {
        public static int ByteSize { get { return System.Runtime.InteropServices.Marshal.SizeOf(default(vec3)); } }

        public float x, y, z;
        public void Construct(float a, float b) { x = a; y = b; }
        public vec3(vec3 dxy) { x = dxy.x; y = dxy.y; z = dxy.z; }
        public vec3(float dx, float dy, float dz) { x = dx; y = dy; z = dz; }
        public OpenTK.Vector3 ToOpenTK() { return new OpenTK.Vector3(x, y, z); }

        public float Len() { return (float)Math.Sqrt((x * x) + (y * y) + (z * z)); }


        public void Normalize()
        {
            float l = Len();
            if (l != 0)
            {
                x /= l;
                y /= l;
                z /= l;
            }
            else
            {
                x = 0; y = 0; z = 0;
            }
        }
        public vec3 Normalized()
        {
            vec3 v = new vec3(this);
            v.Normalize();
            return v;
        }
        public float Len2() { return Dot(this, this); }

        static public implicit operator vec3(float f)
        {
            return new vec3(f, f, f);
        }
        public static float Dot(vec3 a, vec3 b)
        {
            return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
        }
        public float Dot(vec3 b)
        {
            return (x * b.x) + (y * b.y) + (z * b.z);
        }
        public vec3 Cross(vec3 v1)
        {
            vec3 vt;
            vt.x = (y * v1.z) - (v1.y * z);
            vt.y = (z * v1.x) - (v1.z * x);
            vt.z = (x * v1.y) - (v1.x * y);
            return vt;
        }

        public static vec3 operator -(vec3 d)
        {
            return new vec3(-d.x, -d.y, -d.z);
        }
        public static vec3 operator +(vec3 a, vec3 b)
        {
            return new vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static vec3 operator -(vec3 a, vec3 b)
        {
            return new vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static vec3 operator *(vec3 a, float b)
        {
            return new vec3(a.x * b, a.y * b, a.z * b);
        }
        public static vec3 operator *(vec3 a, vec3 b)
        {
            return new vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        public static vec3 operator /(vec3 a, float b)
        {
            return new vec3(a.x / b, a.y / b, a.z / b);
        }
        public static vec3 operator -(vec3 a, float f)
        {
            return new vec3(a.x - f, a.y - f, a.z - f);
        }
        public static vec3 Minv(vec3 a, vec3 b)
        {
            vec3 ret = new vec3();
            ret.x = (float)Math.Min(a.x, b.x);
            ret.y = (float)Math.Min(a.y, b.y);
            ret.z = (float)Math.Min(a.z, b.z);

            return ret;
        }
        public static vec3 Maxv(vec3 a, vec3 b)
        {
            vec3 ret = new vec3();
            ret.x = (float)Math.Max(a.x, b.x);
            ret.y = (float)Math.Max(a.y, b.y);
            ret.z = (float)Math.Max(a.z, b.z);
            return ret;
        }

    }
    public struct ivec3
    {
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

        public struct uvec2
    {
        public uint x { get; set; }
        public uint y { get; set; }
    }

    public struct ivec2
    {
        public int x { get; set; }
        public int y { get; set; }

        public ivec2(int dx, int dy) { x = dx; y = dy; }
        static public implicit operator ivec2(int f)
        {
            return new ivec2(f, f);
        }
        public static ivec2 operator -(ivec2 d)
        {
            return new ivec2(-d.x, -d.y);
        }
        public static ivec2 operator +(ivec2 a, ivec2 b)
        {
            return new ivec2(a.x + b.x, a.y + b.y);
        }
        public static ivec2 operator -(ivec2 a, ivec2 b)
        {
            return new ivec2(a.x - b.x, a.y - b.y);
        }
        public static ivec2 operator *(ivec2 a, int b)
        {
            return new ivec2(a.x * b, a.y * b);
        }
        public static ivec2 operator *(ivec2 a, ivec2 b)
        {
            return new ivec2(a.x * b.x, a.y * b.y);
        }
        public static ivec2 operator /(ivec2 a, int b)
        {
            return new ivec2(a.x / b, a.y / b);
        }
        public static ivec2 operator -(ivec2 a, int f)
        {
            return new ivec2(a.x - f, a.y - f);
        }
    }

    public struct vec4
    {
        public float x, y, z, w;

        public vec4(vec4 dxy) { x = dxy.x; y = dxy.y; z = dxy.z; w = dxy.w; }
        public vec4(float dx, float dy, float dz, float dw) { x = dx; y = dy; z = dz; w = dw; }
        //  public vec4(Vector4 v) { x = v.X; y = v.Y; z = v.Z; w = v.W; }//From XNA's Vector2

        public static vec4 Clamp(vec4 v, float a, float b)
        {
            vec4 ret = new vec4();
            ret.x = Globals.Clamp(v.x, a, b);
            ret.y = Globals.Clamp(v.y, a, b);
            ret.z = Globals.Clamp(v.z, a, b);
            ret.w = Globals.Clamp(v.w, a, b);
            return ret;
        }
        public void Clamp(float a, float b)
        {
            this = Clamp(this, a, b);
        }
        public void SetMinLightValue(float val)
        {
            //Make sure there's enough light for this.
            //Val = the minimum amount of light.
            //This isn't perfect
            float tot = x + y + z;
            if (tot < val)
            {
                float add = (2 - tot) / val;
                x += add;
                y += add;
                z += add;
                x = Globals.Clamp(x, 0, 1);
                y = Globals.Clamp(y, 0, 1);
                z = Globals.Clamp(z, 0, 1);
            }

        }

        // public Vector4 toXNA() { return new Vector4(x, y, z, w); }
        // public Color toXNAColor() { return new Color(toXNA()); }
        public static vec4 operator -(vec4 d)
        {
            return new vec4(-d.x, -d.y, -d.z, -d.w);
        }

        public static vec4 operator +(vec4 a, vec4 b)
        {
            return new vec4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }
        public static vec4 operator -(vec4 a, vec4 b)
        {
            return new vec4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }
        public static vec4 operator *(vec4 a, vec4 b)
        {
            return new vec4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }
        public static vec4 operator *(vec4 a, float b)
        {
            return new vec4(a.x * b, a.y * b, a.z * b, a.w * b);
        }
        public static vec4 operator /(vec4 a, float b)
        {
            return new vec4(a.x / b, a.y / b, a.z / b, a.w / b);
        }
        public static vec4 Minv(vec4 a, vec4 b)
        {
            vec4 ret = new vec4();
            ret.x = (float)Math.Min(a.x, b.x);
            ret.y = (float)Math.Min(a.y, b.y);
            ret.z = (float)Math.Min(a.z, b.z);
            ret.w = (float)Math.Min(a.w, b.w);
            return ret;
        }
        public static vec4 Maxv(vec4 a, vec4 b)
        {
            vec4 ret = new vec4();
            ret.x = (float)Math.Max(a.x, b.x);
            ret.y = (float)Math.Max(a.y, b.y);
            ret.z = (float)Math.Max(a.z, b.z);
            ret.w = (float)Math.Max(a.w, b.w);
            return ret;
        }

    }

    public struct RaycastHit
    {
        public bool _bHit;    // Whether the ray intersected the box.
        public bool _p1Contained;
        public bool _p2Contained;
        public float _t; // - Time to hit [0,1]
                         //  public void* _pPickData; // picked object (BvhObject3*)
        public vec2 _vNormal; //The normal of the plane the raycast hit.
                              //Do not include ray data for optimization.

        //public RaycastHit()
        //{
        //    reset();
        //}
        public bool trySetClosestHit(ref float closest_t)
        {
            //Easy way of iterating a closest hit.
            if (_bHit && (_t < closest_t))
            {
                closest_t = _t;
                return true;
            }
            return false;
        }
        public void reset()
        {
            _bHit = false;
            _p1Contained = false;
            _p2Contained = false;
            _t = float.MaxValue;
            //  _pPickData = NULL;
        }
        public void copyFrom(RaycastHit bh)
        {
            _bHit = bh._bHit;
            _p1Contained = bh._p1Contained;
            _p2Contained = bh._p2Contained;
            _t = bh._t;
        }
    }

    public struct ProjectedRay
    {
        public vec2 Origin;
        public vec2 Dir;
        public float _t;
        public vec2 _vNormal;

        // Found the following two cool optimizations on WIlliams et. al (U. Utah)
        public vec2 InvDir;
        public int[] Sign;

        public bool IsOpt { get; private set; }    // - return true if  we optimized this

        public float Length;// Max length

        public vec2 Begin() { return Origin; }
        public vec2 End() { return Origin + Dir; }

        public ProjectedRay(vec2 origin, vec2 dir)
        {
            Sign = new int[2];
            Origin = origin;
            Dir = dir;

            IsOpt = false;
            Length = float.MaxValue;//Must be maxvalue
            _t = float.MaxValue;
            _vNormal = new vec2(0, 0);

            //opt()
            //            //**New - optimization
            //http://people.csail.mit.edu/amy/papers/box-jgt.pdf
            //Don't set to zero. We need infinity (or large value) here.
            InvDir.x = 1.0f / Dir.x;
            InvDir.y = 1.0f / Dir.y;

            Sign[0] = (InvDir.x < 0) ? 1 : 0;
            Sign[1] = (InvDir.y < 0) ? 1 : 0;

            IsOpt = true;
        }
        //public void opt()
        //{



        //}
        public bool isHit()
        {
            return _t >= 0.0f && _t <= 1.0f;
        }
        public vec2 HitPoint()
        {
            vec2 ret = Begin() + (End() - Begin()) * _t;
            return ret;
        }
    }

    //Copied from Legend Of Kevin
    public struct box2
    {
        public vec2 Min;
        public vec2 Max;

        public float Width() { return Max.x - Min.x; }
        public float Height() { return Max.y - Min.y; }

        public vec2 TopRight() { return new vec2(Max.x, Min.y); }
        public vec2 BotRight() { return new vec2(Max.x, Max.y); }
        public vec2 BotLeft() { return new vec2(Min.x, Max.y); }
        public vec2 TopLeft() { return new vec2(Min.x, Min.y); }

        public void Construct(vec2 min, vec2 max)
        {
            Min = min; Max = max;
        }
        public box2(float x, float y, float w, float h)
        {
            Min = new vec2(x, y);
            Max = new vec2(w, h) + Min;
        }
        public box2(vec2 min, vec2 max)
        {
            Min = min;
            Max = max;
        }
        public vec2 Center()
        {
            return Min + (Max - Min) * 0.5f;
        }
        public static box2 FlipBoxH(box2 b, float w)
        {
            //Flip the box inside of a larger box (w)
            box2 ret = new box2();
            ret.Min.x = w - b.Max.x;
            ret.Max.x = w - b.Min.x;

            ret.Min.y = b.Min.y;
            ret.Max.y = b.Max.y;
            return ret;
        }
        public static box2 FlipBoxV(box2 b, float h)
        {
            //Flip the box inside of a larger box (h)
            box2 ret = new box2();
            ret.Min.y = h - b.Max.y;
            ret.Max.y = h - b.Min.y;

            ret.Min.x = b.Min.x;
            ret.Max.x = b.Max.x;
            return ret;
        }
        //public Rectangle ToXNARect()
        //{
        //    Rectangle r = new Rectangle();

        //    r.X = (int)(Min.x);
        //    r.Y = (int)(Min.y);
        //    r.Width = (int)(Max.x - Min.x);
        //    r.Height = (int)(Max.y - Min.y);

        //    return r;
        //}

        public static box2 GetIntersectionBox_Inclusive(box2 a, box2 b)
        {
            box2 ret = new box2();

            ret.Min.x = Single.MaxValue;
            ret.Min.y = Single.MaxValue;
            ret.Max.x = -Single.MaxValue;
            ret.Max.y = -Single.MaxValue;


            if (a.Min.x >= b.Min.x && a.Min.x <= b.Max.x)
            {
                ret.Min.x = Math.Min(ret.Min.x, a.Min.x);
            }
            if (a.Max.x <= b.Max.x && a.Max.x >= b.Min.x)
            {
                ret.Max.x = Math.Max(ret.Max.x, a.Max.x);
            }
            if (a.Min.y >= b.Min.y && a.Min.y <= b.Max.y)
            {
                ret.Min.y = Math.Min(ret.Min.y, a.Min.y);
            }
            if (a.Max.y <= b.Max.y && a.Max.y >= b.Min.y)
            {
                ret.Max.y = Math.Max(ret.Max.y, a.Max.y);
            }

            if (b.Min.x >= a.Min.x && b.Min.x <= a.Max.x)
            {
                ret.Min.x = Math.Min(ret.Min.x, b.Min.x);
            }
            if (b.Max.x <= a.Max.x && b.Max.x >= a.Min.x)
            {
                ret.Max.x = Math.Max(ret.Max.x, b.Max.x);
            }
            if (b.Min.y >= a.Min.y && b.Min.y <= a.Max.y)
            {
                ret.Min.y = Math.Min(ret.Min.y, b.Min.y);
            }
            if (b.Max.y <= a.Max.y && b.Max.y >= a.Min.y)
            {
                ret.Max.y = Math.Max(ret.Max.y, b.Max.y);
            }
            return ret;
        }

        public void GenResetExtents()
        {
            Min = new vec2(Single.MaxValue, Single.MaxValue);
            Max = new vec2(-Single.MaxValue, -Single.MaxValue);
        }
        public void ExpandByPoint(vec2 v)
        {
            Min = vec2.Minv(Min, v);
            Max = vec2.Maxv(Max, v);
        }
        public bool BoxIntersect_EasyOut_Inclusive(box2 cc)
        {
            return cc.Min.x <= Max.x && cc.Min.y <= Max.y && Min.x <= cc.Max.x && Min.y <= cc.Max.y;
        }
        public bool ContainsPointInclusive(vec2 point)
        {
            if (point.x < Min.x)
                return false;
            if (point.y < Min.y)
                return false;
            if (point.x > Max.x)
                return false;
            if (point.y > Max.y)
                return false;
            return true;
        }
        private vec2 bounds(int x)
        {
            if (x == 0) return Min;
            return Max;
        }
        public bool RayIntersect(ProjectedRay ray, ref RaycastHit bh)
        {
            if (ray.IsOpt == false)
            {
                //Error.
                System.Diagnostics.Debugger.Break();
            }

            float txmin, txmax, tymin, tymax;
            bool bHit;

            txmin = (bounds(ray.Sign[0]).x - ray.Origin.x) * ray.InvDir.x;
            txmax = (bounds(1 - ray.Sign[0]).x - ray.Origin.x) * ray.InvDir.x;

            tymin = (bounds(ray.Sign[1]).y - ray.Origin.y) * ray.InvDir.y;
            tymax = (bounds(1 - ray.Sign[1]).y - ray.Origin.y) * ray.InvDir.y;

            if ((txmin > tymax) || (tymin > txmax))
            {
                // if (bh != null)
                // {
                bh._bHit = false;
                // }
                return false;
            }
            if (tymin > txmin)
            {
                txmin = tymin;
            }
            if (tymax < txmax)
            {
                txmax = tymax;
            }

            bHit = ((txmin >= 0.0f) && (txmax <= ray.Length));

            //**Note changed 20151105 - this is not [0,1] this is the lenth along the line in which 
            // the ray enters and exits the cube, so any value less than the maximum is valid

            // if (bh != null)
            // {
            bh._bHit = bHit;
            bh._t = txmin;
            // }

            return bHit;
        }
    }

    public class box3
    {
        public vec3 _vmin;
        public vec3 _vmax;

        public box3()
        {
        }
        public box3(vec3 min, vec3 max)
        {
            _vmin = min;
            _vmax = max;
        }

        public void GenResetExtents()
        {
            _vmin = new vec3(Single.MaxValue, Single.MaxValue, Single.MaxValue);
            _vmax = new vec3(-Single.MaxValue, -Single.MaxValue, -Single.MaxValue);
        }
        public void ExpandByPoint(vec3 v)
        {
            _vmin = vec3.Minv(_vmin, v);
            _vmax = vec3.Maxv(_vmax, v);
        }

        public void Validate()
        {
            if (_vmax.x < _vmin.x)
                throw new Exception("Bound box X was invalid.");
            if (_vmax.y < _vmin.y)
                throw new Exception("Bound box Y was invalid.");
            if (_vmax.z < _vmin.z)
                throw new Exception("Bound box Z was invalid.");
        }
        /**
        *	@fn RayIntersect
        *	@brief Returns true if the given ray intersects this Axis aligned
        *	cube volume.
        *	@param bh - Reference to a BoxHit structure.
        *	@prarm ray - The ray to test against the box.
        *	@return true if ray intersects, false otherwise.
        */
        public bool LineOrRayIntersectInclusive_EasyOut(PickRay ray, ref BoxAAHit bh)
        {
            if (RayIntersect(ray, ref bh))
                return true;
            // - otherwise check for points contained.
            if (containsInclusive(ray.Origin))
            {
                bh._p1Contained = true;
                bh._bHit = true;
                return true;
            }

            if (containsInclusive(ray.Origin + ray.Dir))
            {
                bh._p2Contained = true;
                bh._bHit = true;
                return true;
            }

            return false;
        }
        private vec3 bounds(int in__)
        {
            if (in__ == 0)
                return _vmin;
            return _vmax;
        }
        private bool RayIntersect(PickRay ray, ref BoxAAHit bh)
        {
            if (!ray._isOpt)
                throw new Exception("Projected ray was not optimized");

            float txmin, txmax, tymin, tymax, tzmin, tzmax;

            txmin = (bounds(ray.Sign[0]).x - ray.Origin.x) * ray.InvDir.x;
            txmax = (bounds(1 - ray.Sign[0]).x - ray.Origin.x) * ray.InvDir.x;

            tymin = (bounds(ray.Sign[1]).y - ray.Origin.y) * ray.InvDir.y;
            tymax = (bounds(1 - ray.Sign[1]).y - ray.Origin.y) * ray.InvDir.y;

            if ((txmin > tymax) || (tymin > txmax))
            {
                bh._bHit = false;
                return false;
            }
            if (tymin > txmin)
                txmin = tymin;
            if (tymax < txmax)
                txmax = tymax;

            tzmin = (bounds(ray.Sign[2]).z - ray.Origin.z) * ray.InvDir.z;
            tzmax = (bounds(1 - ray.Sign[2]).z - ray.Origin.z) * ray.InvDir.z;

            if ((txmin > tzmax) || (tzmin > txmax))
            {
                bh._bHit = false;
                return false;
            }
            if (tzmin > txmin)
                txmin = tzmin;
            if (tzmax < txmax)
                txmax = tzmax;

            bh._bHit = ((txmin > 0.0f) && (txmax <= ray._length));
            bh._t = txmin;

            return bh._bHit;
        }

        private bool containsInclusive(vec3 v)
        {
            return (
                (v.z >= _vmin.z) && (v.z <= _vmax.z) &&
                (v.y >= _vmin.y) && (v.y <= _vmax.y) &&
                (v.z >= _vmin.z) && (v.z <= _vmax.z)
                );
        }

    }

    public class BoxAAHit
    {
        public bool _bHit;  // Whether the ray intersected the box.
        public bool _p1Contained;
        public bool _p2Contained;
        public float _t; // - Time to hit [0,1]
    };

    public class PickRay
    {
        public vec3 Origin;
        public vec3 Dir;
        public float _length;
        public bool _isOpt;
        public vec3 InvDir;
        public int[] Sign = new int[3];

        public void Opt()
        {
            //**New - optimization
            //http://people.csail.mit.edu/amy/papers/box-jgt.pdf
            // if (Dir.X != 0.0f)
            InvDir.x = 1.0f / Dir.x;
            //   else
            //       InvDir.X = 0.0f;
            //   if (Dir.Y != 0.0f)
            InvDir.y = 1.0f / Dir.y;
            //      else
            //         InvDir.Y = 0.0f;
            //     if (Dir.Z != 0.0f)
            InvDir.z = 1.0f / Dir.z;
            //     else
            //         InvDir.Z = 0.0f;

            Sign[0] = Convert.ToInt32(InvDir.x < 0);
            Sign[1] = Convert.ToInt32(InvDir.y < 0);
            Sign[2] = Convert.ToInt32(InvDir.z < 0);

            _isOpt = true;
        }
    }

}
