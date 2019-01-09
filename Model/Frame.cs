using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Monoedit
{
    /// <summary>
    /// A single sprite frame for frame-by-frame animation.
    /// Sprites have at least one frame, or multiple frames!
    /// </summary>
    public class Frame : ResourceBase
    {
        [JsonProperty]
        public int Delay = 41;
        [JsonProperty]
        public long ImageResourceId = -1;
        //   [JsonProperty]
        //  public string Location = "";

        //[JsonProperty]
        //public int FrameId = -1;
        [JsonProperty]
        public int x;
        [JsonProperty]
        public int y;
        [JsonProperty]
        public int w;
        [JsonProperty]
        public int h;

        ///[JsonIgnore]
        //public MtTex ImageTemp { get; set; } = null;
        [JsonIgnore]
        private ImageResource _objImageResource = null;
        [JsonIgnore]
        public ImageResource ImageResource
        {
            get { return _objImageResource; }
            set
            {
                _objImageResource = value;
                if (_objImageResource != null)
                {
                    ImageResourceId = _objImageResource.Id;
                }
            }
        }
        [JsonIgnore]
        public SpriteObject Sprite { get; set; } = (SpriteObject)null;

        public Frame() { }
        public Frame(Int64 id) : base(id) { }

        public Rectangle GetRect()
        {
            return new Rectangle(x, y, w, h);
        }
        public Bitmap GetImageForFrame()
        {
            Bitmap b = null;
            if (ImageResource == null)
            {
                Globals.LogError("Frame had no image resource");
            }
            else
            {
                b = ImageResource.GetImageForFrame(this);
            }
            return b;
        }
        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        //public override void Serialize(BinaryWriter stream, string version)
        //{
        //    BinUtils.WriteInt32(x, stream);
        //    BinUtils.WriteInt32(y, stream);
        //    BinUtils.WriteInt32(w, stream);
        //    BinUtils.WriteInt32(h, stream);
        //    BinUtils.WriteInt32(ImageResourceId, stream);
        //    BinUtils.WriteInt32(Delay, stream);
        //    BinUtils.WriteString(Location, stream);
        //    BinUtils.WriteString(Name, stream);
        //    BinUtils.WriteInt32(FrameId, stream);
        //}

        //public override void Deserialize(BinaryReader stream, string version)
        //{
        //    Block block = new Block(stream);
        //    x = BinUtils.ReadInt32(stream);
        //    y = BinUtils.ReadInt32(stream);
        //    w = BinUtils.ReadInt32(stream);
        //    h = BinUtils.ReadInt32(stream);
        //    ImageResourceId = BinUtils.ReadInt32(stream);
        //    Delay = BinUtils.ReadInt32(stream);
        //    Location = BinUtils.ReadString(stream);
        //    Name = BinUtils.ReadString(stream);
        //    FrameId = BinUtils.ReadInt32(stream);
        //}

        //public Frame CreateCopy()
        //{
        //    Frame newFrame = new Frame(this._objProjectFile, this.Id)
        //    {
        //        Delay = Delay,
        //        x = x,
        //        y = y,
        //        w = w,
        //        h = h,
        //        texid = texid
        //    };
        //    newFrame.ImageTemp = ImageTemp.CreateCopy(newFrame);
        //    newFrame.Location = Location;
        //    newFrame.Name = Name;
        //    newFrame.Sprite = Sprite;
        //    newFrame.FrameId = FrameId;
        //    return newFrame;
        //}

        //public void LoadFrameImage(string file)
        //{
        //    Bitmap bmp;
        //    if (!File.Exists(file))
        //    {
        //        bmp = Globals.GetDefaultXImage();
        //    }
        //    else
        //    {
        //        bmp = new Bitmap(file);
        //    }
        //    ImageTemp = new MtTex(bmp, this);
        //}
    }
}
