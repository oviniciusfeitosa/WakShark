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

                        BatalhaAntiBOT objBatalhaAntiBOT = BatalhaAntiBOT.obterInstancia();

                        Rectangle RectPersonagem = new Rectangle(275, 405, 107, 107);
                        Rectangle RectGato = new Rectangle(448, 405, 107, 107);
                        

                        Dictionary<int, Model.Match> MatchesGato = new Dictionary<int, Model.Match>();
                        MatchesGato.Add(1, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero1.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(2, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero2.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(3, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero3.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(4, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero4.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(5, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero5.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(6, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero6.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(7, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero7.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        MatchesGato.Add(8, objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero8.png", Imagem.EnumRegiaoImagem.RETANGULO, RectGato));
                        Application.DoEvents();

                        List<Model.Match> Verificar = new List<Model.Match>();
                        foreach (Model.Match m in MatchesGato.Values)
                        {
                            if (m.Semelhanca > 0)
                            {
                                Verificar.Add(m);
                             
                            }
                        }

                        //System.Threading.Thread.Sleep(1000);
                        List<Model.Match> Clicar = new List<Model.Match>();
                        bool conflito = false;
                        if (Verificar.Count > 3)
                        {
                            for (int i = 0; i < Verificar.Count; i++)
                            {
                                conflito = false;

                                for (int j =0;j < Verificar.Count; j++)
                                {
                                    if (i == j)
                                    {
                                        continue;
                                    }

                                    if (new Rectangle(Verificar[i].Location, new Size(24, 24)).Contains(Verificar[j].Location))
                                    {
                                        conflito = true;
                                        if (Verificar[i].Semelhanca > Verificar[j].Semelhanca)
                                            Clicar.Add(Verificar[i]);
                                        else
                                            Clicar.Add(Verificar[j]);
                                    }

                                }
                                if (!conflito)
                                    Clicar.Add(Verificar[i]);

                            }
                        }
                        else
                        {
                            Clicar.AddRange(Verificar);
                        }

                        foreach (Model.Match c in Clicar)
                        {
                            System.Threading.Thread.Sleep(2000);
                            Model.Match matchClicar = objBatalhaAntiBOT.buscarNumeroPorTemplateRotacionado(@"./numero" + c.Numero.ToString() + ".png", Imagem.EnumRegiaoImagem.RETANGULO, RectPersonagem);

                            System.Windows.Forms.SendKeys.SendWait("1");
                            System.Threading.Thread.Sleep(2000);
                            Common.Lib.Win32.posicionarMouse(matchClicar.Location.X, matchClicar.Location.Y);
                            Common.Lib.Win32.clicarBotaoEsquerdo(matchClicar.Location.X, matchClicar.Location.Y);

                        }

                        Application.DoEvents();

                        System.Threading.Thread.Sleep(8000);
                        System.Windows.Forms.SendKeys.SendWait("{ESC}");


                        //Dictionary<int, Model.Match> MatchesPersonagem = new Dictionary<int, Model.Match>();

                        //List<Model.Match> EncontradosPersonagem = new List<Model.Match>();

                        //foreach (Model.Match m in MatchesPersonagem.Values)
                        //{
                        //    if (m.Semelhanca > 0)
                        //        EncontradosPersonagem.Add(m);
                        //}



                        // @todo Verificar qual resultado está duplicado do lado do personagem e comparar pra usar o mais correto e substituir o outro pelo numero que faltou





                        //for(int indice = 1; indice < 9; indice++)
                        //{
                        //    if (ModelTelas[indice].X > 0)
                        //    {
                        //        Point localizacao = ImagemTransformacao.obterInstancia().obterPontoRotacionado(315f, ModelTelas[indice]);
                        //        for (int i = localizacao.X; i < localizacao.X + 20; i++)
                        //        {
                        //            for (int j = localizacao.Y; j < localizacao.Y + 20; j++)
                        //            {
                        //                if (j <= bmpClone.Height && i <= bmpClone.Width)
                        //                    bmpClone.SetPixel(i, j, Color.Red);
                        //            }
                        //        }
                        //    }
                        //}


                        //bmpClone.Save(@"C:\\Users\\Public\\Resultado.bmp");

                        //MessageBox.Show("Alo mundo!");
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

        

    }
}
