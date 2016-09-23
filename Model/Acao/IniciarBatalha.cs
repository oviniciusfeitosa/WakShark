using Model.Base;
using Common.Lib;
using System.Threading.Tasks;
using System.Threading;
namespace Model.Acao
{
    public class IniciarBatalha : AAcao
    {
		public IniciarBatalha() : base("IniciarBatalha", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\iniciar_batalha.png") {}

		public bool executarAcao(Match objMatch, int Tempo) {
			// To something.
		}
    }
}
