using Common.Lib;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Lib.Win32;

namespace Common
{
    public class ImagemTransformacao
    {
        #region Singleton
        private static ImagemTransformacao objImagemTransformacao;

        public static ImagemTransformacao obterInstancia()
        {
            if (ImagemTransformacao.objImagemTransformacao == null)
            {
                ImagemTransformacao.objImagemTransformacao = new ImagemTransformacao();
            }
            return ImagemTransformacao.objImagemTransformacao;
        }
        #endregion


        public Bitmap redimencionarImagem(Bitmap objImagem, int largura, int altura)
        {
            var destRect = new Rectangle(0, 0, largura, altura);
            var destImage = new Bitmap(largura, altura);

            destImage.SetResolution(objImagem.HorizontalResolution, objImagem.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(objImagem, destRect, 0, 0, objImagem.Width, objImagem.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public Bitmap rotacionarImagem(Bitmap objImagem, float rotationAngle)
        {
            Bitmap objBitmap = new Bitmap(objImagem.Width, objImagem.Height);

            Graphics objGraphics = Graphics.FromImage(objBitmap);
            objGraphics.Clear(Color.White);
            objGraphics.TranslateTransform((float)objBitmap.Width / 2, (float)objBitmap.Height / 2);
            objGraphics.RotateTransform(rotationAngle);
            objGraphics.TranslateTransform(-(float)objBitmap.Width / 2, -(float)objBitmap.Height / 2);
            objGraphics.DrawImage(objImagem, new Point(0, 0));
            objGraphics.Dispose();

            return objBitmap;
        }

        public Bitmap converterImagemPara8bitesPorPixel(Bitmap objBitmap)
        {
            return objBitmap.Clone(new Rectangle(0, 0, objBitmap.Width, objBitmap.Height), PixelFormat.Format8bppIndexed);
        }

        private Image<Emgu.CV.Structure.Gray, byte> converterImagemParaCinza(Bitmap objBitmapTemplate)
        {
            ImagemCaptura objImagemCaptura = ImagemCaptura.obterInstancia();

            if (objImagemCaptura.isUtilizarMascaraLuminosidade) objBitmapTemplate = ImagemMascaraNegra.obterInstancia().aplicarMascaraNegraImagem(objBitmapTemplate);

            objBitmapTemplate = this.converterImagemPara8bitesPorPixel(objBitmapTemplate);
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(objBitmapTemplate); // Image A
            //objImagemTemplate = objImagemTemplate.ThresholdBinary(new Gray(115), new Gray(255));
            objImagemTemplate = objImagemTemplate.ThresholdBinary(new Gray(145), new Gray(255));
            objImagemTemplate._Not();

            return objImagemTemplate;
        }
    }
}

