using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Tela
    {
        #region Singleton
        private static Tela objTela;

        public static Tela obterInstancia()
        {
            if (Tela.objTela == null)
            {
                Tela.objTela = new Tela();
            }
            return Tela.objTela;
        }
        #endregion


    }
}
