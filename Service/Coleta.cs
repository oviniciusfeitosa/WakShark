
using ModelTela = Model.Tela;
using Service;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Threading;
using Common.Lib;
using Common;

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
            return ImagemBusca.obterInstancia().procurarImagemPorTemplateComAcao(caminhoTemplateRecurso, acaoColetar);
        }
        
        public static bool acaoColetar(Model.Tela objModelTela)
        {
            try
            {
                /*
                 * @TODO: Comentei esse trecho do código, porque nem sempre o posicionamento do pixel será "700,100". 
                 * Uma maneira mais eficaz é verificando se ao lado da barra de hp já está aparecendo o ícone de batalha (duas espadas).*/
                System.Drawing.Color cBatalha = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel().GetPixel(700, 100);
                if (Common.ColorHelper.HexConverter(cBatalha) == "#000000")
                {

                    BatalhaAntiBOT.acaoIniciarBatalha(objModelTela);
                    Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
                }
                

                Win32.posicionarMouse(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Win32.clicarBotaoDireito(objModelTela.eixoHorizontal, objModelTela.eixoVertical);

                Thread.Sleep(1100);

                Win32.posicionarMouse(objModelTela.eixoHorizontal + 35, objModelTela.eixoVertical - 35);
                Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal + 35, objModelTela.eixoVertical - 35);

                Thread.Sleep(6000);
                
                /**
                 */
                //MessageBox.Show("Achou");
                //Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }

    }
}
