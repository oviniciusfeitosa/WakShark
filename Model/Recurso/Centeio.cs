using Model.Base;
namespace Model.Recurso
{
    public class Centeio : ARecurso, IFazendeiro
    {
        public Centeio() : base("Centeio", 50, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\centeio.png") {}
    }
}
