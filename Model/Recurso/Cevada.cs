using Model.Base;

namespace Model.Recurso
{
    public class Cevada : ARecurso, IFazendeiro
    {
        public Cevada() : base("Cevada", 20, 2700, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\cevada.png") {}
    }
}
