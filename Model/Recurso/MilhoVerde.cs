using Model.Base;
namespace Model.Recurso
{
    public class MilhoVerde : ARecurso, IFazendeiro
    {
        public MilhoVerde() : base("MilhoVerde", 70, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\milho_verde.png") {}
    }
}
