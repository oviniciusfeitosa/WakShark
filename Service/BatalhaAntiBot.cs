using Common;
using Common.Lib;
using Emgu.CV;
using Emgu.CV.Structure;
using Model;
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

        public enum numeroMarcacao
        {
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
                Size bounds = Proporcao.obterProporcao();

                if (ImagemCaptura.obterInstancia().objBitmap != null) ImagemCaptura.obterInstancia().objBitmap.Dispose();
                Bitmap objBitmap = ImagemCaptura.obterInstancia().obterImagemTela(true);

                int eixoHorizontal = 275;
                int eixoVertical = 405;
                int larguraEAlturaRetangulo = 107;

                Rectangle retanguloPersonagem = new Rectangle(eixoHorizontal, eixoVertical, larguraEAlturaRetangulo, larguraEAlturaRetangulo);

                eixoHorizontal = 448;
                Rectangle retanguloGato = new Rectangle(eixoHorizontal, eixoVertical, larguraEAlturaRetangulo, larguraEAlturaRetangulo);

                Dictionary<int, Model.Match> MatchesGato = new Dictionary<int, Model.Match>();
                AntiBOT objAntiBOT = new AntiBOT();
                for (int numeroMatch = 1; numeroMatch < 8; numeroMatch++)
                {
                    MatchesGato.Add(numeroMatch, ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(
                        objAntiBOT.numerosMatch["Numero" + numeroMatch],
                        Imagem.EnumRegiaoImagem.RETANGULO,
                        retanguloGato
                        )
                    );
                }
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
                System.Threading.Thread.Sleep(1100);
                foreach (Model.Match objMatch in Clicar)
                {

                    //System.Threading.Thread.Sleep(2000);
                    Model.Match matchClicar = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(objAntiBOT.numerosMatch["Numero" + objMatch.Numero.ToString()], Imagem.EnumRegiaoImagem.RETANGULO, retanguloPersonagem);

                    System.Windows.Forms.SendKeys.SendWait("1");
                    System.Threading.Thread.Sleep(800);
                    //Common.Lib.Win32.posicionarMouse(matchClicar.Location.X, matchClicar.Location.Y);
                    Common.Lib.Win32.clicarBotaoEsquerdo(matchClicar.Location.X, matchClicar.Location.Y);

                    /*System.Windows.Forms.SendKeys.SendWait("1");
                    System.Threading.Thread.Sleep(1000);
                    Common.Lib.Win32.clicarBotaoEsquerdo(objMatch.Location.X, objMatch.Location.Y);*/
                }

                Application.DoEvents();

                System.Threading.Thread.Sleep(5000);
                //System.Windows.Forms.SendKeys.SendWait("{ESC}");


            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
            return true;
        }

        public Model.Match buscarNumeroPorTemplateRotacionado(string caminhoTemplateNumero, Imagem.EnumRegiaoImagem objRegiaoImagem)
        {
            return ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateNumero, objRegiaoImagem, new Rectangle(0, 0, Proporcao.Width, Proporcao.Height));
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
