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
            
            //@todo: refatorar esse trenho para que esse método estático receba o nome do namespace e também como propriedade anonima o tipo que deve ser comparado no "is"
            Type[] typelist = NamespaceUtil.GetTypesInNamespace("Model.BotaoAcao");
            for (int i = 0; i < typelist.Length; i++)
            {
                if (typelist[i] is IColheita) {

                    listaBotoesAcoes.Add((ABotaoAcao)Activator.CreateInstance(typelist[i]));
                }
            }
            //@fim do todo
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
