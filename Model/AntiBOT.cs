using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AntiBOT
    {
        public Dictionary<string, string> numerosMatch = new Dictionary<string, string> {
            { "Numero1", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero1.png" },
            { "Numero2", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero2.png" },
            { "Numero3", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero3.png" },
            { "Numero4", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero4.png" },
            { "Numero5", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero5.png" },
            { "Numero6", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero6.png" },
            { "Numero7", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero7.png" },
            { "Numero8", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\antibot\numero8.png" }
        };
    }
}
