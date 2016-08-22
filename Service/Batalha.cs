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
                    try {
                        //System.Threading.Thread.Sleep(3000);
                        Bitmap bmp = TelaCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(TelaCaptura.EnumRegiaoTela.TELA_CHEIA, false);
                        Bitmap bmpClone = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppArgb);
                        
                        //bmpClone = TelaCaptura.obterInstancia().redimencionarImagem(bmpClone, bmpClone.Width / 2, bmpClone.Height);
                        //bmpClone = TelaCaptura.obterInstancia().rotacionarImagem(bmpClone, 315);

                        Dictionary<int, ModelTela> ModelTelas = new Dictionary<int, ModelTela>();
                        ModelTelas.Add(1, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero1.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(2, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero2.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(3, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero3.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(4, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero4.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(5, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero5.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(6, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero6.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(7, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero7.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        ModelTelas.Add(8, Service.TelaPixelBatalha.obterInstancia().buscarNumeroPorTemplateRotacionado("./numero8.png", TelaCaptura.EnumRegiaoTela.LADO_DIREITO));
                        Application.DoEvents();

                        for(int indice = 1; indice < 9; indice++)
                        {
                            if (ModelTelas[indice].eixoHorizontal > 0)
                            {
                                bmpClone.SetPixel(ModelTelas[indice].eixoHorizontal, ModelTelas[indice].eixoVertical, Color.FromArgb(255, 255, 255, 255));
                            }
                        }
                        bmpClone.Save(@"C:\\Users\\Public\\Resultado.bmp");
                        Application.DoEvents();
                    }
                    catch (Exception objException)
                    {
                        MessageBox.Show(objException.Message);
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
