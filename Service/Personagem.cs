using Common.Lib;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public class Personagem
    {
        #region Singleton
        private static Personagem objPersonagem;

        public static Personagem obterInstancia()
        {

            if (Personagem.objPersonagem == null)
            {
                Personagem.objPersonagem = new Personagem();
            }
            return Personagem.objPersonagem;
        }
        #endregion

        public void movimentarRandomicamente() {
            Random objRandomNumber = new Random();
            /*int eixoHorizontalRandomico = objRandomNumber.Next((int)(Screen.PrimaryScreen.Bounds.Width / 2) - 100, (int)(Screen.PrimaryScreen.Bounds.Width / 2) + 100);
            int eixoVertucalRandomico = objRandomNumber.Next((int)(Screen.PrimaryScreen.Bounds.Height / 2) - 100, (int)(Screen.PrimaryScreen.Bounds.Height / 2) + 100);*/

            Size bounds = Proporcao.obterProporcao();
            int variancia = 300;
            int eixoHorizontalRandomico = objRandomNumber.Next((int)(bounds.Width / 2) - variancia, (int)(bounds.Width / 2) + variancia);
            int eixoVertucalRandomico = objRandomNumber.Next((int)(bounds.Height / 2) - variancia, (int)(bounds.Height / 2) + variancia);
            Win32.clicarBotaoEsquerdo(eixoHorizontalRandomico, eixoVertucalRandomico);
        }
    }
}
