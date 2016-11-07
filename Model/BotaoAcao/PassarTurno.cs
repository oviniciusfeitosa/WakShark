using Model.Base;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class PassarTurno : ABotaoAcao, IGlobal
    {
		public PassarTurno() : base("PassarTurno", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\botao_passar_turno.png") {}
    }
}
