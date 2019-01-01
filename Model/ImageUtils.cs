using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing.Imaging;
namespace Monoedit
{
    public struct Pixel
    {
        public byte a;
        public byte r;
        public byte g;
        public byte b;
        public Pixel(byte xr, byte xg, byte xb, byte xa)
        {
            a = xa;
            r = xr;
            g = xg;
            b = xb;
        }
    }
    public class ImageManip
    {
        public Bitmap Bitmap { get; private set; } = null;
        public byte[] Data { get; set; } = null;
        public int Stride { get; private set; } = 0;
        public bool Locked { get; private set; } = false;

        public ImageManip(Bitmap bmp)
        {
            Bitmap = bmp;
        }
        public Pixel GetPixel(int x, int y)
        {
            if (Locked == false)
            {
                throw new Exception("Bitmap was not locked");
            }

            Pixel pix = new Pixel();
            int iOff = y * Bitmap.Width + x;

            if (Stride == 4)
            {
                pix.a = Data[iOff + 0];
                pix.r = Data[iOff + 1];
                pix.g = Data[iOff + 2];
                pix.b = Data[iOff + 3];
            }
            else if (Stride == 3)
            {
                pix.r = Data[iOff + 0];
                pix.g = Data[iOff + 1];
                pix.b = Data[iOff + 2];
            }

            return pix;
        }
        public void SetPixel(int x, int y, Pixel pix)
        {
            if (Locked == false)
            {
                throw new Exception("Bitmap was not locked");
            }

            int iOff = y * Bitmap.Width + x;

            if (Stride == 4)
            {
                Data[iOff + 0] = pix.a;
                Data[iOff + 1] = pix.r;
                Data[iOff + 2] = pix.g;
                Data[iOff + 3] = pix.b;
            }
            else if (Stride == 3)
            {
                Data[iOff + 0] = pix.r;
                Data[iOff + 1] = pix.g;
                Data[iOff + 2] = pix.b;
            }
        }

        public void PixelOp(Action<> op)
        {

        }
        public void BlackAndWhite()
        {
            ModifyPixelData((ImageManip) =>
            {

                for (int iPixel = 0; iPixel < Data.Length / struct; iPixel++)
                {
                    byte a = 0;
                    byte r = 0;
                    byte g = 0;
                    byte b = 0;

                    int pix = iPixel * stride;

                    double f = .299 * (double)r + .587 * (double)g + .114 * (double)b;
                    if (stride == 4)
                    {

                    }
                    else if (stride == 3)
                    {

                    }
                    dat[counter] = 255;
                }

            });

            //// Draw the modified image.
            //e.Graphics.DrawImage(bmp, 0, 150);
        }
        private void ModifyPixelData(Action<ImageManip> action)
        {
            // Lock the bitmap's bits. 
            BitmapData bmpData = null;
            try
            {
                Rectangle rect = new Rectangle(0, 0, Bitmap.Width, Bitmap.Height);
                bmpData = Bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, Bitmap.PixelFormat);
                {
                    Locked = true;
                    {
                        // Get the address of the first line.
                        IntPtr ptr = bmpData.Scan0;

                        // Declare an array to hold the bytes of the bitmap.
                        int numBytes = Math.Abs(bmpData.Stride) * Bitmap.Height;
                        Data = new byte[numBytes];

                        Stride = bmpData.Stride;

                        // Copy the RGB values into the array.
                        System.Runtime.InteropServices.Marshal.Copy(ptr, Data, 0, numBytes);

                        //Run action
                        action(this);

                        // Copy the RGB values back to the bitmap
                        System.Runtime.InteropServices.Marshal.Copy(Data, 0, ptr, numBytes);
                    }
                    Locked = false;
                }
                // Unlock the bits.
                Bitmap.UnlockBits(bmpData);
            }
            catch (Exception ex)
            {
                Globals.LogError(ex.ToString(),true);
                Locked = false;
                if (bmpData != null)
                {
                    try
                    {
                        Bitmap.UnlockBits(bmpData);
                    }
                    catch (Exception ex2)
                    {
                        Globals.LogError(ex2.ToString());
                    }
                }

            }
        }
    }



}
