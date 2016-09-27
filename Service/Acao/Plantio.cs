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
                InputSimulator objInputSimulator = new InputSimulator();
                objInputSimulator.Keyboard.KeyDown(VirtualKeyCode.SHIFT);
                objInputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1);
                objInputSimulator.Keyboard.KeyUp(VirtualKeyCode.SHIFT);
                System.Threading.Thread.Sleep(20);
                Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
                System.Threading.Thread.Sleep(4500);
                objInputSimulator.Keyboard.KeyPress(VirtualKeyCode.VK_1);
                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
            return false;
        }
    }
}
