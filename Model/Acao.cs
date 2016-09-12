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
        public uint Tempo { get; set; }
        public string Imagem { get; set; }

        public Acao(string nome, uint tempo, string imagem)
        {
            this.Nome = nome;
            this.Tempo = tempo;
            this.Imagem = imagem;
        }

        public static void inicializarAcoes()
        {
            Acoes = new List<Acao>();
            Acoes.Add(new Acao("Colher", 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png"));
            Acoes.Add(new Acao("Ceifar", 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png"));
            Acoes.Add(new Acao("Fechar", 1000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png"));
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
