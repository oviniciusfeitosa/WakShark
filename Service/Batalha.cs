using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using Common;

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

        public enum EnumTiposBatalha
        {
            AntiBOT,
            Normal
        };

        public bool iniciar(EnumTiposBatalha objEnumTipoBatalha)
        {
            Camera.obterInstancia().padronizarDistanciaCamera();
            switch (objEnumTipoBatalha)
            {
                case EnumTiposBatalha.AntiBOT:
                    BatalhaAntiBOT.obterInstancia().acaoIniciarBatalha();
                    break;
                case EnumTiposBatalha.Normal:
                    // Faça Algo
                    break;
                default:
                    break;
            }
            return true;
        }



    }
}
