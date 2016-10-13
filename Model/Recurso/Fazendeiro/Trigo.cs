using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class Trigo : ARecurso, IFazendeiro
    {
        public Trigo() : base("Trigo", 0, 1800, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\trigo.png") {}
    }
}
