﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Drawing;
using Common;
using Common.Lib;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Threading;

namespace Common
{
    public class ImagemBusca
    {
        #region Singleton
        private static ImagemBusca objImagemBusca;

        public static ImagemBusca obterInstancia()
        {
            if (ImagemBusca.objImagemBusca == null)
            {
                ImagemBusca.objImagemBusca = new ImagemBusca();
            }
            return ImagemBusca.objImagemBusca;
        }
        #endregion

        public VFBitmapLocker objVFBitmapLocker;

        public string obterPixel(Model.Tela objModelTela)
        {
            if (this.objVFBitmapLocker == null)
            {
                this.objVFBitmapLocker = new Common.Lib.VFBitmapLocker(ImagemCaptura.obterInstancia().obterImagemTela());
            }
            Color objColor = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            return Common.ColorHelper.HexConverter(objColor);
        }

        public string obterPixel(int eixoHorizontal, int eixoVertical)
        {
            if (this.objVFBitmapLocker == null)
            {
                this.objVFBitmapLocker = new Common.Lib.VFBitmapLocker(ImagemCaptura.obterInstancia().obterImagemTela());
            }
            Color objColor = this.objVFBitmapLocker.getPixel(eixoHorizontal, eixoVertical);
            return Common.ColorHelper.HexConverter(objColor);
        }

        // Percentual: Entre 0 e 1
        public string obterPixelClaro(Model.Tela objModelTela, float percentual)
        {
            Color objColor = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            objColor = ControlPaint.Light(objColor, percentual);
            return Common.ColorHelper.HexConverter(objColor);
        }

        // Percentual: Entre 0 e 1
        public string obterPixelEscuro(Model.Tela objModelTela, float percentual)
        {
            Color objColor = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            objColor = ControlPaint.Dark(objColor, percentual);

            return Common.ColorHelper.HexConverter(objColor);
        }

        public Color mudarClaridadeCor(Color objColor, float fatorCorrecao)
        {
            float red = (float)objColor.R;
            float green = (float)objColor.G;
            float blue = (float)objColor.B;

            if (fatorCorrecao < 0)
            {
                // escuro
                fatorCorrecao = 1 + fatorCorrecao;
                red *= fatorCorrecao;
                green *= fatorCorrecao;
                blue *= fatorCorrecao;
            }
            else
            {
                //claro
                red = (255 - red) * fatorCorrecao + red;
                green = (255 - green) * fatorCorrecao + green;
                blue = (255 - blue) * fatorCorrecao + blue;
            }

            return Color.FromArgb(objColor.A, (int)red, (int)green, (int)blue);
        }

