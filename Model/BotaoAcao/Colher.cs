using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Colher : ABotaoAcao, IColheita
    {
        public Colher() : base("Colher", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png"){}
    }
}
