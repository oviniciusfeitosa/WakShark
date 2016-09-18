using Model.Base;

namespace Model.Recurso
{
    public class Aveia : ARecurso, IFazendeiro
    {
        public Aveia() : base("Aveia", 35, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\aveia.png") {}
    }
}
