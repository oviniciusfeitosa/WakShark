using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Cortar : ABotaoAcao, IColheita
    {
        public Cortar() : base("Cortar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\cortar.png") {}
        
    }
}
