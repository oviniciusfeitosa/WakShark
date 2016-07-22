using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public class TelaCaptura
    {
        #region Singleton
        private static TelaCaptura objTelaCaptura;

        public static TelaCaptura obterInstancia()
        {
            if (TelaCaptura.objTelaCaptura == null)
            {
                TelaCaptura.objTelaCaptura = new TelaCaptura();
            }
            return TelaCaptura.objTelaCaptura;
        }
        #endregion

        public Bitmap objBitmap;
        public Service.Lib.LockBitmap objLockedBitmap;
        public int valorTransparencia = 0;

        public void capturarTela(String filePath)
        {
            try
            {
                using (TelaCaptura.obterInstancia().objBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
                {
                    var gfxScreenshot = Graphics.FromImage(TelaCaptura.obterInstancia().objBitmap);

                    // Tira uma printScreen do canto superior esquerdo até o canto inferior direito.
                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                Screen.PrimaryScreen.Bounds.Y,
                                                0,
                                                0,
                                                Screen.PrimaryScreen.Bounds.Size,
                                                CopyPixelOperation.SourceCopy);

                    if (TelaCaptura.obterInstancia().objBitmap == null)
                    {
                        throw new Exception();
                    }
                    TelaCaptura.obterInstancia().objBitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.ToString());
            }
        }

        public Bitmap obterImagemTelaComo8bitesPorPixel()
        {
            Size bounds = SystemInformation.PrimaryMonitorSize;
            //Rectangle bounds = SystemInformation.VirtualScreen;
            //Rectangle bounds = Screen.PrimaryScreen.Bounds;

            using (Bitmap objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format64bppArgb))
            {
                using (Graphics g = Graphics.FromImage(objBitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                }

                /* // Mover para um lugar mais correto
                if (this.valorTransparencia > 0)
                {
                    using (Bitmap objBitmapMascarado = this.aplicarMascaraNegraImagem(objBitmap, this.valorTransparencia)) {
                        return objBitmapMascarado.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
                        //return objBitmapMascarado.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format16bppArgb1555);
                    }
                } */
                return objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
                //return objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format16bppArgb1555);
            }
        }

        public Bitmap converterImagemPara8bitesPorPixel(Bitmap objBitmap)
        {
            return objBitmap.Clone(new Rectangle(0, 0, objBitmap.Width, objBitmap.Height), PixelFormat.Format8bppIndexed);
        }

        public Bitmap obterImagemTela()
        {
            Size bounds = SystemInformation.PrimaryMonitorSize;

            using (Bitmap objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(objBitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                }

                // Mover para um lugar mais correto
                if (this.valorTransparencia > 0)
                {
                    using (Bitmap objBitmapMascarado = this.aplicarMascaraNegraImagem(objBitmap, this.valorTransparencia))
                    {
                        return objBitmapMascarado.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
                    }
                }
                return objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
            }
        }

        public int obterValorTransparenciaPorHorario()
        {
            // "Romance Standard Time" (GMT+01:00) Brussels, Copenhagen, Madrid, Paris
            DateTime horarioaAtual = DateTime.Now;
            TimeZoneInfo tempoDeZonaFranca = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            DateTime horarioConvertido = TimeZoneInfo.ConvertTime(horarioaAtual, TimeZoneInfo.Local, tempoDeZonaFranca);
            
            int horaAtual = Int32.Parse(horarioConvertido.ToString("HH"));
            int valorMaximoTransparencia = 160;

            int[] variacoesTransparenciaPorHorario = new int[24];
            for (int hora = 0; hora < 24; hora++)
            {
                if (hora >= 12 ) variacoesTransparenciaPorHorario[ hora ] = (valorMaximoTransparencia / 12) * ( hora - 12 );
                else variacoesTransparenciaPorHorario[ hora ] = (valorMaximoTransparencia / 12) * (hora);
            };

            return variacoesTransparenciaPorHorario[horaAtual];
        }

        public Bitmap aplicarMascaraNegraImagemIndexada(Bitmap objImagemOriginal, int valorTransparencia)
        {
            Bitmap newImage = new Bitmap(objImagemOriginal.Width, objImagemOriginal.Height,
                                PixelFormat.Format32bppArgb);
            newImage.SetResolution(objImagemOriginal.HorizontalResolution,
                                   objImagemOriginal.VerticalResolution);
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

    }
}
