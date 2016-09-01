using Common;
using Common.Lib;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
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
                MatchesGato.Add(1, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero1.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(2, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero2.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(3, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero3.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(4, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero4.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(5, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero5.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(6, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero6.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(7, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero7.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                MatchesGato.Add(8, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(Application.StartupPath + @"/numero8.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                Application.DoEvents();

                List<Model.Match> Verificar = new List<Model.Match>();
                List<Model.Match> NaoEncontrados = new List<Model.Match>();

                
                //Buscar os números até encontrar pelo menos 3 do lado do gato
                    Verificar.Clear();
                    foreach (Model.Match m in MatchesGato.Values)
                    {
                        if (m.Semelhanca > 0)
                        {
                            Verificar.Add(m);
                        }
                        else
                        {
                            NaoEncontrados.Add(m);
                        }
                    }

                    //if (Verificar.Count < 3)
                    //{
                    //    for (int i = 0; i < NaoEncontrados.Count; i++)
                    //    {
                    //        MatchesGato[NaoEncontrados[i].Numero] = this.buscarNumeroPorTemplateRotacionado(@"./numero" + NaoEncontrados[i].Numero.ToString() + ".png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato);
                    //    }
                    //}

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
                    Model.Match matchClicar = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(@"./numero" + objMatch.Numero.ToString() + ".png", Imagem.EnumRegiaoImagem.RETANGULO, RectPersonagem);

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
                //System.Windows.Forms.SendKeys.SendWait("{ESC}");
               Model.Match match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\batalhaAntiBOT\fechar.png", Imagem.EnumRegiaoImagem.RETANGULO, new Rectangle(50, 50, Screen.PrimaryScreen.Bounds.Width - 100, Screen.PrimaryScreen.Bounds.Height - 100));
                if (match.Semelhanca > 0.9)
                {
                    acaoFechar(new Model.Tela(match.Location.X, match.Location.Y));
                }

            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
            return true;
        }

        public static bool acaoFechar(Model.Tela objModelTela)
        {
            try
            {
                Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal + 5, objModelTela.eixoVertical + 5);
                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            return ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateNumero, objRegiaoImagem, new Rectangle(0, 0, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height));
        }
 
        public Bitmap tratarLadoImagemParaBusca(Imagem.EnumRegiaoImagem objRegiaoImagem, Rectangle AreaBusca)
        {
            Bitmap objTemplate = new Bitmap(@"./x.bmp");

            Bitmap telaCheia = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela();
            float anguloRotacao = 315f;
            telaCheia = ImagemTransformacao.obterInstancia().redimensionarImagem(telaCheia, telaCheia.Width / 2, telaCheia.Height);
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
