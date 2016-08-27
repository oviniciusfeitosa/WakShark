using System;
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
            Color objColor = this.objVFBitmapLocker.getPixel(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
            return Common.ColorHelper.HexConverter(objColor);
        }

        public string obterPixel(int eixoHorizontal, int eixoVertical)
        {
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

        public Model.Tela procurarImagemPorTemplate(string caminhoTemplateRecurso)
        {
            ImagemCaptura objImagemCaptura = ImagemCaptura.obterInstancia();
            Bitmap objBitmapTemplate = new Bitmap(caminhoTemplateRecurso);

            if (objImagemCaptura.isUtilizarMascaraLuminosidade)
            {
                objBitmapTemplate = ImagemMascaraNegra.obterInstancia().aplicarMascaraNegraImagem(objBitmapTemplate);
            }

            objBitmapTemplate = ImagemTransformacao.obterInstancia().converterImagemPara8bitesPorPixel(objBitmapTemplate);

            Image<Emgu.CV.Structure.Gray, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Gray, byte>(objImagemCaptura.obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true)); // Image B
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(objBitmapTemplate); // Image A

            Model.Tela objModelTela = new Model.Tela();
            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCORR_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                if (maxValues[0] > 0.5d)
                {
                    objModelTela.eixoHorizontal = maxLocations[0].X;
                    objModelTela.eixoVertical = maxLocations[0].Y;
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
    }
}
