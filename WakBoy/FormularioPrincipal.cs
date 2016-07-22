// https://github.com/gmamaladze/globalmousekeyhook
using System;
using System.Drawing;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using ServiceRecurso = Service.Recurso;
using CapturadorPixel = Service.CapturadorPixel;
using ServiceColeta = Service.Coleta;
using Service;
using Gma.System.MouseKeyHook;
using System.Drawing.Imaging;
using Service.Lib;
using Emgu.CV;
using Emgu.CV.Structure;

namespace WakBoy
{
    public partial class FormularioPrincipal : Form, IDisposable
    {
        private IKeyboardMouseEvents m_GlobalHook;

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            labelRecurso.Visible = false;
            comboRecurso.Visible = false;
            using (ServiceRecurso objRecurso = new ServiceRecurso())
            {
                comboTipoRecurso.DataSource = objRecurso.obterTiposRecurso();
            }
        }

        #region Selecionar Combo Tipo de Recurso
        private void comboTipoRecurso_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            string tipoRecursos = objComboBox.SelectedValue.ToString();
            labelRecurso.Visible = false;
            comboRecurso.Visible = false;
            if (!String.IsNullOrEmpty(tipoRecursos) && tipoRecursos != "")
            {
                labelRecurso.Visible = true;
                comboRecurso.Visible = true;
                using (ServiceRecurso objRecurso = new ServiceRecurso())
                {
                    comboRecurso.DataSource = objRecurso.obterRecursos(tipoRecursos);
                }
            }
        }
        #endregion

        #region Iniciar Capinação
        private void checkBoxCapinacaoLigado_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objComboBox = (CheckBox)sender;
            objComboBox.Text = "Desligado";
            if (objComboBox.Checked == true)
            {
                objComboBox.Text = "Ligado";
                bool retorno = ServiceColeta.obterInstancia().coletar(comboRecurso.SelectedValue.ToString());
                checkBoxCapinacaoLigado.Checked = false;
                objComboBox.Text = "Desligado";
            }
        }
        #endregion

        #region Capturador de  Padrões de Pixels
        private void checkBoxCapturadorLigado_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objComboBox = (CheckBox)sender;
            objComboBox.BackColor = Color.Transparent;
            objComboBox.ForeColor = Color.DimGray;
            if (objComboBox.Checked == true)
            {
                textBoxTituloCaptura.Focus();
                objComboBox.BackColor = Color.LightGreen;
                objComboBox.ForeColor = Color.DimGray;
                m_GlobalHook = Hook.GlobalEvents();
                CapturadorPixel.objModelTelaInicial = null;
                m_GlobalHook.MouseDownExt += obterPixelPorClique;
                if (checkBoxMostraPixelMovimentoMouse.Checked == true)
                {
                    m_GlobalHook.MouseMoveExt += exibirPixelMovimentoMouse;
                }
            }
            else
            {
                m_GlobalHook.MouseDownExt -= obterPixelPorClique;
                m_GlobalHook.MouseMoveExt -= exibirPixelMovimentoMouse;
                m_GlobalHook.Dispose();
            }
        }
        #endregion

        #region Exibir Pixel ao movimentar Mouse
        void exibirPixelMovimentoMouse(object sender, MouseEventArgs e)
        {
            if (checkBoxMostraPixelMovimentoMouse.Checked == true)
            {

                Color objColor = Service.Lib.Win32.GetPixelColor(MousePosition.X, MousePosition.Y);
                panelCorPixel.BackColor = objColor;
                labelCor.Text = "Cor (hex): [ " + Service.Common.Color.HexConverter(objColor) + " ]";
                labelEixoVerticalPixel.Text = "Eixo Vertical: [ " + MousePosition.Y + " ]";
                labelEixoHorizontalPixel.Text = "Eixo Horizontal: [ " + MousePosition.X + " ]";
            }
        }
        #endregion

        #region Obter Pixel por Clique
        void obterPixelPorClique(object sender, MouseEventArgs e)
        {
            try
            {
                Service.TelaCaptura objServiceTelaCaptura = Service.TelaCaptura.obterInstancia();
                using (Bitmap objBitmap = objServiceTelaCaptura.obterImagemTelaComo8bitesPorPixel())
                {
                    /*using (Service.Lib.LockBitmap objLockedBitmap = new Service.Lib.LockBitmap(objBitmap))
                    {
                        objLockedBitmap.LockBits();*/
                    Color myColor = objBitmap.GetPixel(e.X, e.Y);

                    ModelTela objModelTela = new ModelTela();
                    objModelTela.eixoHorizontal = e.Location.X;
                    objModelTela.eixoVertical = e.Location.Y;
                    objModelTela.pixel = Service.Common.Color.HexConverter(myColor);

                    panelCorPixel.BackColor = myColor;
                    labelCor.Text = "Cor (hex): [ " + (objModelTela.pixel) + " ]";
                    labelEixoVerticalPixel.Text = "Eixo Vertical: [ " + objModelTela.eixoVertical + " ]";
                    labelEixoHorizontalPixel.Text = "Eixo Horizontal: [ " + objModelTela.eixoHorizontal + " ]";

                    HSLColor objCorAtualHSL = Service.Lib.HSLColor.FromRGB(myColor);

                    labelMatiz.Text = "Matiz: " + objCorAtualHSL.Hue;
                    labelSaturacao.Text = "Saturacao: " + objCorAtualHSL.Saturation;
                    labelLuminosidade.Text = "Luminosidade: " + objCorAtualHSL.Luminosity;

                    if (checkBoxCapturaContinua.Checked == false)
                    {
                        checkBoxCapturadorLigado.Checked = false;
                        checkBoxVisualizarPixel.Checked = false;
                    }

                    if (checkBoxCapturadorLigado.Focused == false && checkBoxCapturadorLigado.Checked == true)
                    {
                        CapturadorPixel.armazenarCapturaComoTemplate(objModelTela, textBoxLocalizacaoPixelsCapturados.Text);
                        CapturadorPixel.armazenarLogCaptura(objModelTela, textBoxTituloCaptura.Text, textBoxLocalizacaoPixelsCapturados.Text);
                    }

                    //  objLockedBitmap.UnlockBits();
                    //}
                }
            }
            catch (Exception objException)
            {
                //MessageBox.Show(objException.ToString());
                throw new Exception(objException.ToString());
            }
        }
        #endregion

        #region Tirar Screenshot
        private void botaoScreenshot_Click(object sender, EventArgs e)
        {

            Service.TelaCaptura objServiceTelaCaptura = Service.TelaCaptura.obterInstancia();
            if (!String.IsNullOrEmpty(textBoxTransparencia.Text)) objServiceTelaCaptura.valorTransparencia = Int32.Parse(textBoxTransparencia.Text);

            objServiceTelaCaptura.valorTransparencia = objServiceTelaCaptura.obterValorTransparenciaPorHorario();

            using (Image<Gray, byte> source = new Image<Gray, byte>(objServiceTelaCaptura.obterImagemTelaComo8bitesPorPixel()))
            {
                source.Save(@textBoxLocalizacaoScreenshot.Text);
                MessageBox.Show("PrintScreen realizado com sucesso!");
            }
        }
        #endregion

        #region Visuar Pixel
        private void checkBoxVisualizarPixel_CheckedChanged(object sender, EventArgs e)
        {
            Service.TelaCaptura objServiceTelaCaptura = Service.TelaCaptura.obterInstancia();
            //objServiceTelaCaptura.valorTransparencia = objServiceTelaCaptura.obterValorTransparenciaPorHorario();

            if (!String.IsNullOrEmpty(textBoxTransparencia.Text)) objServiceTelaCaptura.valorTransparencia = Int32.Parse(textBoxTransparencia.Text);


            Image<Emgu.CV.Structure.Gray, byte> objImagemOrigem = new Image<Emgu.CV.Structure.Gray, byte>(TelaCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel()); // Image B

            Bitmap objBitmapTemplate = new Bitmap(@"C:\\Users\\Thunder\\Dropbox\\Docs\\gAMES\\Wakfu\\trigo.png");
            objBitmapTemplate = objServiceTelaCaptura.aplicarMascaraNegraImagem(objBitmapTemplate, objServiceTelaCaptura.valorTransparencia);
            objBitmapTemplate = objServiceTelaCaptura.converterImagemPara8bitesPorPixel(objBitmapTemplate);
            Image<Emgu.CV.Structure.Gray, byte> objTemplateBusca = new Image<Emgu.CV.Structure.Gray, byte>(objBitmapTemplate); // Image A
            
            using (Image<Emgu.CV.Structure.Gray, float> result = objImagemOrigem.MatchTemplate(objTemplateBusca, Emgu.CV.CvEnum.TM_TYPE.CV_TM_CCOEFF_NORMED))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > 0.5)
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    Win32.posicionarMouse(maxLocations[0].X, maxLocations[0].Y);
                    Win32.clicarBotaoEsquerdo(maxLocations[0].X, maxLocations[0].Y);
                    objImagemOrigem.Save("C:\\Users\\Public\\imagem_tela.bmp");
                    objTemplateBusca.Save("C:\\Users\\Public\\imagem_template.bmp");
                }
            }
            /*


            //MessageBox.Show(Service.TelaCaptura.obterInstancia().obterValorTransparenciaPorHorario().ToString());

            CheckBox objComboBox = (CheckBox)sender;
            objComboBox.BackColor = Color.Transparent;
            objComboBox.ForeColor = Color.DimGray;
            if (objComboBox.Checked == true)
            {
                textBoxTituloCaptura.Focus();
                objComboBox.BackColor = Color.LightGreen;
                objComboBox.ForeColor = Color.DimGray;

                m_GlobalHook = Hook.GlobalEvents();
                CapturadorPixel.objModelTelaInicial = null;
                m_GlobalHook.MouseDownExt += obterPixelPorClique;
                if (checkBoxMostraPixelMovimentoMouse.Checked == true)
                {
                    m_GlobalHook.MouseMoveExt += exibirPixelMovimentoMouse;
                }
            }
            else
            {
                m_GlobalHook.MouseDownExt -= obterPixelPorClique;
                m_GlobalHook.MouseMoveExt -= exibirPixelMovimentoMouse;
                m_GlobalHook.Dispose();
            }*/
        }
        #endregion

        #region Relógio Francês
        private void timerHorarioFrances_Tick(object sender, EventArgs e)
        {
            DateTime horarioaAtual = DateTime.Now;
            TimeZoneInfo tempoDeZonaFranca = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            DateTime horarioConvertido = TimeZoneInfo.ConvertTime(horarioaAtual, TimeZoneInfo.Local, tempoDeZonaFranca);

            labelHorarioFranca.Text = horarioConvertido.ToString("HH:mm:ss");
        }
        #endregion
    }
}