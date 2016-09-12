using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Recurso
    {
        public static List<Recurso> Recursos = new List<Recurso>();

        public string Nome;
        public int Level;
        public int Tempo;
        public string Imagem;
        public string Caption;

        public Recurso(string nome, int level, int tempo, string imagem)
        {
            this.Nome = nome;
            this.Level = level;
            this.Tempo = tempo;
            this.Imagem = imagem;
            this.Caption = Nome + " | Level: " + Level.ToString();
        }

        public static void inicializarRecursos()
        {
            Recursos = new List<Recurso>();
            Recursos.Add(new Recurso("Água", 0, 1000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\agua.png"));
            Recursos.Add(new Recurso("Trigo", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\trigo.png"));
            Recursos.Add(new Recurso("Cevada", 20, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\cevada.png"));
            Recursos.Add(new Recurso("Aveia", 35, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\aveia.png"));
            Recursos.Add(new Recurso("Centeio", 50, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\centeio.png"));
        }

        public static Recurso obterRecurso(string caption)
        {
            foreach (Recurso r in Recursos)
            {
                if (r.Caption == caption)
                {
                    return r;
                }
            }
            return null;
        }

    }
}
