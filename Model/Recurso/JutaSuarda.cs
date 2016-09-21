using Model.Base;
namespace Model.Recurso
{
    public class JutaSuarda : ARecurso, IFazendeiro
    {
        public JutaSuarda() : base("JutaSuarda", 65, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\juta_suarda.png") { }
    }
}
