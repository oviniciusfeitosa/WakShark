using Model.Acao.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Acao
{
    public class Colher : AAcao
    {
        public Colher() : base("Colher", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png"){}
    }
}
