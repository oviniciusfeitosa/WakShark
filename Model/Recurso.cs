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
            { "Trigo | Level 0", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\trigo.png" },
            { "Cevada | Level 20", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\cevada.png" },
            { "Aveia | Level 35", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\aveia.png" },
            { "Centeio | Level 50", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\centeio.png" }
        };
    }
}
