
using ModelTela = Model.Tela;
using Service;
using Gma.System.MouseKeyHook;
using System.Windows.Forms;
using System.Threading;
using Common.Lib;
using Common;
using System.Drawing;
using System;

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
            _areaColetaPercent = 30;
        }

        private Rectangle definirRetanguloAreaColeta()
        {
            return new Rectangle(
                                (Screen.PrimaryScreen.Bounds.Width / 4) - ((Screen.PrimaryScreen.Bounds.Width / 2 * _areaColetaPercent / 100) / 2),
                                (Screen.PrimaryScreen.Bounds.Height / 2) - ((Screen.PrimaryScreen.Bounds.Height * _areaColetaPercent / 100) / 2),
                                (Screen.PrimaryScreen.Bounds.Width / 2 * _areaColetaPercent / 100),
                                (Screen.PrimaryScreen.Bounds.Height * _areaColetaPercent / 100)
            );
        }


        public bool coletar(string caminhoTemplateRecurso)
        {

            this.validarInicioBatalha();

            Model.Match match = new Model.Match();

            while (match.Semelhanca < 0.7)
            {
                match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateRecurso, Imagem.EnumRegiaoImagem.COMPLETO, definirRetanguloAreaColeta());

                if (match.Semelhanca >= 0.7)
                {
                    acaoColetar(match);
                    _redefinirAreaColeta();
                }
                else if(_areaColetaPercent == 90) {
                    Personagem.obterInstancia().movimentarRandomicamente();
                    _redefinirAreaColeta();
                }
                else
                {
                    
                    _ampliarAreaColeta();
                }
            }
            return false;
        }

        public void validarInicioBatalha()
        {
            System.Drawing.Bitmap bmpBatalha = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true);
            if (Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(200, 200)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(250, 250)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(300, 300)) == "#000000")
            {
                //bmpBatalha.Save(@"C:\users\public\iniciandoBatalha.bmp");
                System.Windows.Forms.SendKeys.SendWait(" ");
                Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
            }
            bmpBatalha.Dispose();
        }

        public static bool acaoColetar(Model.Match Match)
        {
            try
            {
                Win32.clicarBotaoDireito(Match.Location.X, Match.Location.Y);
                Thread.Sleep(500);
                Win32.clicarBotaoEsquerdo(Match.Location.X - 35, Match.Location.Y - 35);
                Thread.Sleep(4500);

                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }
    }
}
