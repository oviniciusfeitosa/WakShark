﻿using Model.Base;
namespace Model.Recurso.Fazendeiro
{
    public class Girassol : ARecurso, IFazendeiro
    {
        public Girassol() : base("Girassol", 75, 1500, System.IO.Directory.GetCurrentDirectory() + @"\assets\imagem\recurso\fazendeiro\girassol.png") { }
    }
}
