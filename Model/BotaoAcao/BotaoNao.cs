using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class BotaoNao : ABotaoAcao, IGlobal
    {
		public BotaoNao() : base("BotaoNao", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\botao_nao.png") {}
    }
}