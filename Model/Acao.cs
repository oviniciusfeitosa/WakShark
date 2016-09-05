using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Acao
    {
        public Dictionary<string, string> tiposAcoes = new Dictionary<string, string> {
            { "Colher", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png" },
            { "Ceifar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png" },
            { "Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png" }
        };
    }
}
