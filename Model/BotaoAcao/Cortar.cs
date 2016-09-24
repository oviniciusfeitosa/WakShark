using Model.Base;
namespace Model.BotaoAcao
{
    public class Cortar : ABotaoAcao
    {
        public Cortar() : base("Cortar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\cortar.png") {}
        
    }
}
