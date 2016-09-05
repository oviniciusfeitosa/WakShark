﻿
using ModelTela = Model.Tela;
using Service;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Threading;
using Common.Lib;
using Common;
using System.Drawing;
using System;
using Model;

namespace Service
{
    public class Coleta
    {

        private int _areaColetaPercent = 30;

        #region Singleton
        private static Coleta objColeta;

        public static Coleta obterInstancia()
        {

            if (Coleta.objColeta == null)
            {
                Coleta.objColeta = new Coleta();
            }
            return Coleta.objColeta;
        }
        #endregion

        private void _ampliarAreaColeta()
        {
            if (_areaColetaPercent <= 80)
            {
                _areaColetaPercent += 10;
            }
        }

        private void _redefinirAreaColeta()
        {
            _areaColetaPercent = 20;
        }

        private Rectangle definirRetanguloAreaColeta()
        {
            /*
            return new Rectangle(
                                (Screen.PrimaryScreen.Bounds.Width / 4) - ((Screen.PrimaryScreen.Bounds.Width / 2 * _areaColetaPercent / 100) / 2),
                                (Screen.PrimaryScreen.Bounds.Height / 2) - ((Screen.PrimaryScreen.Bounds.Height * _areaColetaPercent / 100) / 2),
                                (Screen.PrimaryScreen.Bounds.Width / 2 * _areaColetaPercent / 100),
                                (Screen.PrimaryScreen.Bounds.Height * _areaColetaPercent / 100)
            );*/
            Size bounds = Proporcao.obterProporcao();

            return new Rectangle(
                                (bounds.Width / 4) - ((bounds.Width / 2 * _areaColetaPercent / 100) / 2),
                                (bounds.Height / 2) - ((bounds.Height * _areaColetaPercent / 100) / 2),
                                (bounds.Width / 2 * _areaColetaPercent / 100),
                                (bounds.Height * _areaColetaPercent / 100)
            );
        }


        public bool coletar(string caminhoTemplateRecurso)
        {

            this.validarInicioBatalha();
            this.validarFechamentoMensagens();

            Model.Match match = new Model.Match();

            while (match.Semelhanca < 0.633d)
            {
                match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateRecurso, Imagem.EnumRegiaoImagem.COMPLETO, definirRetanguloAreaColeta());

                if (match.Semelhanca >= 0.633d)
                {
                    acaoColetarGraos(match);
                    break;
                }
                else if(_areaColetaPercent > 89) {
                    Personagem.obterInstancia().movimentarRandomicamente();
                    Thread.Sleep(800);
                    break;
                }
                else
                {   
                    _ampliarAreaColeta();
                }    
            }
            _redefinirAreaColeta();
            
            return false;
        }

        public void validarInicioBatalha()
        {
            System.Drawing.Bitmap bmpBatalha = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true);
            if (Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(200, 200)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(250, 250)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(300, 300)) == "#000000")
            {
                System.Windows.Forms.SendKeys.SendWait(" ");
                Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
            }
            bmpBatalha.Dispose();
        }

        private void validarFechamentoMensagens()
        {
            Acao objAcao = new Model.Acao();
            Rectangle areaBusca = new Rectangle(50, 50, Proporcao.Width - 50, Proporcao.Height - 50);
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(objAcao.tiposAcoes["Fechar"], Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
        }

        private bool acaoColetarGraos(Model.Match objMatch)
        {
            try
            {
                Win32.clicarBotaoDireito(objMatch.Location.X, objMatch.Location.Y);
                Thread.Sleep(500);
                Acao objAcao = new Model.Acao();

                Rectangle areaBusca = new Rectangle(objMatch.Location.X - 100, objMatch.Location.Y - 60, 100, 100);
                objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(objAcao.tiposAcoes["Colher"], Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
                if(objMatch.Semelhanca > 0)
                {
                    Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
                    Thread.Sleep(4700);
                }

                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }
    }
}
