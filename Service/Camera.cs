using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Service
{
    public class Camera
    {

        #region Singleton
        private static Camera objCamera;

        public static Camera obterInstancia()
        {
            if (Camera.objCamera == null)
            {
                Camera.objCamera = new Camera();
            }
            return Camera.objCamera;
        }
        #endregion

        public void padronizarDistanciaCamera()
        {
            InputSimulator objInputSimulator = new InputSimulator();
            for (int zoomIn = 1; zoomIn < 15; zoomIn++)
            {
                objInputSimulator.Keyboard.KeyPress(VirtualKeyCode.ADD);
                System.Threading.Thread.Sleep(20);
            }
            for (int zoomOut = 1; zoomOut < 14; zoomOut++)
            {
                objInputSimulator.Keyboard.KeyPress(VirtualKeyCode.SUBTRACT);
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
