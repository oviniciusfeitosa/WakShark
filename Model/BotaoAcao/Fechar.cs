using Model.Base;

namespace Model.BotaoAcao
{
    public class Fechar : ABotaoAcao
    {
		public Fechar() : base("Fechar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\fechar.png") {}
    }
}
