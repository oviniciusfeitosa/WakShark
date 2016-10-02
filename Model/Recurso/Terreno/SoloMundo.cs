using Model.Base;

namespace Model.Recurso.Terreno
{
	public class SoloMundo : ARecurso, ITerreno
    {
		public SoloMundo() : base("SoloMundo", 0, 3000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\terreno\terreno_mundo.png") {}
	}
}
