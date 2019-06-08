using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
namespace OpenGS
{
    public enum TextureLoadResult
    {
        Success,
        TooLarge,
        InvalidPath,
        InvalidExtension
    }

    public class Texture2D 
    {
        public int GlTexId { get; private set; } = 0;
        public float Width { get; private set; } = 0;
        public float Height { get; private set; } = 0;

        public System.Drawing.Imaging.PixelFormat WindowsPixelFormat
        {
            get
            {
                return System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            }
            private set
            {
            }
        }
        public OpenTK.Graphics.OpenGL.PixelFormat GlPixelFormat
        {
            get
            {
                return OpenTK.Graphics.OpenGL.PixelFormat.Bgra;
            }
            private set
            {
            }
        }

        public Texture2D(Bitmap bmp)
        {
            Create(bmp);
        }
        private int GetNumMipmaps(int w, int h)
        {
            int numMipMaps = 0;
            int x = System.Math.Max(w, h);
            for (; x > 0; x = x >> 1)
                numMipMaps++;
            return numMipMaps;
        }
        public void Create(Bitmap bmp)
        {
            Width = bmp.Width;
            Height = bmp.Height;

            int ts = Gpu.GetMaxTextureSize();
            if (Width >= ts)
            {
                throw new System.Exception(string.Format("Texture Width {0} larger than max supported texture size {1}.",Width, ts));
            }
            if (Height >= ts)
            {
                throw new System.Exception(string.Format("Texture Height {0} larger than max supported texture size {1}.", Height, ts));
            }

            GlTexId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, GlTexId);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            BitmapData bmp_data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                WindowsPixelFormat);//Note:if you change this make sure to change save image.

            int numMipmaps = GetNumMipmaps((int)Width, (int)Height);

            GL.TexStorage2D(TextureTarget2d.Texture2D, numMipmaps, SizedInternalFormat.Rgba8, (int)Width, (int)Height);

            GL.TexSubImage2D(TextureTarget.Texture2D,
                0, //mipmap level
                0, 0, //x.y
                bmp_data.Width,
                bmp_data.Height,
                GlPixelFormat,
                PixelType.UnsignedByte,
                bmp_data.Scan0);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            bmp.UnlockBits(bmp_data);

            Globals.CheckGpuErrorsRt();
        }
        public void Bind()
        {
            if (GlTexId == 0)
            {
                throw new System.Exception("Texture ID was 0 when binding texture.");
            }

            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, GlTexId);
        }
        public void Unbind()
        {
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
        public void Dispose()
        {
            if (GL.IsTexture(GlTexId))
            {
                GL.DeleteTexture(GlTexId);
            }
        }


    }
}
