using Model.Base;
using System.Threading.Tasks;
using System.Threading;


namespace Model.BotaoAcao
{
    public class Ceifar : ABotaoAcao
    {
        public Ceifar() : base("Ceifar", System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\acao\ceifar.png") { }
    }
}
