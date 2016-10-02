using Model;
using Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Base
{
    public abstract class AViewModelColeta
    {
        public ARecurso objRecurso { set; get;}
        public ABotaoAcao objABotaoAcao { set; get; }
        public Match objMatch { set; get; }

        public abstract bool executarAcao();
    }
}
