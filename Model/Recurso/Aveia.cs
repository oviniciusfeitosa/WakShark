using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recurso.Base;

namespace Model.Recurso
{
    public class Aveia : ARecurso
    {
        public Aveia() : base("Aveia", 35, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\aveia.png") {}
    }
}
