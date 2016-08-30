
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
            return ImagemBusca.obterInstancia().procurarImagemPorTemplateComAcao(caminhoTemplateRecurso, acaoColetar);
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

        public static bool acaoColetar(Model.Tela objModelTela)
        {
            try
            {
                Win32.clicarBotaoDireito(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                Thread.Sleep(1100);
                Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal - 35, objModelTela.eixoVertical - 35);
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
