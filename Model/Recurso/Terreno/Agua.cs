using Model.Base;

namespace Model.Recurso.Terreno
{
    public class Agua : ARecurso, ITerreno
    {
        public Agua() : base("Água", 0, 1000, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\agua.png") { }
    }
}
