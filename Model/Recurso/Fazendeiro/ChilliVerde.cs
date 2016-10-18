using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class ChilliVerde : ARecurso, IFazendeiro
    {
        public ChilliVerde() : base("ChilliVerde", 90, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\chilli_verde.png") {}
    }
}
