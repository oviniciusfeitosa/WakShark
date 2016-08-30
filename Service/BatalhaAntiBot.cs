using Common;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

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

        public Bitmap telaRotacionadaLadoEsquerdo { get; set; }

        public Bitmap telaRotacionadaLadoDireito { get; set; }

        // @todo Implementar esse método
        public static bool buscarIconeInicioBatalha(Model.Tela objModelTela)
        {
            // Somente se existe o ícone de inicio batalha que a batalha será iniciada
            return false;
        }

        
        public bool acaoIniciarBatalha()
        {
            System.Threading.Thread.Sleep(1000);
            System.Windows.Forms.SendKeys.SendWait(" ");
            System.Threading.Thread.Sleep(4000);
            try
            {
                if (ImagemCaptura.obterInstancia().objBitmap != null) ImagemCaptura.obterInstancia().objBitmap.Dispose();
                Bitmap objBitmap = ImagemCaptura.obterInstancia().obterImagemTela(true);

                // if (this.imagemLadoEsquerdo != null) this.imagemLadoEsquerdo.Dispose();
                //if (this.imagemLadoDireito != null) this.imagemLadoDireito.Dispose();

                int eixoHorizontal = ImagemTransformacao.obterInstancia().calcularProporcao(275, 1600, objBitmap.Width); ;
                int eixoVertical = ImagemTransformacao.obterInstancia().calcularProporcao(405, 900, objBitmap.Height);
                int larguraEAlturaRetangulo = ImagemTransformacao.obterInstancia().calcularProporcao(107, 1440000, objBitmap.Width * objBitmap.Height);

                Rectangle RectPersonagem = new Rectangle(eixoHorizontal, eixoVertical, larguraEAlturaRetangulo, larguraEAlturaRetangulo);

                eixoHorizontal = ImagemTransformacao.obterInstancia().calcularProporcao(448, 1600, objBitmap.Width); ;
                Rectangle RectGato = new Rectangle(eixoHorizontal, eixoVertical, larguraEAlturaRetangulo, larguraEAlturaRetangulo);

                Dictionary<int, Model.Match> MatchesGato = new Dictionary<int, Model.Match>();
                MatchesGato.Add(1, this.buscarNumeroPorTemplateRotacionado(@"./numero1.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(2, this.buscarNumeroPorTemplateRotacionado(@"./numero2.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(3, this.buscarNumeroPorTemplateRotacionado(@"./numero3.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(4, this.buscarNumeroPorTemplateRotacionado(@"./numero4.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(5, this.buscarNumeroPorTemplateRotacionado(@"./numero5.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(6, this.buscarNumeroPorTemplateRotacionado(@"./numero6.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(7, this.buscarNumeroPorTemplateRotacionado(@"./numero7.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(8, this.buscarNumeroPorTemplateRotacionado(@"./numero8.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                Application.DoEvents();

                List<Model.Match> Verificar = new List<Model.Match>();
                foreach (Model.Match m in MatchesGato.Values)
                {
                    if (m.Semelhanca > 0)
                    {
                        Verificar.Add(m);
                    }
                }

                //System.Threading.Thread.Sleep(1000);
                List<Model.Match> Clicar = new List<Model.Match>();
                bool conflito = false;
                if (Verificar.Count > 3)
                {
                    for (int i = 0; i < Verificar.Count; i++)
                    {
                        conflito = false;

                        for (int j = 0; j < Verificar.Count; j++)
                        {
                            if (i == j)
                            {
                                continue;
                            }

                            if (new Rectangle(Verificar[i].Location, new Size(24, 24)).Contains(Verificar[j].Location))
                            {
                                conflito = true;
                                if (Verificar[i].Semelhanca > Verificar[j].Semelhanca)
                                    Clicar.Add(Verificar[i]);
                                else
                                    Clicar.Add(Verificar[j]);
                            }

                        }
                        if (!conflito) Clicar.Add(Verificar[i]);
                    }
                }
                else
                {
                    Clicar.AddRange(Verificar);
                }

                foreach (Model.Match objMatch in Clicar)
                {
                    
                    //System.Threading.Thread.Sleep(2000);
                    Model.Match matchClicar = this.buscarNumeroPorTemplateRotacionado(@"./numero" + objMatch.Numero.ToString() + ".png", Imagem.EnumRegiaoImagem.RETANGULO, RectPersonagem);

                    System.Windows.Forms.SendKeys.SendWait("1");
                    System.Threading.Thread.Sleep(1000);
                    Common.Lib.Win32.posicionarMouse(matchClicar.Location.X, matchClicar.Location.Y);
                    Common.Lib.Win32.clicarBotaoEsquerdo(matchClicar.Location.X, matchClicar.Location.Y);
                    
                    /*System.Windows.Forms.SendKeys.SendWait("1");
                    System.Threading.Thread.Sleep(1000);
                    Common.Lib.Win32.clicarBotaoEsquerdo(objMatch.Location.X, objMatch.Location.Y);*/
                }

                Application.DoEvents();

                System.Threading.Thread.Sleep(5000);
                System.Windows.Forms.SendKeys.SendWait("{ESC}");
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
            return true;
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            return buscarNumeroPorTemplateRotacionado(caminhoTemplateNumero, objRegiaoImagem, new Rectangle(0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height));
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle AreaBusca)
        {
            Bitmap objBitmapTemplate = (Bitmap)Bitmap.FromFile(caminhoTemplateNumero);
            Bitmap telaOriginal = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela(true);
            //telaOriginal.Save(@"C:\\Users\\Public\\telaOriginal.bmp");
            ImagemTransformacao objImagemTransformacao = ImagemTransformacao.obterInstancia();
            objBitmapTemplate = objImagemTransformacao.redimencionarImagem(objBitmapTemplate, objImagemTransformacao.calcularProporcao(objBitmapTemplate.Width, 1600, telaOriginal.Width), objImagemTransformacao.calcularProporcao(objBitmapTemplate.Height, 900, telaOriginal.Height));
            Image<Emgu.CV.Structure.Rgb, byte> objImagemTemplate = new Image<Emgu.CV.Structure.Rgb, byte>(objBitmapTemplate);
            

            float anguloRotacao = 315f;

            Bitmap telaOriginalRotacionada = objImagemTransformacao.redimencionarImagem(telaOriginal, telaOriginal.Width / 2, telaOriginal.Height);
            telaOriginalRotacionada = objImagemTransformacao.rotacionarImagem(telaOriginalRotacionada, anguloRotacao); //Deveria ser 45 graus, mas como rotacionei 45 no sentido anti-horario, entao ficou como 315 graus
            //telaOriginalRotacionada.Save(@"C:\\Users\\Public\\telaOriginalRotacionada.bmp");

            Bitmap telaRotacionadaCortada = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(telaOriginalRotacionada, objRegiaoImagem, AreaBusca);
            //telaRotacionadaCortada.Save(@"C:\\Users\\Public\\telaRotacionadaCortada.bmp");

            Image<Emgu.CV.Structure.Rgb, byte> objImagemTelaAtual = new Image<Emgu.CV.Structure.Rgb, byte>(telaRotacionadaCortada); // Image B
            //objImagemTelaAtual.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTelaAtual.bmp");
            //objImagemTemplate.ToBitmap().Save(@"C:\\Users\\Public\\objImagemTemplate.bmp");

            Model.Match matchRetorno = new Model.Match();
            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemTelaAtual.MatchTemplate(objImagemTemplate, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                Dictionary<double, Point> MatchesMax = new Dictionary<double, Point>();
                Dictionary<double, Point> MatchesMin = new Dictionary<double, Point>();

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
        
        public Bitmap tratarLadoImagemParaBusca(Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle AreaBusca)
        {
            Bitmap objTemplate = new Bitmap(@"./x.bmp");

            Bitmap telaCheia = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela();
            float anguloRotacao = 315f;
            telaCheia = ImagemTransformacao.obterInstancia().redimencionarImagem(telaCheia, telaCheia.Width / 2, telaCheia.Height);
            telaCheia = ImagemTransformacao.obterInstancia().rotacionarImagem(telaCheia, anguloRotacao);
            telaCheia = ImagemTransformacao.obterInstancia().extrairRegiaoImagem(telaCheia, objRegiaoImagem, AreaBusca);

            // @todo terminar de implementar esse método.
            // Basicamente a idéia dele é que as imagens sejam encontradas dinamicamente e seja utilizado apenas uma imagem já
            // tratada, redimencionada e girada para o lado esquerdo e direito, encontrando os números por eliminação.

            if (objRegiaoImagem == Imagem.EnumRegiaoImagem.LADO_ESQUERDO)
            {
                this.telaRotacionadaLadoEsquerdo = telaCheia;
                telaCheia.Dispose();
                return this.telaRotacionadaLadoEsquerdo;
            }
            else
            {
                this.telaRotacionadaLadoDireito = telaCheia;
                telaCheia.Dispose();
                return this.telaRotacionadaLadoDireito;
            }

            
        }
    }
}
