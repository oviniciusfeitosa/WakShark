﻿using Common.Lib;
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
                using (this.objBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb))
                {
                    var gfxScreenshot = Graphics.FromImage(this.objBitmap);

                    gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                                Screen.PrimaryScreen.Bounds.Y,
                                                0,
                                                0,
                                                Screen.PrimaryScreen.Bounds.Size,
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
            Size bounds = SystemInformation.PrimaryMonitorSize;

            using (Bitmap objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics g = Graphics.FromImage(objBitmap))
                {
                    g.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                }

                int valorTransparencia = ImagemTransparencia.obterInstancia().valorTransparencia;
                if (valorTransparencia > 0)
                {
                    using (Bitmap objBitmapMascarado = ImagemMascaraNegra.obterInstancia().aplicarMascaraNegraImagem(objBitmap, valorTransparencia))
                    {
                        return objBitmapMascarado.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
                    }
                }
                return objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format32bppArgb);
            }
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
                Size bounds = SystemInformation.PrimaryMonitorSize;
                //Rectangle bounds = SystemInformation.VirtualScreen;
                //Rectangle bounds = Screen.PrimaryScreen.Bounds;

                this.regiaoTelaAtual = objEnumRegiaoTela;

                this.objBitmap = new Bitmap(bounds.Width, bounds.Height, PixelFormat.Format32bppArgb);

                using (Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    Size objSize = objBitmap.Size;
                    switch (objEnumRegiaoTela)
                    {
                        case Imagem.EnumRegiaoImagem.LADO_ESQUERDO:
                            objGraphics.CopyFromScreen(0, 0, (int)(objBitmap.Width / 2.09), 0, objSize);
                            break;
                        case Imagem.EnumRegiaoImagem.LADO_DIREITO:
                            objGraphics.CopyFromScreen((int)(objBitmap.Width / 2), 0, (int)(objBitmap.Width / 2), 0, objSize);
                            break;
                        case Imagem.EnumRegiaoImagem.COMPLETO:
                        default:
                            objGraphics.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                            break;
                    }
                }
                this.objBitmap = objBitmap.Clone(new Rectangle(0, 0, bounds.Width, bounds.Height), PixelFormat.Format8bppIndexed);
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
