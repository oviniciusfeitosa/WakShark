using Model.Base;

namespace Model.Recurso.Herbolista
{
    public class CardoCoroadoTipo1 : ARecurso, IHerbolista
    {
        public CardoCoroadoTipo1() : base("Cardo Coroado - 1", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_tipo-1.png") { }
    }
}
