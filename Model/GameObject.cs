using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Monoedit
{
    public class GameObject : ResourceBase
    {
        [JsonProperty]
        public Frame DisplayFrame;

        public GameObject() { }
        public GameObject(Int64 id) : base(id) { }

        public override void Refresh()
        {
        }
        public override void Serialize(BinaryWriter w, string version)
        {
            base.Serialize(w, version);
            DisplayFrame.Serialize(w, version);
        }
        public override void Deserialize(BinaryReader r, string version)
        {
            base.Deserialize(r, version);
            Name = BinUtils.ReadString(r);

            DisplayFrame = new Frame();
            DisplayFrame.Deserialize(r, version);
        }


    }
}
