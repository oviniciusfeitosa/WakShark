using Model.Base;
namespace Model.Recurso
{
    public class Milho : ARecurso, IFazendeiro
    {
        public Milho() : base("Milho", 70, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\milho.png") {}
    }
}
