using System.Collections.Generic;

namespace Model.Base
{
    public abstract class ARecurso
    {
        public string Nome { get; set; }
        public int Level { get; set; }
        public int Tempo { get; set; }
        public string ImagemExibicao { get; set; }
        public List<string> ListaImagens { get; set; }
        public string Caption { get; set; }

        public ARecurso(string Nome, int Level, int Tempo, string ImagemExibicao)
        {
            ListaImagens = new List<string>();
            this.Nome = Nome;
            this.Level = Level;
            this.Tempo = Tempo;
            this.ImagemExibicao = ImagemExibicao;
            this.Caption = this.Nome + " | Level: " + this.Level.ToString();
            this.ListaImagens.Add(ImagemExibicao);
        }
    }
}
