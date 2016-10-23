using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class Chilli : ARecurso, IFazendeiro
    {
        public Chilli() : base("Chilli", 90, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\chilli.png") {}
    }
}
