using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static bool buscarIconeInicioBatalha(Model.Tela objModelTela)
        {
            // Somente se existei o ícone de inicio batalha que a batalha será iniciada
            return false;
        }

        public static bool acaoIniciarBatalha(Model.Tela objModelTela)
        {
            // Faça algo.
            return true;
        }

        public static BatalhaAntiBOT.numeroMarcacao identificarMarcacoes(Model.Tela objModelTela)
        {
            if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoUm(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Um;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoDois(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Dois;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoTres(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Tres;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoQuatro(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Quatro;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoCinco(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Cinco;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoSeis(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Seis;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoSete(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Sete;
            else if (BatalhaAntiBOT.obterInstancia().isPossuiNumeracaoOito(objModelTela)) return BatalhaAntiBOT.numeroMarcacao.Oito;
            return BatalhaAntiBOT.numeroMarcacao.Vazio;
        }

        public static Dictionary<BatalhaAntiBOT.numeroMarcacao, List<Model.Tela>> armazenarMarcacoes
            (
                Model.Tela objModelTela, 
                BatalhaAntiBOT.numeroMarcacao  enumNumeroMarcacao, 
                Dictionary<
                    BatalhaAntiBOT.numeroMarcacao, 
                    List<Model.Tela>
                > objDicionarioMarcacoes
            )
        {
            if (objDicionarioMarcacoes == null) objDicionarioMarcacoes = new Dictionary<BatalhaAntiBOT.numeroMarcacao, List<Model.Tela>>();
            if (enumNumeroMarcacao != BatalhaAntiBOT.numeroMarcacao.Vazio) objDicionarioMarcacoes[enumNumeroMarcacao].Add(objModelTela);
            return objDicionarioMarcacoes;
        }

        public bool isPossuiNumeracaoUm(Model.Tela objModelTela) {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 3, objModelTela.eixoVertical + 3, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 0, objModelTela.eixoVertical + 3, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 22, objModelTela.eixoVertical - 3, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 30, objModelTela.eixoVertical + 6, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 17, objModelTela.eixoVertical + 11, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 25, objModelTela.eixoVertical + 9, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 38, objModelTela.eixoVertical + 5, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 30, objModelTela.eixoVertical - 1, "#996633")) return false;
            return true;
        }

        public bool isPossuiNumeracaoDois(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 3, objModelTela.eixoVertical + 4, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 5, objModelTela.eixoVertical + 5, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 2, objModelTela.eixoVertical + 0, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 0, objModelTela.eixoVertical + 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 4, objModelTela.eixoVertical + 17, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 1, objModelTela.eixoVertical + 18, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 5, objModelTela.eixoVertical + 20, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 8, objModelTela.eixoVertical + 19, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 16, objModelTela.eixoVertical + 9, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 21, objModelTela.eixoVertical + 10, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 15, objModelTela.eixoVertical + 14, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 27, objModelTela.eixoVertical + 14, "#993333")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 32, objModelTela.eixoVertical + 14, "#993333")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 23, objModelTela.eixoVertical + 11, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 31, objModelTela.eixoVertical + 9, "#996633")) return false;

            return true;
        }

        public bool isPossuiNumeracaoTres(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 0, objModelTela.eixoVertical + 5, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 2, objModelTela.eixoVertical + 13, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 1, objModelTela.eixoVertical + 18, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 0, objModelTela.eixoVertical + 23, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 4, objModelTela.eixoVertical + 26, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 15, objModelTela.eixoVertical + 19, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 16, objModelTela.eixoVertical + 6, "#993333")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 20, objModelTela.eixoVertical + 13, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 18, objModelTela.eixoVertical + 19, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 24, objModelTela.eixoVertical + 17, "#993333")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 32, objModelTela.eixoVertical + 10, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal - 3, objModelTela.eixoVertical - 4, "#996633")) return false;

            return true;
        }

        public bool isPossuiNumeracaoQuatro(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 6, objModelTela.eixoVertical + 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 10, objModelTela.eixoVertical + 1, "#FF9933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 27, objModelTela.eixoVertical - 12, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 29, objModelTela.eixoVertical - 9, "#FF9933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 53, objModelTela.eixoVertical + 1, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 49, objModelTela.eixoVertical - 1, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 52, objModelTela.eixoVertical + 3, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 35, objModelTela.eixoVertical + 12, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 30, objModelTela.eixoVertical + 15, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 27, objModelTela.eixoVertical + 11, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 14, objModelTela.eixoVertical + 6, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 16, objModelTela.eixoVertical - 9, "#996633")) return false;

            return true;
        }

        public bool isPossuiNumeracaoCinco(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 8, objModelTela.eixoVertical - 8, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 24, objModelTela.eixoVertical - 13, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 42, objModelTela.eixoVertical - 9, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 52, objModelTela.eixoVertical - 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 45, objModelTela.eixoVertical + 6, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 27, objModelTela.eixoVertical + 13, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 24, objModelTela.eixoVertical + 15, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 11, objModelTela.eixoVertical + 8, "#993333")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 25, objModelTela.eixoVertical + 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 39, objModelTela.eixoVertical - 10, "#996633")) return false;

            return true;
        }

        public bool isPossuiNumeracaoSeis(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 16, objModelTela.eixoVertical - 7, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 34, objModelTela.eixoVertical - 17, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 46, objModelTela.eixoVertical - 13, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 49, objModelTela.eixoVertical - 11, "#996633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 67, objModelTela.eixoVertical - 1, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 65, objModelTela.eixoVertical + 1, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 54, objModelTela.eixoVertical + 7, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 48, objModelTela.eixoVertical + 5, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 47, objModelTela.eixoVertical + 9, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 39, objModelTela.eixoVertical + 13, "#FF9933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 31, objModelTela.eixoVertical + 13, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 38, objModelTela.eixoVertical + 16, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 15, objModelTela.eixoVertical + 5, "#996633")) return false;

            return true;
        }

        public bool isPossuiNumeracaoSete(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FFCC00")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 21, objModelTela.eixoVertical - 9, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 37, objModelTela.eixoVertical - 17, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 64, objModelTela.eixoVertical + 0, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 47, objModelTela.eixoVertical + 9, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 30, objModelTela.eixoVertical + 16, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 30, objModelTela.eixoVertical + 1, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 31, objModelTela.eixoVertical - 5, "#CC6633")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 36, objModelTela.eixoVertical - 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 47, objModelTela.eixoVertical + 9, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 62, objModelTela.eixoVertical + 2, "#FF9900")) return false;

            return true;
        }

        public bool isPossuiNumeracaoOito(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 2, objModelTela.eixoVertical + 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 14, objModelTela.eixoVertical - 6, "#FFCC00")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 17, objModelTela.eixoVertical - 6, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 29, objModelTela.eixoVertical - 13, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 32, objModelTela.eixoVertical - 11, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 66, objModelTela.eixoVertical + 0, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 62, objModelTela.eixoVertical + 3, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 60, objModelTela.eixoVertical + 0, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 49, objModelTela.eixoVertical + 10, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 45, objModelTela.eixoVertical + 10, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 34, objModelTela.eixoVertical + 21, "#FFCC00")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 30, objModelTela.eixoVertical + 21, "#FFCC00")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 18, objModelTela.eixoVertical + 7, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 21, objModelTela.eixoVertical + 6, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 38, objModelTela.eixoVertical - 2, "#FF9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 42, objModelTela.eixoVertical - 5, "#FF9900")) return false;

            return true;
        }
    }
}
