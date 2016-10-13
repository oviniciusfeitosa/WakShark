using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class JutaSuardaVerde : ARecurso, IFazendeiro
    {
        public JutaSuardaVerde() : base("JutaSuardaVerde", 65, 1800, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\juta_suarda_verde.png") { }
    }
}
