using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class CenteioVerde : ARecurso, IFazendeiro
    {
        public CenteioVerde() : base("CenteioVerde", 50, 1800, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\centeio_verde.png") {}
    }
}
