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
            listaRecursosFazendeiro = new List<ARecurso>();
            listaRecursosFazendeiro.Add(new Agua());
            listaRecursosFazendeiro.Add(new Trigo());
            listaRecursosFazendeiro.Add(new Cevada());
            listaRecursosFazendeiro.Add(new Aveia());
            listaRecursosFazendeiro.Add(new Centeio());
            listaRecursosFazendeiro.Add(new JutaSuarda());
            listaRecursosFazendeiro.Add(new JutaSuardaVerde());
            listaRecursosFazendeiro.Add(new Milho());
            listaRecursosFazendeiro.Add(new MilhoVerde());
        }

        public void preencherListaRecursosHerbolista()
        {
            listaRecursosFazendeiro.Add(new CardoCoroadoTipo1());
            listaRecursosFazendeiro.Add(new CardoCoroadoTipo2());
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

        public List<ARecurso> obterListaCompletaRecursos() {
            return listaRecursosFazendeiro;
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

        private List<ARecurso> obterTipoListaRecurso(EnumProfissoes objEnumProfissoes)
        {
            List<ARecurso> objListaRecursos = new List<ARecurso>();
            if (objEnumProfissoes == EnumProfissoes.Fazendeiro)
            {
                objListaRecursos = listaRecursosFazendeiro;
            }
            else if (objEnumProfissoes == EnumProfissoes.Herbolista)
            {
                objListaRecursos = listaRecursosHerbolista;
            }
            return objListaRecursos;
        }
    }
}
