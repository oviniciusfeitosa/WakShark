using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recurso.Base;

namespace Model.Recurso
{
    public class Cevada : ARecurso
    {
        public Cevada() : base("Cevada", 20, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\cevada.png") {}
    }
}
