using Common;
using Common.Lib;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Service.Acao
{
    public class Plantio : AViewModelColeta
    {
        public override bool executarAcao()
        {
            try
            {
                this.pressionarTeclaAtalho();
                Random objRandomNumber = new Random();
                Win32.clicarBotaoEsquerdo(objMatch.Location.X + objRandomNumber.Next(2, 5), objMatch.Location.Y + objRandomNumber.Next(2, 5));
                System.Threading.Thread.Sleep(3000);
                Win32.clicarBotaoDireito(objMatch.Location.X + objRandomNumber.Next(2, 5), objMatch.Location.Y + objRandomNumber.Next(2, 5));

                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
            return false;
        }

        private void pressionarTeclaAtalho() {
            InputSimulator objInputSimulator = new InputSimulator();
            System.Threading.Thread.Sleep(125);
            objInputSimulator.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
            System.Threading.Thread.Sleep(125);
            objInputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1);
            System.Threading.Thread.Sleep(125);
            objInputSimulator.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
            System.Threading.Thread.Sleep(125);
        }
    }
}
