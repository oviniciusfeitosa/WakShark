using Model.Base;

namespace Model.Recurso.Fazendeiro
{
    public class Aveia : ARecurso, IFazendeiro
    {
        public Aveia() : base("Aveia", 35, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\aveia.png") {}
    }
}
