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
        public string Path { get; set; } = "";
        [JsonProperty]
        public ImageType ImageType { get; set; } = ImageType.Image;
        [JsonProperty]
        public Int32 TileCountX { get; set; } = 16;
        [JsonProperty]
        public Int32 TileCountY { get; set; } = 16;
        [JsonProperty]
        public Int32 TileWidth { get; set; } = 16;
        [JsonProperty]
        public Int32 TileHeight { get; set; } = 16;
        [JsonProperty]
        public Int32 PaddingX { get; set; } = 1;
        [JsonProperty]
        public Int32 PaddingY { get; set; } = 1;
        [JsonProperty]
        public Int32 SpacingX { get; set; } = 1;
        [JsonProperty]
        public Int32 SpacingY { get; set; } = 1;

        //Not Serialized
        [JsonIgnore]
        private Bitmap _objBitmap = null;
        [JsonIgnore]
        public Bitmap Bitmap
        {
            get
            {
                LoadIfNecessary(false);
                return _objBitmap;
            }
            set
            {
                _objBitmap = value;
            }
        }

        public ImageResource() { }
        public ImageResource(Int64 id) : base(id) { }

        public override void Refresh()
        {
            LoadIfNecessary(true);
        }
        public void LoadIfNecessary(bool force)
        {
            if (_objBitmap == null || force)
            {
                if (_objBitmap != null)
                {
                    _objBitmap = null;
                    GC.Collect();
                }
                string dir = Globals.ResolvePath(Path);
                if (File.Exists(dir))
                {
                    _objBitmap = new Bitmap(dir);
                }
                else
                {
                    _objBitmap = Globals.GetDefaultXImage();
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


    }
}
