using System.Collections.Generic;

namespace Model.Base
{
    public abstract class ARecurso
    {
        public string Nome;
        public int Level;
        public int Tempo;
        public string ImagemExibicao;
        public List<string> ListaImagens = new List<string>();
        public string Caption;

        public ARecurso(string Nome, int Level, int Tempo, string ImagemExibicao)
        {
            this.Nome = Nome;
            this.Level = Level;
            this.Tempo = Tempo;
            this.ImagemExibicao = ImagemExibicao;
            this.Caption = this.Nome + " | Level: " + this.Level.ToString();
            this.ListaImagens.Add(ImagemExibicao);
        }
    }
}
