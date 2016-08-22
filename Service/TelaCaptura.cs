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
        public Common.Lib.LockBitmap objLockedBitmap;
        public int valorTransparencia = 0;
        public bool isUtilizarMascaraLuminosidade = false;

        public enum EnumRegiaoTela
        {
            TELA_CHEIA,
            LADO_ESQUERDO,
            LADO_DIREITO
        }

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

        public Bitmap obterImagemTelaComo8bitesPorPixel()
        {
            return obterImagemTelaComo8bitesPorPixel(EnumRegiaoTela.TELA_CHEIA);
        }

        public Bitmap obterImagemTelaComo8bitesPorPixel(EnumRegiaoTela objEnumRegiaoTela)
        {
            Size bounds = SystemInformation.PrimaryMonitorSize;
            //Rectangle bounds = SystemInformation.VirtualScreen;
            //Rectangle bounds = Screen.PrimaryScreen.Bounds;

            using (Bitmap objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    Size objSize = objBitmap.Size;

                    // @todo: substitutir o objBitmap.size.width para a propriedade que recuperar a altura e largura da tela do wakfu
                    // Porque atualmente só é valido quando o jogo está em tela cheia.
                    switch (objEnumRegiaoTela)
                    {
                        case EnumRegiaoTela.LADO_ESQUERDO:
                            objGraphics.CopyFromScreen(0, 0, (int)(objBitmap.Width / 2.09), 0 , objSize);
                            break;
                        case EnumRegiaoTela.LADO_DIREITO:
                            objGraphics.CopyFromScreen((int)(objBitmap.Width / 2), 0, (int)(objBitmap.Width / 2), 0, objSize);
                            break;
                        case EnumRegiaoTela.TELA_CHEIA:
                        default:
                            objGraphics.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                            break;
                    }
                }

                return objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
            }
        }

        public Bitmap converterImagemPara8bitesPorPixel(Bitmap objBitmap)
        {
            return objBitmap.Clone(new Rectangle(0, 0, objBitmap.Width, objBitmap.Height), PixelFormat.Format8bppIndexed);
        }
        
        public Bitmap obterImagemApplicacao(string nomeProcesso)
        {
            var listProcessos = Process.GetProcessesByName(nomeProcesso)[0];

            IntPtr hwnd = listProcessos.MainWindowHandle;

            RECT rc;
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            //bmp.Save("C:\\Users\\Public\\a.bmp");

            return bmp;
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


        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

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
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap RotateImage(Bitmap img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        public Bitmap aplicarMascaraNegraImagem(Bitmap objImagemOriginal)
        {
            this.valorTransparencia = this.obterValorTransparenciaPorHorario();
            return aplicarMascaraNegraImagem(objImagemOriginal, this.valorTransparencia);
        }
    }
}
