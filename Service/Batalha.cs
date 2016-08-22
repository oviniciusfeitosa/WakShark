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
                    try {
                        System.Threading.Thread.Sleep(3000);
                        Bitmap bmp = TelaCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel();
                        Bitmap bmpClone = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppArgb);
                        Bitmap bmpCloneOrig = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppArgb);
                        bmpClone = TelaCaptura.ResizeImage(bmpClone, bmpClone.Width / 2, bmpClone.Height);
                        bmpClone = TelaCaptura.RotateImage(bmpClone, 315);

                        Dictionary<int, ModelTela> ModelTelas = new Dictionary<int, ModelTela>();
                        ModelTelas.Add(1, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero1.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(2, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero2.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(3, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero3.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(4, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero4.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(5, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero5.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(6, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero6.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(7, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero7.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        ModelTelas.Add(8, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero8.png", TelaCaptura.EnumRegiaoTela.TELA_CHEIA));
                        Application.DoEvents();


                        List<ModelTela> NumerosEncontrados = new List<ModelTela>();
                        foreach (ModelTela m in ModelTelas.Values)
                        {
                            if (m.eixoHorizontal > 0)
                            {
                                NumerosEncontrados.Add(m);

                            }
                        }

                        foreach (ModelTela m in NumerosEncontrados)
                        {
                            int offsetX = m.eixoHorizontal;
                            int offsetY = m.eixoVertical;

                            for (int i = offsetX; i < offsetX + 20; i++)
                            {
                                for (int j = offsetY; j < offsetY + 20; j++)
                                {
                                    if (j <= bmpClone.Height && i <= bmpClone.Width)
                                        bmpClone.SetPixel(i, j, Color.FromArgb(255, 255 - m.pixelColor.R, 255 - m.pixelColor.G, 255 - m.pixelColor.B));
                                }
                            }
                        }
                        bmpClone.Save(@"C:\temp\Resultado.bmp");
                        Application.DoEvents();
                    }
                    catch (Exception e)
                    {

                    }

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
