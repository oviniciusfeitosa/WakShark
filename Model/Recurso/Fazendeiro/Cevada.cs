using Model.Base;

namespace Model.Recurso.Fazendeiro
{
    public class Cevada : ARecurso, IFazendeiro
    {
        public Cevada() : base("Cevada", 20, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\cevada.png") {}
    }
}
