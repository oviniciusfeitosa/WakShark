using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class GirassolVerde : ARecurso, IFazendeiro
    {
        public GirassolVerde() : base("GirassolVerde", 80, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\girassol_verde_tipo-1.png") {
            this.ListaImagens.Add(System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\girassol_verde_tipo-2.png");
        }
    }
}