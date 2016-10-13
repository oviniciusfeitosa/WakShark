using Model.Base;

namespace Model.Recurso.Fazendeiro
{
    public class Aveia : ARecurso, IFazendeiro
    {
        public Aveia() : base("Aveia", 35, 1800, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\aveia.png") {}
    }
}
