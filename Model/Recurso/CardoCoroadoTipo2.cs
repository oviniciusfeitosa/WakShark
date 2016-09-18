using Model.Base;

namespace Model.Recurso
{
    public class CardoCoroadoTipo2 : ARecurso, IHerbolista
    {
        public CardoCoroadoTipo2() : base("Cardo Coroado - 2", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\herbolista\cardo_coroado_tipo-2.png") { }
    }
}
