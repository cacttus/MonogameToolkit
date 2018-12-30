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
        public Int16 TileCountX { get; set; }
        [JsonProperty]
        public Int16 TileCountY { get; set; }
        [JsonProperty]
        public Int16 TileWidth { get; set; }
        [JsonProperty]
        public Int16 TileHeight { get; set; }
        [JsonProperty]
        public Int16 PaddingX { get; set; }
        [JsonProperty]
        public Int16 PaddingY { get; set; }
        [JsonProperty]
        public Int16 SpacingX { get; set; }
        [JsonProperty]
        public Int16 SpacingY { get; set; }

        //Not Serialized
        [JsonIgnore]
        public Bitmap BitmapImage { get; set; } = null;

        public ImageResource() { }
        public ImageResource(Int64 id) : base(id) { }

        public override void Refresh()
        {
            LoadIfNecessary(true);
        }
        public void LoadIfNecessary(bool force)
        {
            if (BitmapImage == null || force)
            {
                if (BitmapImage != null)
                {
                    BitmapImage = null;
                    GC.Collect();
                }
                if (File.Exists(Path))
                {
                    string dir = System.IO.Path.GetFullPath(Path);
                    BitmapImage = new Bitmap(dir);
                }
                else
                {
                    BitmapImage = Globals.GetDefaultXImage();
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

        public override void Serialize(BinaryWriter w, string version)
        {
            base.Serialize(w, version);
            BinUtils.WriteString(Path, w);
            BinUtils.WriteInt16(TileCountX, w);
            BinUtils.WriteInt16(TileCountY, w);
            BinUtils.WriteInt16(TileWidth, w);
            BinUtils.WriteInt16(TileHeight, w);
            BinUtils.WriteInt16(PaddingX, w);
            BinUtils.WriteInt16(PaddingY, w);
            BinUtils.WriteInt16(SpacingX, w);
            BinUtils.WriteInt16(SpacingY, w);
        }

        public override void Deserialize(BinaryReader r, string version)
        {
            base.Deserialize(r, version);
            Path = BinUtils.ReadString(r);
            TileCountX = BinUtils.ReadInt16(r);
            TileCountY = BinUtils.ReadInt16(r);
            TileWidth = BinUtils.ReadInt16(r);
            TileHeight = BinUtils.ReadInt16(r);
            PaddingX = BinUtils.ReadInt16(r);
            PaddingY = BinUtils.ReadInt16(r);
            SpacingX = BinUtils.ReadInt16(r);
            SpacingY = BinUtils.ReadInt16(r);
        }

        //Adding the image map utils.
        public Bitmap GetImageForFrame(Frame f)
        {
            if (f == null)
            {
                Globals.MainForm.LogError("Given Frame was null");
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
            Globals.CopyRegionIntoImage(BitmapImage, r, ref destBitmap, destRegion);
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
