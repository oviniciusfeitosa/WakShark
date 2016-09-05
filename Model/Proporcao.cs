using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Proporcao
    {
        /*public int Width { get; set; }
        public int Heigth { get; set; }

        public Proporcao(int Width, int Height)
        {
            this.Width = Width;
            this.Heigth = Heigth;
        }*/

        public const int Width = 1600;
        public const int Height = 900;

        public static Size obterProporcao()
        {
            return new Size(Proporcao.Width, Proporcao.Height);
        }
    }
}
