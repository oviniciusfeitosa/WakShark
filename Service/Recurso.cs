﻿using Model;
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

        private List<ARecurso> listaRecursosFazendeiro = new List<ARecurso>();
        private List<ARecurso> listaRecursosHerbolista = new List<ARecurso>();

        public Recurso() {
            this.preencherListaRecursosFazendeiro();
            this.preencherListaRecursosHerbolista();
        }

        public void preencherListaRecursosFazendeiro()
        {
            listaRecursosFazendeiro.Add(new Agua());
            listaRecursosFazendeiro.Add(new SoloMundo());
            listaRecursosFazendeiro.Add(new SoloBolsa());
            listaRecursosFazendeiro.Add(new Trigo());
            listaRecursosFazendeiro.Add(new Cevada());
            listaRecursosFazendeiro.Add(new Aveia());
            listaRecursosFazendeiro.Add(new Centeio());
            listaRecursosFazendeiro.Add(new CenteioVerde());
            listaRecursosFazendeiro.Add(new JutaSuarda());
            listaRecursosFazendeiro.Add(new JutaSuardaVerde());
            listaRecursosFazendeiro.Add(new Milho());
            listaRecursosFazendeiro.Add(new MilhoVerde());
        }

        public void preencherListaRecursosHerbolista()
        {
            listaRecursosHerbolista.Add(new Agua());
            listaRecursosHerbolista.Add(new SoloMundo());
            listaRecursosHerbolista.Add(new SoloBolsa());
            listaRecursosHerbolista.Add(new CardoCoroadoTipo1());
            listaRecursosHerbolista.Add(new CardoCoroadoTipo2());
        }

        public ARecurso obterRecurso(string caption, EnumProfissoes objEnumProfissao)
        {
            List<ARecurso> objListaRecursos = obterTipoListaRecurso(objEnumProfissao);
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
            List<ARecurso> objListaRecursos = obterTipoListaRecurso(objEnumProfissao);
            return objListaRecursos;
        }

        public Dictionary<string, string> obterListaSimplificadaRecursos(EnumProfissoes objEnumProfissao)
        {
            Dictionary<string, string> listaSimplificada = new Dictionary<string, string>();
            List<ARecurso> objListaRecursos = obterTipoListaRecurso(objEnumProfissao);

            foreach (ARecurso objRecurso in objListaRecursos) {
                listaSimplificada.Add(objRecurso.Caption, objRecurso.Imagem);
            }
        
            return listaSimplificada;
        }

        private List<ARecurso> obterTipoListaRecurso(EnumProfissoes objEnumProfissao)
        {
            List<ARecurso> objListaRecursos = new List<ARecurso>();
            if (objEnumProfissao == EnumProfissoes.Fazendeiro)
            {
                objListaRecursos = listaRecursosFazendeiro;
            }
            else if (objEnumProfissao == EnumProfissoes.Herbolista)
            {
                objListaRecursos = listaRecursosHerbolista;
            }
            return objListaRecursos;
        }
    }
}
