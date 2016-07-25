
using ModelTela = Model.Tela;
using Service;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Threading;
using Common.Lib;

namespace Service
{
    public class Coleta
    {
        #region Singleton
        private static Coleta objColeta;

        public static Coleta obterInstancia() {

            if(Coleta.objColeta == null)
            {
                Coleta.objColeta = new Coleta();
            }
            return Coleta.objColeta;
        }
        #endregion

        public bool coletar(string caminhoTemplateRecurso)
        {
            return TelaPixel.obterInstancia().procurarImagemPorTemplateComAcao(caminhoTemplateRecurso, acaoColetar);
        }
        
        public static bool acaoColetar(Model.Tela objModelTela)
        {
            try
            {
                Win32.posicionarMouse(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Win32.clicarBotaoDireito(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Thread.Sleep(1000);

                Win32.posicionarMouse(objModelTela.eixoHorizontal - 35, objModelTela.eixoVertical - 35);
                Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal - 35, objModelTela.eixoVertical - 35);



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

    }
}
