using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class BotaoFechar : ABotaoAcao, IGlobal
    {
		public BotaoFechar() : base("Botão Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\botao_fechar.png") {}
    }
}
