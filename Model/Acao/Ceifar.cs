using Model.Acao.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Acao
{
    public class Ceifar : AAcao
    {
        public Ceifar() : base("Ceifar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png") {}
    }
}
