using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Newtonsoft.Json;

namespace Monoedit
{
    public enum ImageType
    {
        Atlas,
        Image
    }
    /// <summary>
    /// an image, texture, or sprite atlas
    /// </summary>
    public class ImageResource : ResourceBase
    {
        [JsonProperty]
        public string Path { get; set; }
        [JsonProperty]
        public ImageType ImageType { get; set; }
        [JsonProperty]
        public Int32 TileCountX { get; set; }
        [JsonProperty]
        public Int32 TileCountY { get; set; }
        [JsonProperty]
        public Int32 TileWidth { get; set; }
        [JsonProperty]
        public Int32 TileHeight { get; set; }
        [JsonProperty]
        public Int32 PaddingX { get; set; }
        [JsonProperty]
        public Int32 PaddingY { get; set; }
        [JsonProperty]
        public Int32 SpacingX { get; set; }
        [JsonProperty]
        public Int32 SpacingY { get; set; }

        //Not Serialized
        [JsonIgnore]
        public Bitmap Bitmap { get; set; } = null;

        public ImageResource() { }
        public ImageResource(Int64 id) : base(id) { }

        public override void Refresh()
        {
            LoadIfNecessary(true);
        }
        public void LoadIfNecessary(bool force)
        {
            if (Bitmap == null || force)
            {
                if (Bitmap != null)
                {
                    Bitmap = null;
                    GC.Collect();
                }
                string dir = Globals.ResolvePath(Path);
                if (File.Exists(dir))
                {
                    Bitmap = new Bitmap(dir);
                }
                else
                {
                    Bitmap = Globals.GetDefaultXImage();
                }
            }
        }

        public bool hasValues()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Path))
            {
                return false;
            }
            return true;
        }

        //public override void Serialize(BinaryWriter w, string version)
        //{
        //    base.Serialize(w, version);
        //    BinUtils.WriteString(Path, w);
        //    BinUtils.WriteInt16(TileCountX, w);
        //    BinUtils.WriteInt16(TileCountY, w);
        //    BinUtils.WriteInt16(TileWidth, w);
        //    BinUtils.WriteInt16(TileHeight, w);
        //    BinUtils.WriteInt16(PaddingX, w);
        //    BinUtils.WriteInt16(PaddingY, w);
        //    BinUtils.WriteInt16(SpacingX, w);
        //    BinUtils.WriteInt16(SpacingY, w);
        //}

        //public override void Deserialize(BinaryReader r, string version)
        //{
        //    base.Deserialize(r, version);
        //    Path = BinUtils.ReadString(r);
        //    TileCountX = BinUtils.ReadInt16(r);
        //    TileCountY = BinUtils.ReadInt16(r);
        //    TileWidth = BinUtils.ReadInt16(r);
        //    TileHeight = BinUtils.ReadInt16(r);
        //    PaddingX = BinUtils.ReadInt16(r);
        //    PaddingY = BinUtils.ReadInt16(r);
        //    SpacingX = BinUtils.ReadInt16(r);
        //    SpacingY = BinUtils.ReadInt16(r);
        //}

        //Adding the image map utils.
        public Bitmap GetImageForFrame(Frame f)
        {
            if (f == null)
            {
                Globals.LogError("Given Frame was null");
                return Globals.GetDefaultXImage();
            }
            return GetSubImageForRect(GetRectForFrame(f), f.ImageResourceId);
        }

        private Rectangle GetRectForFrame(Frame f)
        {
            return new Rectangle(f.x, f.y, f.w, f.h);
        }

        private Bitmap GetSubImageForRect(Rectangle r, int texid)
        {
            LoadIfNecessary(false);
            
            //Globals.GetDefaultXImage();

            Rectangle destRegion = new Rectangle(0, 0, r.Width, r.Height);
            Bitmap destBitmap = new Bitmap(r.Width, r.Height);
            Globals.CopyRegionIntoImage(Bitmap, r, ref destBitmap, destRegion);
            return destBitmap;
        }

        //public Bitmap GetDefaultXImage()
        //{
        //    return Globals.GetDefaultXImage();
        //    //if (this.DefaultImage == null)
        //    //{
        //    //    string str = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "no.png");
        //    //    if (File.Exists(str))
        //    //    {
        //    //        this.DefaultImage = new Bitmap(str);
        //    //    }
        //    //    else
        //    //    {
        //    //        Bitmap bitmap = new Bitmap(64, 64, PixelFormat.Format24bppRgb);
        //    //    }
        //    //}
        //    //return this.DefaultImage;
        //}




    }
}
