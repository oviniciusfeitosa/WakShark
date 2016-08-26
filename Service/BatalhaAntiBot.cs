using Common;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;

namespace Service
{
    public class BatalhaAntiBOT
    {
        #region Singleton
        private static BatalhaAntiBOT objBatalhaAntiBOT;

        public static BatalhaAntiBOT obterInstancia()
        {
            if (BatalhaAntiBOT.objBatalhaAntiBOT == null)
            {
                BatalhaAntiBOT.objBatalhaAntiBOT = new BatalhaAntiBOT();
            }
            return BatalhaAntiBOT.objBatalhaAntiBOT;
        }
        #endregion

        public enum numeroMarcacao {
            Um,
            Dois,
            Tres,
            Quatro,
            Cinco,
            Seis,
            Sete,
            Oito,
            Vazio
        };

        // @todo Implementar esse método
        public static bool buscarIconeInicioBatalha(Model.Tela objModelTela)
        {
            // Somente se existe o ícone de inicio batalha que a batalha será iniciada
            return false;
        }

        // @todo Implementar esse método
        public static bool acaoIniciarBatalha(Model.Tela objModelTela)
        {
            // Faça algo.
            System.Threading.Thread.Sleep(1000);

            System.Windows.Forms.SendKeys.SendWait(" ");
            System.Threading.Thread.Sleep(1000);
            return true;
        }

        public Point buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            Bitmap template8bits = (Bitmap)Bitmap.FromFile(caminhoTemplateNumero);
            ImagemTransformacao objImagemTransformacao = ImagemTransformacao.obterInstancia();
            //System.Threading.Thread.Sleep(3000);
            //template8bits = objImagem.redimencionarImagem(template8bits, template8bits.Width / 2, template8bits.Height);
            //template8bits = objImagem.rotacionarImagem(template8bits, 315f);
            Image<Emgu.CV.Structure.Gray, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Gray, byte>(template8bits);

            Bitmap tela = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel();
            tela.Save(@"C:\\Users\\Public\\telaOriginal.bmp");

            float anguloRotacao = 315f;

            tela = objImagemTransformacao.redimencionarImagem(tela, tela.Width / 2, tela.Height);
            tela = objImagemTransformacao.rotacionarImagem(tela, anguloRotacao); //Deveria ser 45 graus, mas como rotacionei 45 no sentido anti-horario, entao ficou como 315 graus
            tela = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(tela, objRegiaoImagem);
            tela.Save(@"C:\\Users\\Public\\telaRotacionada.bmp");

            Image<Emgu.CV.Structure.Gray, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Gray, byte>(tela); // Image B

            //objImagemTelaAtual = objImagemTelaAtual.ThresholdBinary(new Gray(135), new Gray(255));
            //objImagemTelaAtual._Not();
            //objImagemTelaAtual.Erode(1);

            Point objPoint = new Point();
            objImagemTelaAtual.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTelaAtual.bmp");
            objImagemTemplate.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTemplate.bmp");

            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                double valorMaximo = maxValues[0];

                foreach (Point p in maxLocations)
                {
                    if (valorMaximo > 0.5d)
                    {
                        objImagemTelaAtual.Copy(new Rectangle(p.X, p.Y, objImagemTemplate.Width, objImagemTemplate.Height)).Save(@"C:\\Users\\Public\\match_" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + ".bmp");
                    }
                }
            }

            objImagemTelaAtual.ToBitmap().Save("C:\\Users\\Public\\objImagemTelaAtual2.bmp");
            //caminhoTemplateRecurso.Replace("./", "");
            objImagemTemplate.ToBitmap().Save("C:\\Users\\Public\\objImagemTemplate" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + ".bmp");
            objImagemTelaAtual.Dispose();
            objImagemTemplate.Dispose();
            tela.Dispose();
            template8bits.Dispose();

            return objPoint;
        }
    }
}
