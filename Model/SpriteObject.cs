using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monoedit
{
    /// <summary>
    /// Holds key frame data for a sprite at a specific keyframe.
    /// </summary>
    public class KeyFrame : IdItemBase
    {
        [JsonIgnore]
        public SpriteObjectAnimation ParentAnimation = null;//MUST SET

        //The image Frame at (t)
        [JsonProperty]
        public Frame Frame { get; set; }

        [JsonProperty]
        public vec2 Position { get; set; }
        [JsonProperty]
        public vec2 Rotation { get; set; }
        [JsonProperty]
        public vec2 Scale { get; set; }

        // Whether the component is visible
        [JsonProperty]
        public bool Visible { get; set; }


    }
    /// <summary>
    /// Animation for a sprite object.
    /// Has a name, and list of keyframes.
    /// </summary>
    public class SpriteObjectAnimation : ResourceBase
    {
        [JsonIgnore]
        public SpriteObject ParentSprite = null;//MUST SET

        [JsonProperty]
        public List<KeyFrame> _lstKeyFrames = new List<KeyFrame>();
        [JsonProperty]
        public int PreviewKeyFrameId { get; set; } = 0;

        [JsonIgnore]
        public List<KeyFrame> KeyFrames
        {
            get { return _lstKeyFrames; }
            set { _lstKeyFrames = value; }
        }


        public SpriteObjectAnimation() { }
        public SpriteObjectAnimation(Int64 id) : base(id) { }
        public override void Refresh()
        {
            throw new NotImplementedException();
        }
        public Bitmap RenderKeyFrame(int frameId)
        {
            KeyFrame f  = KeyFrames.Where(x => x.Id == frameId).FirstOrDefault();
            return RenderKeyFrame(f);
        }
        public Bitmap RenderKeyFrame(KeyFrame f)
        {
            Bitmap ret = null;
            if (f == null)
            {
                return null;
            }

            //ooh.. ok


            return ret;
        }

    }
    public class TimeLine
    {
        //[JsonProperty]
        //private Dictionary<int, KeyFrame> _objKeyFrames;
        //[JsonIgnore]
        //public Dictionary<int, KeyFrame> KeyFrames { get { return _objKeyFrames; } set { _objKeyFrames = value; } }
    }
    /// <summary>
    /// Sprite objects are aggregates of sprite components and a timeline
    /// Sprite components are traditional sprites with frames.
    /// </summary>
    public class SpriteObject : ResourceBase
    {
        [JsonProperty]
        public vec2 Origin = new vec2(0, 0);
        [JsonProperty]
        private List<SpriteComponent> _lstComponents = new List<SpriteComponent>();
        [JsonProperty]
        private List<SpriteObjectAnimation> _lstAnimations = new List<SpriteObjectAnimation>();
        [JsonProperty]
        public Model3D Model { get; set; } = null;

        //Anim Id and Key Frame ID of the preview image to show for this sprite.
        [JsonProperty]
        public long PreviewAnimationId { get; set; } = -1;

        [JsonIgnore]
        public Bitmap Preview
        {
            get
            {
                Bitmap ret = null;
                if (_lstAnimations != null && _lstAnimations.Count > 0)
                {
                    if (PreviewAnimationId >= 0)
                    {
                        SpriteObjectAnimation found = _lstAnimations.Where(x => x.Id == PreviewAnimationId).FirstOrDefault();
                        if (found != null)
                        {
                            ret = found.RenderKeyFrame(found.PreviewKeyFrameId);
                        }
                    }
                }

                if (ret == null)
                {
                    ret = Globals.GetDefaultXImage();
                }

                return ret;
            }
        }
        [JsonIgnore]
        public List<SpriteComponent> Components { get { return _lstComponents; } set { _lstComponents = value; } }
        [JsonIgnore]
        public List<SpriteObjectAnimation> Animations { get { return _lstAnimations; } set { _lstAnimations = value; } }

        public SpriteObject() { }
        public SpriteObject(Int64 id) : base(id) { }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }
    }

    public class SpriteComponent : ResourceBase
    {
        [JsonProperty]
        public bool Loop { get; set; } = true;
        [JsonProperty]
        public List<KeyFrame> Frames { get; set; } = new List<KeyFrame>();
        [JsonProperty]
        public string FileLocation { get; set; } = "";
        [JsonProperty]
        public float Origin_X { get; set; } = 0.0f;
        [JsonProperty]
        public float Origin_Y { get; set; } = 0.0f;

        public SpriteComponent() { }
        public SpriteComponent(Int64 id) : base(id) { }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        //public void SortFrames()
        //{
        //    Frames.Sort((Comparison<Frame>)((x, y) => x.Id.CompareTo(y.Id)));
        //}

        //public override void Serialize(BinaryWriter stream, string version)
        //{
        //    //BinUtils.WriteInt32(Direction, stream);
        //    base.Serialize(stream, version);
        //    BinUtils.WriteBool(Loop, stream);
        //    BinUtils.WriteString(FileLocation, stream);
        //    BinUtils.WriteFloat(Origin_X, stream);
        //    BinUtils.WriteFloat(Origin_Y, stream);
        //    BinUtils.WriteInt32(Frames.Count, stream);
        //    foreach (Frame frame in Frames)
        //    {
        //        frame.Serialize(stream, version);
        //    }
        //}

        //public override void Deserialize(BinaryReader stream, string version)
        //{
        //    //  Direction = BinUtils.ReadInt32(stream);
        //    base.Deserialize(stream, version);
        //    Loop = BinUtils.ReadBool(stream);
        //    FileLocation = BinUtils.ReadString(stream);
        //    Origin_X = BinUtils.ReadFloat(stream);
        //    Origin_Y = BinUtils.ReadFloat(stream);
        //    int num = BinUtils.ReadInt32(stream);
        //    for (int index = 0; index < num; ++index)
        //    {
        //        Frame frame = new Frame(-1);
        //        frame.Deserialize(stream, version);
        //        frame.Sprite = this;
        //        Frames.Add(frame);
        //    }
        //}
    }
}
