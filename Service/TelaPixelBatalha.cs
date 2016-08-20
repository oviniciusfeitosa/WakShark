using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class TelaPixelBatalha
    {

        #region Singleton
        private static TelaPixelBatalha objTelaPixelBatalha;

        public static TelaPixelBatalha obterInstancia()
        {
            if (TelaPixelBatalha.objTelaPixelBatalha == null)
            {
                TelaPixelBatalha.objTelaPixelBatalha = new TelaPixelBatalha();
            }
            return TelaPixelBatalha.objTelaPixelBatalha;
        }
        #endregion

        public Model.Tela buscarNumeroPorTemplate(string caminhoTemplateNumero, TelaCaptura.EnumRegiaoTela objRegiaoTela)
        {
            Service.TelaCaptura objServiceTelaCaptura = Service.TelaCaptura.obterInstancia();
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(caminhoTemplateNumero);
            //Bitmap objBitmapTemplate = new Bitmap();
            //Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = this.converterTemplateParaCinza(objBitmapTemplate);
            Image<Emgu.CV.Structure.Gray, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Gray, byte>(TelaCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(objRegiaoTela)); // Image B

            objImagemTelaAtual = objImagemTelaAtual.ThresholdBinary(new Gray(135), new Gray(255));
            objImagemTelaAtual._Not();
            //objImagemTelaAtual.Erode(1);

            Model.Tela objModelTela = new Model.Tela();

            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                double valorMaximo = maxValues[0];
                if (valorMaximo > 0.5d)
                {
                    objModelTela.eixoHorizontal = maxLocations[0].X + (objImagemTemplate.Width / 2);
                    objModelTela.eixoVertical = maxLocations[0].Y + (objImagemTemplate.Height / 2);
                }
            }

            //objImagemTelaAtual.ToBitmap().Save("C:\\Users\\Public\\teste1.bmp");
            //caminhoTemplateRecurso.Replace("./", "");
            //objImagemTemplate.ToBitmap().Save("C:\\Users\\Public\\" + caminhoTemplateRecurso + ".bmp");
            objImagemTelaAtual.Dispose();
            objImagemTemplate.Dispose();

            return objModelTela;
        }

        private Image<Emgu.CV.Structure.Gray, byte> converterTemplateParaCinza(Bitmap objBitmapTemplate) {

            Service.TelaCaptura objServiceTelaCaptura = Service.TelaCaptura.obterInstancia();
            if (objServiceTelaCaptura.isUtilizarMascaraLuminosidade)
            {
                objBitmapTemplate = objServiceTelaCaptura.aplicarMascaraNegraImagem(objBitmapTemplate);
            }

            objBitmapTemplate = objServiceTelaCaptura.converterImagemPara8bitesPorPixel(objBitmapTemplate);
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(objBitmapTemplate); // Image A
            //objImagemTemplate = objImagemTemplate.ThresholdBinary(new Gray(115), new Gray(255));
            objImagemTemplate = objImagemTemplate.ThresholdBinary(new Gray(145), new Gray(255));
            objImagemTemplate._Not();

            return objImagemTemplate;
        }

    }
}
