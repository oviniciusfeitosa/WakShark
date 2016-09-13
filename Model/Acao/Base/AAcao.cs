using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Acao.Base
{
    public abstract class AAcao
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }

        public AAcao(string nome, string imagem)
        {
            this.Nome = nome;
            this.Imagem = imagem;
        }
    }
}
