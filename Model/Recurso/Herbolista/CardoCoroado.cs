using Model.Base;

namespace Model.Recurso.Herbolista
{
    public class CardoCoroado : ARecurso, IHerbolista
    {
        public CardoCoroado() : base("Cardo Coroado", 0, 2600, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_tipo-1.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_tipo-2.png");
        }
    }
}
