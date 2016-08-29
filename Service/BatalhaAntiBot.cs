using Common;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
            System.Threading.Thread.Sleep(5000);
            return true;
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            return buscarNumeroPorTemplateRotacionado(caminhoTemplateNumero, objRegiaoImagem, new Rectangle(0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height));
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle AreaBusca)
        {
            Bitmap template8bits = (Bitmap)Bitmap.FromFile(caminhoTemplateNumero);
            ImagemTransformacao objImagemTransformacao = ImagemTransformacao.obterInstancia();

            //template8bits = objImagemTransformacao.converterImagemPara8bitesPorPixel(template8bits);
           // System.Threading.Thread.Sleep(3000);
            //template8bits = objImagem.redimencionarImagem(template8bits, template8bits.Width / 2, template8bits.Height);
            //template8bits = objImagem.rotacionarImagem(template8bits, 315f);
            Image<Emgu.CV.Structure.Rgb, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Rgb, byte>(template8bits);


            //Bitmap tela = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel();
            //System.Threading.Thread.Sleep(3000);
            Bitmap telaOriginal = ImagemCaptura.obterInstancia().obterImagemTela();
            telaOriginal.Save(@"C:\\Users\\Public\\telaOriginal.bmp");

            Bitmap telaOriginalRotacionada; 

            float anguloRotacao = 315f;

            telaOriginalRotacionada = objImagemTransformacao.redimencionarImagem(telaOriginal, telaOriginal.Width / 2, telaOriginal.Height);
            telaOriginalRotacionada = objImagemTransformacao.rotacionarImagem(telaOriginalRotacionada, anguloRotacao); //Deveria ser 45 graus, mas como rotacionei 45 no sentido anti-horario, entao ficou como 315 graus
            telaOriginalRotacionada.Save(@"C:\\Users\\Public\\telaOriginalRotacionada.bmp");

            Bitmap telaRotacionadaCortada = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(telaOriginalRotacionada, objRegiaoImagem, AreaBusca);
            telaRotacionadaCortada.Save(@"C:\\Users\\Public\\telaRotacionadaCortada.bmp");

            Image<Emgu.CV.Structure.Rgb, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Rgb, byte>(telaRotacionadaCortada); // Image B

            //objImagemTelaAtual = objImagemTelaAtual.ThresholdBinary(new Gray(135), new Gray(255));
            //objImagemTelaAtual._Not();
            //objImagemTelaAtual.Erode(1);

            Model.Match matchRetorno = new Model.Match();
            objImagemTelaAtual.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTelaAtual.bmp");
            objImagemTemplate.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTemplate.bmp");

            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                Dictionary<double, Point> MatchesMax = new Dictionary<double, Point>();
                Dictionary<double, Point> MatchesMin = new Dictionary<double, Point>();

                Bitmap imgResultado = (Bitmap)telaRotacionadaCortada.Clone(new Rectangle(0,0,result.Bitmap.Width, result.Bitmap.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                int cnt = 0;
                for (int i = 0; i < maxLocations.Length; i++)
                {
                    matchRetorno.Location = ImagemTransformacao.obterInstancia().RotatePoint(new Point(maxLocations[i].X + AreaBusca.X, maxLocations[i].Y + AreaBusca.Y), new Point(telaOriginal.Width / 2 /2, telaOriginal.Height / 2), 45d);

                    if (maxValues[i] > 0.699d)
                    {
                        
                        matchRetorno.Semelhanca = maxValues[i];
                        if (caminhoTemplateNumero.Contains("numero"))
                        {
                            matchRetorno.Numero = int.Parse(caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero") + 6, 1));
                        }
                        objImagemTelaAtual.Copy(new Rectangle(maxLocations[i].X, maxLocations[i].Y, objImagemTemplate.Width, objImagemTemplate.Height)).Save(@"C:\\Users\\Public\\match_" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + maxValues[cnt].ToString() + ".bmp");
                        //for (int x = maxLocations[i].X; x < maxLocations[i].X + template8bits.Width - 1; x++)
                        //{
                        //    for (int y = maxLocations[i].Y; y < maxLocations[i].Y + template8bits.Height - 1; y++)
                        //    {
                        //        try
                        //        {
                        //            imgResultado.SetPixel(x, y, Color.LightGreen);
                        //        }
                        //        catch (System.Exception exc)
                        //        {

                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        //for (int x = maxLocations[i].X; x < maxLocations[i].X + template8bits.Width - 1; x++)
                        //{
                        //    for (int y = maxLocations[i].Y; y < maxLocations[i].Y + template8bits.Height - 1; y++)
                        //    {
                        //        try {
                        //            imgResultado.SetPixel(x, y, Color.Red);
                        //        }
                        //        catch (System.Exception exc)
                        //        {

                        //        }
                        //    }
                        //}
                    }
                    cnt++;
                }

                imgResultado.Save(@"C:\users\public\imgResultado_" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero") + 6).Replace(".bmp","") + "_.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                double valorMaximo = maxValues[0];
                

                //cnt = 0;
                //foreach (Point p in minLocations)
                //{
                //    //                    if (valorMaximo > 0.5d)
                //    //                  {
                //    objImagemTelaAtual.Copy(new Rectangle(p.X, p.Y, objImagemTemplate.Width, objImagemTemplate.Height)).Save(@"C:\\Users\\Public\\match_" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + minValues[cnt].ToString() + ".bmp");
                //    //                }
                //    cnt++;
                //}
                //List<double> values = maxValues.ToList<double>();

                //values.Sort();
                ////List<>
                ////valorMaximo = values.Last<double>();

                //if (valorMaximo > 0.5d)
                //{
                //    //objPoint.X = 
                //}
            }

            objImagemTelaAtual.ToBitmap().Save("C:\\Users\\Public\\objImagemTelaAtual2.bmp");
            //caminhoTemplateRecurso.Replace("./", "");
            objImagemTemplate.ToBitmap().Save("C:\\Users\\Public\\objImagemTemplate" + caminhoTemplateNumero.Substring(caminhoTemplateNumero.IndexOf("numero")).Replace(".bmp", "") + ".bmp");
            objImagemTelaAtual.Dispose();
            objImagemTemplate.Dispose();
            telaOriginal.Dispose();
            telaOriginalRotacionada.Dispose();
            telaRotacionadaCortada.Dispose();
            template8bits.Dispose();

            return matchRetorno;
        }
    }

}
