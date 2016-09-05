using Common.Lib;
using Model;
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
    public class ImagemCaptura
    {
        #region Singleton
        private static ImagemCaptura objImagemCaptura;

        public static ImagemCaptura obterInstancia()
        {
            if (ImagemCaptura.objImagemCaptura == null)
            {
                ImagemCaptura.objImagemCaptura = new ImagemCaptura();
            }
            return ImagemCaptura.objImagemCaptura;
        }
        #endregion

        public Bitmap objBitmap;

        public Imagem.EnumRegiaoImagem regiaoTelaAtual = Imagem.EnumRegiaoImagem.NAO_DEFINIDO;

        public Common.Lib.LockBitmap objLockedBitmap;

        public bool isUtilizarMascaraLuminosidade = false;

        public void capturarTela(String filePath)
        {
            try
            {
                Size bounds = Proporcao.obterProporcao();
                using (this.objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
                {
                    var gfxScreenshot = Graphics.FromImage(this.objBitmap);

                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                Screen.PrimaryScreen.Bounds.Y,
                                                0,
                                                0,
                                                bounds,
                                                CopyPixelOperation.SourceCopy);

                    if (this.objBitmap == null) throw new Exception();
                    this.objBitmap.Save(filePath, ImageFormat.Png);
                }
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.ToString());
            }
        }

        public Bitmap obterImagemTela()
        {
            return obterImagemTela(false);
        }

        public Bitmap obterImagemTela(bool isGerarNovaInstancia)
        {
            if (this.objBitmap == null || isGerarNovaInstancia == true)
            {
                Size bounds = Proporcao.obterProporcao();

                this.objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(this.objBitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0, this.objBitmap.Size);
                }

                int valorTransparencia = ImagemTransparencia.obterInstancia().valorTransparencia;
                if (valorTransparencia > 0)
                {
                    using (Bitmap objBitmapMascarado = ImagemMascaraNegra.obterInstancia().aplicarMascaraNegraImagem(this.objBitmap, valorTransparencia))
                    {
                        return objBitmapMascarado.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
                    }
                }
                
                
                this.objBitmap = objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
            }
            return this.objBitmap;
        }

        public Bitmap obterImagemTelaComo8bitesPorPixel()
        {
            return obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, false);
        }

        public Bitmap obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem objEnumRegiaoTela)
        {
            return obterImagemTelaComo8bitesPorPixel(objEnumRegiaoTela, false);
        }

        public Bitmap obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem objEnumRegiaoTela, bool isGerarNovaInstancia)
        {
            if (this.regiaoTelaAtual != objEnumRegiaoTela || isGerarNovaInstancia == true)
            {
                Size bounds = Proporcao.obterProporcao();

                //Rectangle bounds = SystemInformation.VirtualScreen;
                //Rectangle bounds = Screen.PrimaryScreen.Bounds;

                this.regiaoTelaAtual = objEnumRegiaoTela;

                Bitmap objBitmapTemporaria = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

                using (Graphics objGraphics = Graphics.FromImage(objBitmapTemporaria))
                {

                    Size objSize = objBitmapTemporaria.Size;
                    switch (objEnumRegiaoTela)
                    {
                        case Imagem.EnumRegiaoImagem.LADO_ESQUERDO:
                            objGraphics.CopyFromScreen(0, 0, (int)(objBitmapTemporaria.Width / 2.09), 0, objSize);
                            break;
                        case Imagem.EnumRegiaoImagem.LADO_DIREITO:
                            objGraphics.CopyFromScreen((int)(objBitmapTemporaria.Width / 2), 0, (int)(objBitmapTemporaria.Width / 2), 0, objSize);
                            break;
                        case Imagem.EnumRegiaoImagem.COMPLETO:
                        default:
                            objGraphics.CopyFromScreen(0, 0, 0, 0, objBitmapTemporaria.Size);
                            break;
                    }
                }
                this.objBitmap = objBitmapTemporaria.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
            }

            return this.objBitmap;
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
    }
}
