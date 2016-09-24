using Model.Base;
namespace Model.BotaoAcao
{
    public class PassarTurno : ABotaoAcao
    {
		public PassarTurno() : base("PassarTurno", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\botao_passar_turno.png") {}
    }
}
