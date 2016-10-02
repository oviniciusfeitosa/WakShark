using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class IniciarBatalha : ABotaoAcao, IGlobal
    {
		public IniciarBatalha() : base("IniciarBatalha", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\iniciar_batalha.png") {}
    }
}
