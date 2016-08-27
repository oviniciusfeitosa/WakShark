using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Match
    {

        public Point Location;
        public double Semelhanca;
        public int Numero;

        public Match()
        {
            this.Location = new Point();
            Semelhanca = 0d;
            Numero = 0;
        }

        public Match(Point Location, double Semelhanca, int Numero)
        {
            this.Location = Location;
            this.Semelhanca = Semelhanca;
            this.Numero = Numero;
        }






    }
}
