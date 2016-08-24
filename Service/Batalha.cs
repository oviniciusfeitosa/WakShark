using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using Common;

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

                        // INÍCIO -  Trecho de teste
                        //System.Threading.Thread.Sleep(3000);
                        Bitmap bmp = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, false);
                        Bitmap bmpClone = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format32bppArgb);
                        
                        //bmpClone = TelaCaptura.obterInstancia().redimencionarImagem(bmpClone, bmpClone.Width / 2, bmpClone.Height);
                        //bmpClone = TelaCaptura.obterInstancia().rotacionarImagem(bmpClone, 315);

                        Dictionary<int, ModelTela> ModelTelas = new Dictionary<int, ModelTela>();
                        BatalhaAntiBOT objBatalhaAntiBOT = BatalhaAntiBOT.obterInstancia();
                        ModelTelas.Add(1, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero1.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(2, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero2.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(3, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero3.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(4, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero4.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(5, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero5.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(6, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero6.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(7, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero7.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
                        ModelTelas.Add(8, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado("./numero8.png", Imagem.EnumRegiaoImagem.LADO_DIREITO));
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
                        // FIM -  Trecho de teste
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

        public PointF obterPontoRotacionado(float angle, Point pt)
        {
            var a = angle * System.Math.PI / 180.0;
            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);
            return new PointF((pt.X * cosa - pt.Y * sina), (pt.X * sina + pt.Y * cosa));
        }

    }
}
