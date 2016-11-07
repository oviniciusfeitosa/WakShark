using Model.Base;
using System.Threading.Tasks;
using System.Threading;
using Model.Base.Acao;

namespace Model.BotaoAcao
{
    public class Ceifar : ABotaoAcao, IColheita
    {
        public Ceifar() : base("Ceifar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png") { }
    }
}
