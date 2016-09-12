using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Acao
    {

        public static List<Acao> Acoes = new List<Acao>();

        public string Nome { get; set; }
        public string Imagem { get; set; }

        public Acao(string nome, string imagem)
        {
            this.Nome = nome;
            this.Imagem = imagem;
        }

        public static void inicializarAcoes()
        {
            Acoes = new List<Acao>();
            Acoes.Add(new Acao("Colher", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png"));
            Acoes.Add(new Acao("Ceifar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png"));
            Acoes.Add(new Acao("Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png"));
        }

        public static Acao obterAcao(String nome)
        {
            foreach (Acao a in Acoes)
            {
                if (a.Nome.ToUpper() == nome.ToUpper())
                    return a;
            }
            return null;
        }
    }
}
