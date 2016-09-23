namespace Model.Base
{
    public abstract class AAcao
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
		public abstract bool executarAcao(Match objMatch, int Tempo);

		public AAcao(string nome, string imagem, string tipoAcao)
        {
            this.Nome = nome;
            this.Imagem = imagem;
        }
    }
}
