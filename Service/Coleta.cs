
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

        public static Coleta obterInstancia() {

            if(Coleta.objColeta == null)
            {
                Coleta.objColeta = new Coleta();
            }
            return Coleta.objColeta;
        }
        #endregion

        private void _ampliaAreaColeta()
        {
            if (_areaColetaPercent <= 80)
            {
                _areaColetaPercent += 10;
            }
        }

        private void _resetaAreaColeta()
        {
            _areaColetaPercent = 30;
        }

        private Rectangle rectAreaColeta = new Rectangle();

        private Rectangle defineRetanguloAreaColeta()
        {
            return new Rectangle(
                                                (Screen.PrimaryScreen.Bounds.Width / 4) - ((Screen.PrimaryScreen.Bounds.Width / 2  * _areaColetaPercent / 100) / 2),
                                                (Screen.PrimaryScreen.Bounds.Height / 2) - ((Screen.PrimaryScreen.Bounds.Height  * _areaColetaPercent / 100) / 2),
                                                (Screen.PrimaryScreen.Bounds.Width /2 * _areaColetaPercent / 100),
                                                (Screen.PrimaryScreen.Bounds.Height  * _areaColetaPercent / 100)
                                               );
        }


        public bool coletar(string caminhoTemplateRecurso)
        {
            System.Drawing.Bitmap bmpBatalha = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true);
            this.validarInicioBatalha(bmpBatalha);
            
            int eixoHorizontal = Convert.ToInt32(SystemInformation.PrimaryMonitorSize.Width * 0.3);
            int eixoVertical = Convert.ToInt32(SystemInformation.PrimaryMonitorSize.Height * 0.3);
            int largura = Convert.ToInt32(SystemInformation.PrimaryMonitorSize.Width * 0.4);
            int altura = Convert.ToInt32(SystemInformation.PrimaryMonitorSize.Height * 0.4);

            //Rectangle RectPersonagem = new Rectangle(eixoHorizontal, eixoVertical, largura, altura);
            //return ImagemBusca.obterInstancia().procurarImagemPorTemplateComAcao(caminhoTemplateRecurso, acaoColetar, Imagem.EnumRegiaoImagem.COMPLETO, RectPersonagem);

            Model.Match match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateRecurso, Imagem.EnumRegiaoImagem.COMPLETO, defineRetanguloAreaColeta());
            
            while (match.Semelhanca < 0.7)
            {
                if (match.Semelhanca >= 0.7)
                {
                    acaoColetar(match);
                    _resetaAreaColeta();
                    return true;
                }
                else
                {
                    if (_areaColetaPercent == 100)
                        return false;
                    _ampliaAreaColeta();
                }

                match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoTemplateRecurso, Imagem.EnumRegiaoImagem.COMPLETO, defineRetanguloAreaColeta());
                acaoColetar(match);
            }
            return false;
        }

        public void validarInicioBatalha(Bitmap bmpBatalha)
        {
            
            if (Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(200, 100)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(300, 100)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(400, 100)) == "#000000")
            {
                //bmpBatalha.Save(@"C:\users\public\iniciandoBatalha.bmp");
                System.Windows.Forms.SendKeys.SendWait(" ");
                Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
            }
        }

        public static bool acaoColetar(Model.Match Match)
        {
            try
            {
                Win32.clicarBotaoDireito(Match.Location.X, Match.Location.Y);
                Thread.Sleep(1100);
                Win32.clicarBotaoEsquerdo(Match.Location.X - 35, Match.Location.Y - 35);
                Thread.Sleep(6000);

                return true;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }
    }
}
