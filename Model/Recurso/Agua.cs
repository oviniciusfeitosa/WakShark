using Model.Base;

namespace Model.Recurso
{
    public class Agua : ARecurso, IFazendeiro
    {
        public Agua() : base("Água", 0, 1000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\agua.png") { }
    }
}
