using Model.Base;

namespace Model.Acao
{
    public class Cortar : AAcao
    {
        public Cortar() : base("Cortar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\cortar.png") {}
    }
}
