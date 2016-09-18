using Model.Base;

namespace Model.Acao
{
    public class Fechar : AAcao
    {
        public Fechar() : base("Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png") {}
    }
}
