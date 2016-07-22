using Service.Lib;
using ModelTela = Model.Tela;
using Service;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Threading;

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

        public bool coletar(string recurso)
        {
            switch (recurso)
            {
                case "Trigo":
                    bool isConsultaParada = Service.TelaPixel.obterInstancia().procurarPixel(ColetaTrigo.buscar, ColetaTrigo.acaoColetar);
                    break;
                case "Cevada":
                    break;
                case "Aveia":
                    break;
                default:
                    break;
            }
            return true;
        }

        

    }
}
