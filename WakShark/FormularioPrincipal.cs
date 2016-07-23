// https://github.com/gmamaladze/globalmousekeyhook
using System;
using System.Drawing;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using ServiceRecurso = Service.Recurso;
using CapturadorPixel = Common.CapturadorPixel;
using ServiceColeta = Service.Coleta;
using Service;
using Gma.System.MouseKeyHook;
using System.Drawing.Imaging;
using Common.Lib;
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

                Color objColor = Common.Lib.Win32.GetPixelColor(MousePosition.X, MousePosition.Y);
                panelCorPixel.BackColor = objColor;
                labelCor.Text = "Cor (hex): [ " + Common.ColorHelper.HexConverter(objColor) + " ]";
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
                    objModelTela.pixel = Common.ColorHelper.HexConverter(myColor);

                    panelCorPixel.BackColor = myColor;
                    labelCor.Text = "Cor (hex): [ " + (objModelTela.pixel) + " ]";
                    labelEixoVerticalPixel.Text = "Eixo Vertical: [ " + objModelTela.eixoVertical + " ]";
                    labelEixoHorizontalPixel.Text = "Eixo Horizontal: [ " + objModelTela.eixoHorizontal + " ]";

                    HSLColor objCorAtualHSL = Common.Lib.HSLColor.FromRGB(myColor);

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

        #region Visualizar Pixel
        private void checkBoxVisualizarPixel_CheckedChanged(object sender, EventArgs e)
        {
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
            }
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