        public bool compararClaridadeCores(Color objCorCorreta, Color objCorComparacao)
        {
            float brightnessCorreta = objCorCorreta.GetBrightness();
            float brightnessComparacao = objCorComparacao.GetBrightness();
            if (brightnessCorreta != brightnessComparacao)
            {
                if (brightnessCorreta > brightnessComparacao)
                {
                    //0.17f
                    for (float fatorCorrecao = 0.01f; fatorCorrecao <= 1f; fatorCorrecao += 0.01f)
                    {
                        brightnessComparacao = ImagemBusca.obterInstancia().mudarClaridadeCor(objCorComparacao, fatorCorrecao).GetBrightness();
                        if (brightnessCorreta == brightnessComparacao)
                        {
                            //ImagemBusca.obterInstancia().luminosidade = fatorCorrecao;
                            return true;
                        }
                    }
                }
                else
                {
                    for (float fatorCorrecao = -0.01f; fatorCorrecao >= -1f; fatorCorrecao -= 0.01f)
                    {
                        brightnessComparacao = ImagemBusca.obterInstancia().mudarClaridadeCor(objCorComparacao, fatorCorrecao).GetBrightness();
                        if (brightnessCorreta == brightnessComparacao)
                        {
                            //ImagemBusca.obterInstancia().luminosidade = fatorCorrecao;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        // seria isPixelVariavel + compararHSL
        public bool isPixelVariavel(Model.Tela objModelTela, string pixelComparacao)
        {
            Color objColorAtual = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            Color objCorCorreta = System.Drawing.ColorTranslator.FromHtml(pixelComparacao);
            byte variacaoPixel = 22;
            if (
                (objCorCorreta.R + variacaoPixel >= objColorAtual.R && objCorCorreta.R - variacaoPixel <= objColorAtual.R)
                && (objCorCorreta.G + variacaoPixel >= objColorAtual.G && objCorCorreta.G - variacaoPixel <= objColorAtual.G)
                && (objCorCorreta.B + variacaoPixel >= objColorAtual.B && objCorCorreta.B - variacaoPixel <= objColorAtual.B)
                )
            {
                return true;
            }
            return false;
        }

        public bool compararHSL(Model.Tela objModelTela, string pixelComparacao)
        {
            Color objCorAtual = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            Color objCorCorreta = System.Drawing.ColorTranslator.FromHtml(pixelComparacao);

            HSLColor objCorAtualHSL = HSLColor.FromRGB(objCorAtual);
            HSLColor objCorCorretaHSL = HSLColor.FromRGB(objCorCorreta);

            float variacaoSaturacao = 0.09f;
            float variacaoLuminosidade = 0.09f;
            if (
                   (objCorAtualHSL.Luminosity + variacaoLuminosidade >= objCorCorretaHSL.Luminosity && objCorAtualHSL.Luminosity - variacaoLuminosidade <= objCorCorretaHSL.Luminosity)
                && (objCorAtualHSL.Saturation + variacaoSaturacao >= objCorCorretaHSL.Saturation && objCorAtualHSL.Saturation - variacaoSaturacao <= objCorCorretaHSL.Saturation)
                )
            {
                return true;
            }
            return false;
        }

        public bool isPixelEncontrado(int eixoHorizontal, int eixoVertical, string pixelComparacao)
        {
            if (eixoHorizontal > 0 && eixoVertical > 0)
            {
                if (this.obterPixel(eixoHorizontal, eixoVertical) == pixelComparacao) return true;
                //if (this.isPixelVariavel(objModelTela, pixelComparacao)) return true;
                //if (this.compararHSL(objModelTela, pixelComparacao)) return true;
            }
            return false;

        }

        /// <summary>
        /// Método responsável por procurar padrões de pixels e executar ações.
        /// </summary>
        /// <typeparam name="TRetornoBusca">Parâmetro do Tipo Anônimo utilizado como tipo de retorno no método delegável "objMetodoBusca".</typeparam>
        /// <typeparam name="TParametroAcaoResultado">Parâmetro do Tipo Anônimo utilizado na assinatura do método delegável "objMetodoAcao".</typeparam>
        /// <param name="objMetodoBusca">Função por delegação, que recebe um método delegável(delegate), com o primeiro parâmetro do tipo ModelTela e retorna um boolean como resultado.</param>
        /// <param name="objMetodoAcao">Função por delegação, que recebe um método delegável(delegate), com o primeiro parâmetro um Tipo Anônimo e retorna um boolean como resultado.</param>
        /// <returns></returns>
        public TParametroAcaoResultado procurarPadroesPixels<TRetornoBusca, TParametroAcaoResultado>(
            Func<Model.Tela, TRetornoBusca> objMetodoBusca,
            Func<Model.Tela, TRetornoBusca, TParametroAcaoResultado, TParametroAcaoResultado> objMetodoAcao
            )
        {
            TParametroAcaoResultado objTTipoAcaoBusca = default(TParametroAcaoResultado);
            try
            {
                Model.Tela objModelTela = new Model.Tela();
                String horarioAtual = System.DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss");
                Bitmap objBitmap = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel();

                using (this.objVFBitmapLocker = new Common.Lib.VFBitmapLocker(objBitmap))
                {
                    TRetornoBusca objRetornoBusca = default(TRetornoBusca);
                    for (int totalPixels = 0; totalPixels < this.objVFBitmapLocker.height * this.objVFBitmapLocker.width; totalPixels++)
                    {
                        objModelTela.eixoHorizontal = totalPixels % this.objVFBitmapLocker.width;
                        objModelTela.eixoVertical = totalPixels / this.objVFBitmapLocker.width;

                        objRetornoBusca = objMetodoBusca(objModelTela);
                        if (objRetornoBusca != null)
                        {
                            objTTipoAcaoBusca = objMetodoAcao(objModelTela, objRetornoBusca, objTTipoAcaoBusca);
                        }
                    }
                    MessageBox.Show("Iniciado em: " + horarioAtual + "\n Concluído em: " + System.DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss"));

                }
            }
            catch (Exception objException)
            {
                throw new Exception(objException.ToString());
            }
            return objTTipoAcaoBusca;
        }

        //Rectangle RectPersonagem = new Rectangle(eixoHorizontal, eixoVertical, larguraEAlturaRetangulo, larguraEAlturaRetangulo);

        public Model.Tela procurarImagemPorTemplate(string caminhoTemplateRecurso)
        {
            return procurarImagemPorTemplate(caminhoTemplateRecurso, Imagem.EnumRegiaoImagem.COMPLETO, new Rectangle(0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height));
        }

        public Model.Tela procurarImagemPorTemplate(string caminhoTemplateRecurso, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            return procurarImagemPorTemplate(caminhoTemplateRecurso, objRegiaoImagem, new Rectangle(0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height));
        }

        public Model.Tela procurarImagemPorTemplate(string caminhoTemplateRecurso, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle areaBusca)
        {
            //System.Threading.Thread.Sleep(3000);
            ImagemCaptura objImagemCaptura = ImagemCaptura.obterInstancia();
            Bitmap objBitmapTemplate = new Bitmap(caminhoTemplateRecurso);
            if (objImagemCaptura.isUtilizarMascaraLuminosidade) objBitmapTemplate = ImagemMascaraNegra.obterInstancia().aplicarMascaraNegraImagem(objBitmapTemplate);
            objBitmapTemplate = ImagemTransformacao.obterInstancia().converterImagemPara8bitesPorPixel(objBitmapTemplate);

            Bitmap objTelaPrincipal = objImagemCaptura.obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true);
            objTelaPrincipal = objTelaPrincipal.Clone(new Rectangle(0, 0, objTelaPrincipal.Width, objTelaPrincipal.Height), System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            objTelaPrincipal = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(objTelaPrincipal, objRegiaoImagem, areaBusca);
            objTelaPrincipal.Save(@"c:\users\public\vinicius123.bmp");
            Image<Emgu.CV.Structure.Gray, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Gray, byte>(objTelaPrincipal); // Image B
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(objBitmapTemplate); // Image A

            Model.Tela objModelTela = new Model.Tela();
            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCORR_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.5d)
                {
                    objModelTela.eixoHorizontal = maxLocations[0].X + areaBusca.X;
                    objModelTela.eixoVertical = maxLocations[0].Y + areaBusca.Y;
                }
            }

            objImagemTelaAtual.Dispose();
            objBitmapTemplate.Dispose();

            return objModelTela;
        }

        public bool procurarImagemPorTemplateComAcao(string caminhoTemplateRecurso, Func<Model.Tela, bool> objMetodoAcao)
        {
            Model.Tela objModelTela = this.procurarImagemPorTemplate(caminhoTemplateRecurso);
            if (objModelTela.eixoHorizontal > 0 && objModelTela.eixoVertical > 0) return objMetodoAcao(objModelTela);
            return false;
        }



        public bool procurarImagemPorTemplateComAcao(string caminhoTemplateRecurso, Func<Model.Tela, bool> objMetodoAcao, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle areaBusca)
        {
            Model.Tela objModelTela = this.procurarImagemPorTemplate(caminhoTemplateRecurso, objRegiaoImagem, areaBusca);
            if (objModelTela.eixoHorizontal > 0 && objModelTela.eixoVertical > 0) return objMetodoAcao(objModelTela);
            return false;
        }

        public bool procurarImagemPorTemplateRotacionadoComAcao(string caminhoTemplateRecurso, Func<Model.Match, bool> objMetodoAcao, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle areaBusca)
        {
            Model.Match match = buscarImagemPorTemplateRotacionado(caminhoTemplateRecurso, objRegiaoImagem, areaBusca );
            if (match.Location.X > 0 && match.Location.Y > 0) return objMetodoAcao(match);
            return false;
        }



        public Model.Match buscarImagemPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle AreaBusca)
        {
            ///System.Threading.Thread.Sleep(3000);
            Bitmap objBitmapTemplate = (Bitmap)Bitmap.FromFile(caminhoTemplateNumero);
            Bitmap telaOriginal = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela(true);
            telaOriginal.Save(@"C:\\Users\\Public\\telaOriginal.bmp");
            ImagemTransformacao objImagemTransformacao = ImagemTransformacao.obterInstancia();
            objBitmapTemplate = objImagemTransformacao.redimensionarImagem(objBitmapTemplate, objImagemTransformacao.calcularProporcao(objBitmapTemplate.Width, 1600, telaOriginal.Width), objImagemTransformacao.calcularProporcao(objBitmapTemplate.Height, 900, telaOriginal.Height));
            Image<Emgu.CV.Structure.Rgb, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Rgb, byte>(objBitmapTemplate);


            float anguloRotacao = 315f;

            Bitmap telaOriginalRotacionada = objImagemTransformacao.redimensionarImagem(telaOriginal, telaOriginal.Width / 2, telaOriginal.Height);
            telaOriginalRotacionada = objImagemTransformacao.rotacionarImagem(telaOriginalRotacionada, anguloRotacao); //Deveria ser 45 graus, mas como rotacionei 45 no sentido anti-horario, entao ficou como 315 graus
            telaOriginalRotacionada.Save(@"C:\\Users\\Public\\telaOriginalRotacionada.bmp");

            Bitmap telaRotacionadaCortada = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(telaOriginalRotacionada, objRegiaoImagem, AreaBusca);
            telaRotacionadaCortada.Save(@"C:\\Users\\Public\\telaRotacionadaCortada.bmp");

            Image<Emgu.CV.Structure.Rgb, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Rgb, byte>(telaRotacionadaCortada); // Image B
            objImagemTelaAtual.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTelaAtual.bmp");
            objImagemTemplate.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTemplate.bmp");

            Model.Match matchRetorno = new Model.Match();
            
            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;

                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                if (minValues.Length > 1 || maxValues.Length > 1)
                {

                }
                Dictionary<double, Point> MatchesMax = new Dictionary<double, Point>();
                Dictionary<double, Point> MatchesMin = new Dictionary<double, Point>();

                int cnt = 0;
                for (int i = 0; i < maxLocations.Length; i++)
                {
                    matchRetorno.Location = ImagemTransformacao.obterInstancia().RotatePoint(new Point(maxLocations[i].X + AreaBusca.X, maxLocations[i].Y + AreaBusca.Y), new Point(telaOriginal.Width / 2 / 2, telaOriginal.Height / 2), 45d);
                    if (caminhoTemplateNumero.Contains("numero"))
                    {
                        matchRetorno.Numero = int.Parse(caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero") + 6, 1));
                    }

                    if (maxValues[i] > 0.699d)
                    {
                        matchRetorno.Semelhanca = maxValues[i];

                        //objImagemTelaAtual.Copy(new Rectangle(maxLocations[i].X, maxLocations[i].Y, objImagemTemplate.Width, objImagemTemplate.Height)).Save(@"C:\\Users\\Public\\match_" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + maxValues[cnt].ToString() + ".bmp");
                    }
                    cnt++;
                }

                double valorMaximo = maxValues[0];
            }

            //objImagemTelaAtual.ToBitmap().Save("C:\\Users\\Public\\objImagemTelaAtual2.bmp");
            //caminhoTemplateRecurso.Replace("./", "");
            //objImagemTemplate.ToBitmap().Save("C:\\Users\\Public\\objImagemTemplate" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + ".bmp");
            objImagemTelaAtual.Dispose();
            objImagemTemplate.Dispose();
            //telaOriginal.Dispose();
            telaOriginalRotacionada.Dispose();
            telaRotacionadaCortada.Dispose();
            objBitmapTemplate.Dispose();

            return matchRetorno;
        }


    }
}
