using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tela
    {
        public int eixoHorizontal { get; set; }
        public int eixoVertical { get; set; }
        public string pixel { get; set; }
        public Color pixelColor { get; set; }

        public Tela()
        {
        }

        public Tela(int eixoHorizontal, int eixoVertical)
        {
            this.eixoHorizontal = eixoHorizontal;
            this.eixoVertical = eixoVertical;
        }

        public Tela (int eixoHorizontal, int eixoVertical, string pixel)
        {
            this.eixoHorizontal = eixoHorizontal;
            this.eixoVertical = eixoVertical;
            this.pixel = this.pixel;
        }

        public Tela(int eixoHorizontal, int eixoVertical, Color pixelColor)
        {
            this.eixoHorizontal = eixoHorizontal;
            this.eixoVertical = eixoVertical;
            this.pixelColor = pixelColor;
        }
    }
}
