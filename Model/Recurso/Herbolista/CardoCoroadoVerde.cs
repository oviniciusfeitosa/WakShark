using Model.Base;

namespace Model.Recurso.Herbolista
{
    public class CardoCoroadoVerde : ARecurso, IHerbolista
    {
        public CardoCoroadoVerde() : base("Cardo Coroado Verde", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_verde_tipo-1.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_verde_tipo-2.png");
        }
    }
}
