using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Plantio : ABotaoAcao, IGlobal
    {
		public Plantio() : base("Plantio", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\plantio.png") {}
    }
}
