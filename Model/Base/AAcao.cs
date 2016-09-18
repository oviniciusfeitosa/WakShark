namespace Model.Base
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
