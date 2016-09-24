namespace Model.Base
{
    public abstract class ABotaoAcao
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }

		public ABotaoAcao(string nome, string imagem)
        {
            this.Nome = nome;
            this.Imagem = imagem;
        }
    }
}
