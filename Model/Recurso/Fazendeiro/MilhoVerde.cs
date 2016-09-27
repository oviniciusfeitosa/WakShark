using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class MilhoVerde : ARecurso, IFazendeiro
    {
        public MilhoVerde() : base("MilhoVerde", 70, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\milho_verde.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\milho_verde_tipo-2.png");
        }
    }
}
