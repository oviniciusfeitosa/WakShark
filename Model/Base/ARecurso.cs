namespace Model.Base
{
    public abstract class ARecurso
    {
        public string Nome;
        public int Level;
        public int Tempo;
        public string Imagem;
        public string Caption;

        public ARecurso(string Nome, int Level, int Tempo, string Imagem)
        {
            this.Nome = Nome;
            this.Level = Level;
            this.Tempo = Tempo;
            this.Imagem = Imagem;
            this.Caption = this.Nome + " | Level: " + this.Level.ToString();
        }
    }
}
