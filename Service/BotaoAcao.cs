using Model.Recurso;
using Model.Base;
using Model.Base.Acao;
using Model.BotaoAcao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Service.Acao;
using System.Reflection;

namespace Service
{
    public class BotaoAcao
    {
        #region Singleton
        private static BotaoAcao objBotaoAcao;

        public static BotaoAcao obterInstancia()
        {
            if (BotaoAcao.objBotaoAcao == null)
            {
                BotaoAcao.objBotaoAcao = new BotaoAcao();
            }
            return BotaoAcao.objBotaoAcao;
        }
        #endregion

        public static List<ABotaoAcao> listaBotoesAcoes = new List<ABotaoAcao>();
        
        public BotaoAcao ()
        {
            this.preencherListaBotoesAcoes();
        }

        public void preencherListaBotoesAcoes()
        {
            listaBotoesAcoes = new List<ABotaoAcao>();
            listaBotoesAcoes.Add(new Colher());
            listaBotoesAcoes.Add(new Ceifar());
            listaBotoesAcoes.Add(new Cortar());
            listaBotoesAcoes.Add(new Plantar());
            listaBotoesAcoes.Add(new IniciarBatalha());
            listaBotoesAcoes.Add(new PassarTurno());
            listaBotoesAcoes.Add(new BotaoFecharX());
            listaBotoesAcoes.Add(new BotaoFechar());
        }

        public ABotaoAcao obterBotaoAcao(string nome)
        {
            foreach (ABotaoAcao objAcao in listaBotoesAcoes)
            {
                if (objAcao.Nome == nome)
                {
                    return objAcao;
                }
            }
            return null;
        }

        public List<ABotaoAcao> obterListaCompletaAcoes()
        {
            return listaBotoesAcoes;
        }

        public Dictionary<string, string> obterListaSimplificadaAcoes()
        {
            Dictionary<string, string> listaSimplificada = new Dictionary<string, string>();
            foreach (ABotaoAcao objRecurso in listaBotoesAcoes)
            {
                listaSimplificada.Add(objRecurso.Nome, objRecurso.Imagem);
            }

            return listaSimplificada;
        }

    }
}
