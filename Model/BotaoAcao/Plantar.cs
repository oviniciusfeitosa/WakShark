using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Plantar : ABotaoAcao, IPlantio
    {
		public Plantar() : base("Plantar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\plantio.png") {}
    }
}
