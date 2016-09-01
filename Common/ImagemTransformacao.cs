using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

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


        public Bitmap redimensionarImagem(Bitmap objImagem, int largura, int altura)
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

        public Bitmap extrairRegiaoImagem(Bitmap objBitmap, Imagem.EnumRegiaoImagem objEnumRegiaoTela)
        {
            return extrairRegiaoImagem(objBitmap, objEnumRegiaoTela);
        }

        public Bitmap extrairRegiaoImagem(Bitmap objBitmap, Imagem.EnumRegiaoImagem objEnumRegiaoTela, Rectangle Area)
        {

            objBitmap.SetResolution(objBitmap.HorizontalResolution, objBitmap.VerticalResolution);
            Bitmap obj8bpp = objBitmap.Clone(new Rectangle(0, 0, objBitmap.Width, objBitmap.Height), PixelFormat.Format32bppRgb);

            Rectangle rectExtracao = Area;

            using (Graphics objGraphics = Graphics.FromImage(obj8bpp))
            {

                objGraphics.DrawImageUnscaled(obj8bpp, 0, 0);
                // Brush brush = new SolidBrush(Color.FromArgb(255, Color.White));
                int posicaoHorizontalInicial = 0;
                int posicaoHorizontalFinal = 0;
                int posicaoVerticalInicial = 0;
                int posicaoVerticalFinal = obj8bpp.Height;

                Bitmap telaRecortada = new Bitmap(obj8bpp.Width, obj8bpp.Height);

                switch (objEnumRegiaoTela)
                {
                    case Imagem.EnumRegiaoImagem.LADO_ESQUERDO:
                        posicaoHorizontalInicial = (int)(obj8bpp.Width / 2);
                        posicaoHorizontalFinal = obj8bpp.Width;
                        rectExtracao = new Rectangle(posicaoHorizontalInicial, posicaoVerticalInicial, posicaoHorizontalFinal, posicaoVerticalFinal);
                        break;
                    case Imagem.EnumRegiaoImagem.LADO_DIREITO:
                        posicaoHorizontalInicial = 0;
                        posicaoHorizontalFinal = (int)(obj8bpp.Width / 2);
                        rectExtracao = new Rectangle(posicaoHorizontalInicial, posicaoVerticalInicial, posicaoHorizontalFinal, posicaoVerticalFinal);
                        break;
                    case Imagem.EnumRegiaoImagem.RETANGULO:
                        telaRecortada = new Bitmap(Area.Width, Area.Height);
                        break;
                    case Imagem.EnumRegiaoImagem.RETANGULO_TELA_CHEIA:
                        break;
                        // @todo Adicionar Enumeradores para outras posições.

                }

                //objGraphics.FillRectangle(brush, rectExtracao);
                telaRecortada = obj8bpp.Clone(rectExtracao, PixelFormat.Format32bppRgb);
                telaRecortada.MakeTransparent(Color.Black);
                Bitmap novaTela = new Bitmap(obj8bpp.Width, obj8bpp.Height);
                Graphics g = Graphics.FromImage(novaTela);
                
                g.DrawImage(telaRecortada, new Point(Area.X, Area.Y));

                //brush.Dispose();
                return telaRecortada;
            }
        }

        public Image CropImage(System.Drawing.Image Image, int Height, int Width)
        {
            return CropImage(Image, Height, Width, 0, 0);
        }

        public Image CropImage(Image Image, int Height, int Width, int StartAtX, int StartAtY)
        {
            MemoryStream objMemoryStream = null;
            try
            {
                if (Image.Height < Height) Height = Image.Height;
                if (Image.Width < Width) Width = Image.Width;

                Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format32bppRgb);
                //bmPhoto.SetResolution(72, 72);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.SmoothingMode = SmoothingMode.AntiAlias;
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;

                grPhoto.DrawImage(Image, new Rectangle(0, 0, Width, Height), StartAtX, StartAtY, Width, Height, GraphicsUnit.Pixel);

                objMemoryStream = new MemoryStream();
                bmPhoto.Save(objMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Image.Dispose();
                bmPhoto.Dispose();
                grPhoto.Dispose();

                return Image.FromStream(objMemoryStream);
            }
            catch (Exception objException)
            {
                throw new Exception("Falha ao recortar imagem : " + objException.Message);
            }
        }

        public Point obterPontoRotacionado(float angle, Point pt)
        {
            var a = angle * System.Math.PI / 180.0;
            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);

            return new Point((int)(pt.X * cosa - pt.Y * sina), (int)(pt.X * sina + pt.Y * cosa));
        }

        public Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);

            Point pt = new Point();
            pt.X = ((int)(cosTheta * (pointToRotate.X - centerPoint.X) - sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X)) * 2;
            pt.Y = (int)(sinTheta * (pointToRotate.X - centerPoint.X) + cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y);

            return pt;

        }

        public int calcularProporcao(int valorTransformacao, int valorOrigem, int valorDestino)
        {
            if (valorDestino != valorOrigem) valorTransformacao = ((valorTransformacao * valorDestino) / valorOrigem);
            return valorTransformacao;
        }

    }
}

