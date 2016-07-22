using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTela = Model.Tela;

namespace Service
{
    public class Batalha
    {
        #region singleton
        private static Batalha objBatalha;

        public static Batalha obterInstancia()
        {
            if (Batalha.objBatalha == null)
            {
                Batalha.objBatalha = new Batalha();
            }
            return Batalha.objBatalha;
        }
        #endregion

        public enum enumTiposBatalha
        {
            AntiBOT,
            Normal
        };

        public bool validarBatalha(enumTiposBatalha objEnumTiposBatalha)
        {
            switch (objEnumTiposBatalha)
            {
                case enumTiposBatalha.AntiBOT:
                    //return ServiceTela.obterInstancia().procurarPixel(BatalhaAntiBOT.buscarIconeInicioBatalha, BatalhaAntiBOT.acaoIniciarBatalha);
                    break;
                case enumTiposBatalha.Normal:
                    // Faça Algo
                    break;
                default:
                    break;
            }
            return true;
        }
        
    }
}
