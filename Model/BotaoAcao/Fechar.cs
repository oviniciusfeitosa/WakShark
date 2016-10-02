using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Fechar : ABotaoAcao, IGlobal
    {
		public Fechar() : base("Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png") {}
    }
}
