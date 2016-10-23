using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class MelaoVerde : ARecurso, IFazendeiro
    {
        public MelaoVerde() : base("MelaoVerde", 75, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\melao_verde_tipo-1.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\melao_verde_tipo-2.png");
        }
    }
}
