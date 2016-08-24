using Common.Lib;
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
    public class ImagemMascaraNegra
    {

        #region Singleton
        private static ImagemMascaraNegra objImagemMascaraNegra;

        public static ImagemMascaraNegra obterInstancia()
        {
            if (ImagemMascaraNegra.objImagemMascaraNegra == null)
            {
                ImagemMascaraNegra.objImagemMascaraNegra = new ImagemMascaraNegra();
            }
            return ImagemMascaraNegra.objImagemMascaraNegra;
        }
        #endregion

        public Bitmap aplicarMascaraNegraImagemIndexada(Bitmap objImagemOriginal, int valorTransparencia)
        {
            Bitmap newImage = new Bitmap(objImagemOriginal.Width, objImagemOriginal.Height, PixelFormat.Format32bppArgb);
            newImage.SetResolution(objImagemOriginal.HorizontalResolution, objImagemOriginal.VerticalResolution);
            Graphics objGraphics = Graphics.FromImage(newImage);
            objGraphics.DrawImageUnscaled(objImagemOriginal, 0, 0);
            Brush brush = new SolidBrush(Color.FromArgb(valorTransparencia, Color.Black));
            objGraphics.FillRectangle(brush, new Rectangle(0, 0, objImagemOriginal.Width, objImagemOriginal.Height));
            brush.Dispose();
            objGraphics.Dispose();
            return newImage;
        }

        public Bitmap aplicarMascaraNegraImagem(Bitmap objImagemOriginal, int valorTransparencia)
        {
            objImagemOriginal.SetResolution(objImagemOriginal.HorizontalResolution,
                                   objImagemOriginal.VerticalResolution);
            Graphics objGraphics = Graphics.FromImage(objImagemOriginal);
            objGraphics.DrawImageUnscaled(objImagemOriginal, 0, 0);
            Brush brush = new SolidBrush(Color.FromArgb(valorTransparencia, Color.Black));
            objGraphics.FillRectangle(brush, new Rectangle(0, 0, objImagemOriginal.Width, objImagemOriginal.Height));
            brush.Dispose();
            objGraphics.Dispose();
            return objImagemOriginal;
        }

        public Bitmap aplicarMascaraNegraImagem(Bitmap objImagemOriginal)
        {
            ImagemTransparencia.obterInstancia().definirValorTransparenciaPorHorario();
            int valorTransparencia = ImagemTransparencia.obterInstancia().valorTransparencia;
            return aplicarMascaraNegraImagem(objImagemOriginal, valorTransparencia);
        }
    }
}
