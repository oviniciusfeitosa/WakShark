using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/// VFBitmapLocker - Means Vinícius Feitosa Bitmap Locker.
/// <summary>
///  This Class helps to easily get pixels from horizontal and vertical axis, using a faster way to do that.
/// </summary>
/// since: 01:51 02/08/2016

namespace Common.Lib
{
    public class VFBitmapLocker : IDisposable
    {

        public BitmapData objBitmapData { get; set; }
        public Bitmap objBitmap { get; set; }
        public int bytesPerPixel { get; set; }
        public int byteCount { get; set; }
        private byte[] pixels { get; set; }
        public int heightInPixels { get; set; }
        public int widthInBytes { get; set; }
        public int Stride { get; set; }
        public int height { get; set; }
        public int width { get; set; }

        public VFBitmapLocker(Bitmap objBitmap)
        {
            this.objBitmap = objBitmap;
            this.objBitmapData = this.objBitmap.LockBits(new Rectangle(0, 0, this.objBitmap.Width, this.objBitmap.Height), ImageLockMode.ReadWrite, this.objBitmap.PixelFormat);
            this.bytesPerPixel = Bitmap.GetPixelFormatSize(this.objBitmap.PixelFormat) / 8;
            this.Stride = objBitmapData.Stride;
            this.byteCount = this.Stride * this.objBitmap.Height;
            this.pixels = new byte[byteCount];
            this.height = objBitmapData.Height;
            this.width = objBitmapData.Width;
            this.heightInPixels = this.height;
            this.widthInBytes = this.width * bytesPerPixel;
            IntPtr ptrFirstPixel = objBitmapData.Scan0;
            Marshal.Copy(ptrFirstPixel, this.pixels, 0, this.pixels.Length);
            
        }

        public Color getPixel(int horizontalAxis, int verticalAxis)
        {
            try
            {
                if(pixels.Length > (verticalAxis * this.Stride) + horizontalAxis + 2)
                {
                    int red = pixels[(verticalAxis * this.Stride) + horizontalAxis + 2];
                    int green = pixels[(verticalAxis * this.Stride) + horizontalAxis + 1];
                    int blue = pixels[(verticalAxis * this.Stride) + horizontalAxis];

                    return Color.FromArgb(red, green, blue);
                }
                return Color.Black;
            }
            catch (Exception objException)
            {
                throw new Exception(objException.ToString());
            }
        }

        public void Dispose()
        {
            this.objBitmap.UnlockBits(objBitmapData);
            GC.SuppressFinalize(this);
        }
    }
}