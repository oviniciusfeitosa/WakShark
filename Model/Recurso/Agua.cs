using Model.Recurso.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Recurso
{
    public class Agua : ARecurso
    {
        public Agua() : base("Água", 0, 1000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\agua.png") { }
    }
}
