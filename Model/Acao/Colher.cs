using Model.Base;
using Common.Lib;
using System.Threading.Tasks;
using System.Threading;
namespace Model.Acao
{
    public class Colher : AAcao
    {
        public Colher() : base("Colher", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\colher.png"){}

		public bool executarAcao(Match objMatch, int Tempo) {
			Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
			Thread.Sleep(2000);
			Thread.Sleep(Tempo);
			return true;
		}
    }
}
