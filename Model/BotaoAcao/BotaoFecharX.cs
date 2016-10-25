using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class BotaoFecharX : ABotaoAcao, IGlobal
    {
		public BotaoFecharX() : base("Botão Fechar X", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar_x.png") {}
    }
}
