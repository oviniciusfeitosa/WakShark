using Model.Base;
namespace Model.Recurso
{
    public class JutaSuardaVerde : ARecurso, IFazendeiro
    {
        public JutaSuardaVerde() : base("JutaSuardaVerde", 65, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\juta_suarda_verde.png") { }
    }
}
