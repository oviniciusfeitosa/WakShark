using Model.Base;

namespace Model.Recurso.Terreno
{
	public class SoloBolsa : ARecurso, ITerreno
    {
		public SoloBolsa() : base("SoloBolsa", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\terreno\terreno_bolsa.png") {}
	}
}
