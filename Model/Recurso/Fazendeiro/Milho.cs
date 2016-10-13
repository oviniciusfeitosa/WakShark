using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class Milho : ARecurso, IFazendeiro
    {
        public Milho() : base("Milho", 70, 1800, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\milho.png") {}
    }
}
