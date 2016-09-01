using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recurso
    {
        public Dictionary<string, string> tiposRecurso = new Dictionary<string, string> {
            { "Trigo", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\trigo.png" },
            { "Cevada", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\cevada.png" },
            { "Centeio", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\centeio.png" },
            { "Aveia", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\aveia.png" }
        };
    }
}
