using Model;
using Model.Base;
using Model.Recurso;
using Model.Recurso.Herbolista;
using Model.Recurso.Fazendeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Recurso.Terreno;

namespace Service
{
    public class Recurso
    {
        #region Singleton
        private static Recurso objRecurso;

        public static Recurso obterInstancia()
        {
            if (Recurso.objRecurso == null)
            {
                Recurso.objRecurso = new Recurso();
            }
            return Recurso.objRecurso;
        }
        #endregion

        public List<ARecurso> preencherListaRecursosComuns(List<ARecurso> listaRecursos)
        {
            listaRecursos.Add(new Agua());
            listaRecursos.Add(new SoloMundo());
            listaRecursos.Add(new SoloBolsa());

            return listaRecursos;
        }

        public List<ARecurso> preencherlistaRecursosFazendeiro(List<ARecurso> listaRecursos)
        {
            listaRecursos.Add(new Trigo());
            listaRecursos.Add(new Cevada());
            listaRecursos.Add(new Aveia());
            listaRecursos.Add(new Centeio());
            listaRecursos.Add(new CenteioVerde());
            listaRecursos.Add(new JutaSuarda());
            listaRecursos.Add(new JutaSuardaVerde());
            listaRecursos.Add(new Milho());
            listaRecursos.Add(new MilhoVerde());
            listaRecursos.Add(new Melao());

            return listaRecursos;
        }

        public List<ARecurso> preencherlistaRecursosHerbolista(List<ARecurso> listaRecursos)
        {
            listaRecursos.Add(new CardoCoroado());
            //listaRecursos.Add(new CardoCoroado());
            //listaRecursos.Add(new CardoCoroadoVerde());

            return listaRecursos;
        }

        public ARecurso obterRecurso(string caption, EnumProfissoes objEnumProfissao)
        {
            List<ARecurso> objListaRecursos = obterListaRecursos(objEnumProfissao);
            foreach (ARecurso objRecurso in objListaRecursos)
            {
                if (objRecurso.Caption == caption)
                {
                    return objRecurso;
                }
            }
            return null;
        }

        public List<ARecurso> obterListaCompletaRecursos(EnumProfissoes objEnumProfissao) {
            List<ARecurso> objListaRecursos = obterListaRecursos(objEnumProfissao);
            return objListaRecursos;
        }

        public Dictionary<string, string> obterListaSimplificadaRecursos(EnumProfissoes objEnumProfissao)
        {
            Dictionary<string, string> listaSimplificada = new Dictionary<string, string>();
            List<ARecurso> objListaRecursos = obterListaRecursos(objEnumProfissao);

            foreach (ARecurso objRecurso in objListaRecursos) {
                listaSimplificada.Add(objRecurso.Caption, objRecurso.ImagemExibicao);
            }
        
            return listaSimplificada;
        }

        private List<ARecurso> obterListaRecursos(EnumProfissoes objEnumProfissao)
        {
            List<ARecurso> listaRecursos = new List<ARecurso>();
            this.preencherListaRecursosComuns(listaRecursos);
            if (objEnumProfissao == EnumProfissoes.Fazendeiro)
            {
                this.preencherlistaRecursosFazendeiro(listaRecursos);
            }
            else if (objEnumProfissao == EnumProfissoes.Herbolista)
            {
                this.preencherlistaRecursosHerbolista(listaRecursos);
            }
            return listaRecursos;
        }
    }
}
