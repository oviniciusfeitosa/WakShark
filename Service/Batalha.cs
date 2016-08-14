using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTela = Model.Tela;

namespace Service
{
    public class Batalha
    {
        #region singleton
        private static Batalha objBatalha;

        public static Batalha obterInstancia()
        {
            if (Batalha.objBatalha == null)
            {
                Batalha.objBatalha = new Batalha();
            }
            return Batalha.objBatalha;
        }
        #endregion

        public enum EnumTiposBatalha
        {
            AntiBOT,
            Normal
        };

        public bool iniciar(EnumTiposBatalha objEnumTipoBatalha)
        {
            switch (objEnumTipoBatalha)
            {
                case EnumTiposBatalha.AntiBOT:
                    /*
                    ModelTela objModelTela = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_1.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela2 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_2.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela3 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_3.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela4 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_4.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela5 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_5.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela6 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_6.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela7 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_7.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    ModelTela objModelTela8 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_8.png", TelaCaptura.EnumRegiaoTela.LADO_ESQUERDO);
                    */
                    ModelTela objModelTela = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_1.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela2 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_2.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela3 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_3.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela4 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_4.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela5 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_5.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela6 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_6.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela7 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_7.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);
                    ModelTela objModelTela8 = Service.TelaPixel.obterInstancia().buscarImagemPorTemplate("./bot_numero_8.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO);

                    /// PAREI AQUI:
                    /// - EXTRAIR IMAGENS JÁ PROCESSADAS DOS NÚMEROS PARA NÃO PRECISAR PROCESSAR NOVAMENTE
                    /// - O NÚMERO 3 DAS IMAGENS NÃO ESTÁ LEGAL, TALVEZ FAZENDO O PROCESSO ACIMA É RECONHECIDO CORRETAMENTE
                    /// - OBS: O MÉTOOD USADO DE COMPARADAÇÃO EM 'BUSCARIMAGEMPORTEMPLATE' AGORA SIM ESTÁ FUNCIONANDO CORRETAMENTE.
                    /*
                    var teste = System.Diagnostics.Process.GetProcessesByName()
                    Common.Lib.Win32.clicarBotaoEsquerdo(objModelTela.eixoHorizontal, objModelTela.eixoVertical);
                    IntPtr objHandle = GetDC(IntPtr.Zero);
                    */
                    break;
                case EnumTiposBatalha.Normal:
                    // Faça Algo
                    break;
                default:
                    break;
            }
            return true;
        }
        
    }
}
