using Model.Recurso;
using Model.Base;
using Model.BotaoAcao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Acao
    {
        #region Singleton
        private static Acao objAcao;

        public static Acao obterInstancia()
        {
            if (Acao.objAcao == null)
            {
                Acao.objAcao = new Acao();
            }
            return Acao.objAcao;
        }
        #endregion

        public static List<ABotaoAcao> listaBotoesAcoes = new List<ABotaoAcao>();
        
        public Acao ()
        {
            this.preencherListaBotoesAcoes();
        }

        public void preencherListaBotoesAcoes()
        {
            listaBotoesAcoes = new List<ABotaoAcao>();
            listaBotoesAcoes.Add(new Colher());
            listaBotoesAcoes.Add(new Ceifar());
            listaBotoesAcoes.Add(new Cortar());
            listaBotoesAcoes.Add(new Fechar());
            listaBotoesAcoes.Add(new IniciarBatalha());
            listaBotoesAcoes.Add(new PassarTurno());
			listaBotoesAcoes.Add(new TerrenoPlantio());
        }

        public ABotaoAcao obterAcao(string nome)
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
