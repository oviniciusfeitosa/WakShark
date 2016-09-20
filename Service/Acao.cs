using Model.Recurso;
using Model.Base;
using Model.Acao;
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

        public static List<AAcao> listaAcoes = new List<AAcao>();
        
        public Acao ()
        {
            this.preencherListaAcoes();
        }

        public void preencherListaAcoes()
        {
            listaAcoes = new List<AAcao>();
            listaAcoes.Add(new Colher());
            listaAcoes.Add(new Ceifar());
            listaAcoes.Add(new Cortar());
            listaAcoes.Add(new Fechar());
            listaAcoes.Add(new IniciarBatalha());
        }

        public AAcao obterAcao(string nome)
        {
            foreach (AAcao objAcao in listaAcoes)
            {
                if (objAcao.Nome == nome)
                {
                    return objAcao;
                }
            }
            return null;
        }

        public List<AAcao> obterListaCompletaAcoes()
        {
            return listaAcoes;
        }

        public Dictionary<string, string> obterListaSimplificadaAcoes()
        {
            Dictionary<string, string> listaSimplificada = new Dictionary<string, string>();
            foreach (AAcao objRecurso in listaAcoes)
            {
                listaSimplificada.Add(objRecurso.Nome, objRecurso.Imagem);
            }

            return listaSimplificada;
        }

    }
}
