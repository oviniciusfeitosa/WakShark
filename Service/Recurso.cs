using Model.Recurso;
using Model.Recurso.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private List<ARecurso> listaRecursos = new List<ARecurso>();

        public Recurso() {
            this.preencherListaRecursos();
        }

        public void preencherListaRecursos()
        {
            listaRecursos = new List<ARecurso>();
            listaRecursos.Add(new Agua());
            listaRecursos.Add(new Trigo());
            listaRecursos.Add(new Cevada());
            listaRecursos.Add(new Aveia());
            listaRecursos.Add(new Centeio());
        }

        public ARecurso obterRecurso(string caption)
        {
            foreach (ARecurso objRecurso in listaRecursos)
            {
                if (objRecurso.Caption == caption)
                {
                    return objRecurso;
                }
            }
            return null;
        }

        public List<ARecurso> obterListaCompletaRecursos() {
            return listaRecursos;
        }

        public Dictionary<string, string> obterListaSimplificadaRecursos()
        {
            Dictionary<string, string> listaSimplificada = new Dictionary<string, string>();
            foreach (ARecurso objRecurso in listaRecursos) {
                listaSimplificada.Add(objRecurso.Caption, objRecurso.Imagem);
            }
        
            return listaSimplificada;
        }
    }
}
