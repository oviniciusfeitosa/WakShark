using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class Melao : ARecurso, IFazendeiro
    {
        public Melao() : base("Melao", 75, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\melao_maduro_tipo-1.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\melao_maduro_tipo-2.png");
        }
    }
}
