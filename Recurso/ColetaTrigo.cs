using System.Drawing;
using Gma.System.MouseKeyHook;
using Model;
using System.Collections.Generic;
using System.Windows.Forms;
using Service.Lib;
using Service;
using System.Threading;

namespace Service
{
    class ColetaTrigo
    {
        public static bool buscar(Model.Tela objModelTela)
        {
            try
            {
                if (ColetaTrigo.isPossuiTrigoNoturno(objModelTela))
                {
                    //MessageBox.Show("Achou!");
                    return true;
                }
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
            return false;
        }

        public static bool acaoColetar(Model.Tela objModelTela)
        {
            try
            {
                Win32.posicionarMouse(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Win32.clicarBotaoDireito(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Thread.Sleep(1000);

                Win32.posicionarMouse(objModelTela.eixoHorizontal - 25, objModelTela.eixoVertical - 25);
                Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal - 25, objModelTela.eixoVertical - 25);



                /**
                 * Thread.Sleep(5000);
                 * 
                 * 
                 * ColetaAntiBatalha
                 * 
                 * APÓS CLICAR DEVE SER VARRIDA NOVAMENTE A TELA OU MESMO UTILIZAR O MESMO QUE É UTILIZADO NO "MOUSE MOVE"
                 * PARA CONSEGUIR OBTER SE ALGUNS PIXELS PARA ESQUERDA OU DIREITA, EXISTEM AS "SETINHAS" QUE TEM QUANDO ALGUM MONSTRO ESTÁ POR PERTO.
                 * 
                 * CASO EXISTA A SETINHA:
                 * 
                 * - CLICAR COM O BOTÃO ESQUERDO ( PARA QUE MUDE PARA A COLHEITA AO INVÉS DA LUTA, QUE SEMPRE VEM PRIMEIRO ).
                 * - EXECUTAR ROTINA PADRÃO PARA CLICAR E AGUARDAR.
                 * 
                 * [ OBS ] > VERIFICAR QUANTO TEMPO É USADO PARA FINALIZAR A ATIVIDADE.
                 */
                MessageBox.Show("Achou");
                //Batalha.obterInstancia().validarBatalha(Batalha.enumTiposBatalha.AntiBOT);
                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }

        public static bool isPossuiTrigoNoturno(Model.Tela objModelTela)
        {
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, "#FFCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 2, objModelTela.eixoVertical + 5, "#CCCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 4, objModelTela.eixoVertical + 9, "#FFCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 8, objModelTela.eixoVertical + 8, "#999933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 19, objModelTela.eixoVertical + 2, "#FFCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 20, objModelTela.eixoVertical - 2, "#CC9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 21, objModelTela.eixoVertical - 1, "#CC9900")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 28, objModelTela.eixoVertical + 12, "#CC9933")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 34, objModelTela.eixoVertical + 9, "#FFCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 32, objModelTela.eixoVertical + 5, "#FFCC33")) return false;
            if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal + 35, objModelTela.eixoVertical + 6, "#CC9900")) return false;

            return true;
        }
    }
}
