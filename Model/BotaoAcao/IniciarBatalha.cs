using Model.Base;

namespace Model.BotaoAcao
{
    public class IniciarBatalha : ABotaoAcao
    {
		public IniciarBatalha() : base("IniciarBatalha", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\iniciar_batalha.png") {}
    }
}
