using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recurso.Base;

namespace Model.Recurso
{
    public class Trigo : ARecurso
    {
        public Trigo() : base("Trigo", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\trigo.png") {}
    }
}
