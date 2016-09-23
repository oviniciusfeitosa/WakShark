using Model.Base;
using Common.Lib;
using System.Threading.Tasks;
using System.Threading;
namespace Model.Acao
{
    public class PassarTurno : AAcao
    {
		public PassarTurno() : base("PassarTurno", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\botao_passar_turno.png") {}

		public bool executarAcao(Match objMatch, int Tempo) {
			// To something.
		}
    }
}
