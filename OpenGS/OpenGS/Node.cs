using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using vec2 = OpenTK.Vector2;
using vec3 = OpenTK.Vector3;

namespace OpenGS
{
    public abstract class Node : IDisposable
    {
        private static int _idGenerator = 0;

        public int Id { get; private set; }    // node id
        public vec3 Pos
        {
            get;
            set;
        }
        public vec3 Scale { get; set; } = new vec3(1, 1, 1);
        public vec4 Rotation { get; set; } = new vec4(0, 0, 1, 0);
        public box3 BoundBox { get; set; } = new box3();

        public Node()
        {
            Id = ++_idGenerator;
        }

        public abstract void Update();
        public abstract void Render();
        public abstract void UpdateBoundBox();
        //public abstract void Free();    // free alld ata; **Dispose handles this now*
        public abstract void Resize(Viewport vp);
        public abstract void Dispose();

        public bool HitTestRay(PickRay xy)
        {
            BoxAAHit baa = new BoxAAHit();

            bool b = BoundBox.LineOrRayIntersectInclusive_EasyOut(xy, ref baa);

            return b;
        }

    }
}
