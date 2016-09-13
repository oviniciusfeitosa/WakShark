using Model.Acao.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Acao
{
    public class Fechar : AAcao
    {
        public Fechar() : base("Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png") {}
    }
}
