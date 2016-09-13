using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recurso.Base;

namespace Model.Recurso
{
    public class Centeio : ARecurso
    {
        public Centeio() : base("Centeio", 50, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\centeio.png"){}
    }
}
