// https://github.com/gmamaladze/globalmousekeyhook
using System;
using System.Drawing;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using CapturadorPixel = Common.CapturadorPixel;
using Common;
using ServiceColeta = Service.Coleta;
using Service;
using Gma.System.MouseKeyHook;
using System.Drawing.Imaging;
using Common.Lib;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Model;
using WindowsInput;
using WindowsInput.Native;

namespace WakBoy
{
    public partial class FormularioPrincipal : Form, IDisposable
    {
        private IKeyboardMouseEvents m_GlobalHook;
        private KeyboardHook hook;
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            string[] objDataSourceTipoBusca = new[] { "Coleta", "Batalha" };
            comboBoxTipoBusca.DataSource = objDataSourceTipoBusca;

            
            //newRecurso.tiposRecurso

            hook = new KeyboardHook ();
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(gatilhoTeclaPressionadaGlobalmente);
            // register the control + alt + F12 combination as hot key.
            // hook.RegisterHotKey(Common.Lib.ModifierKeys.Control | ModifierKeys.Alt, Keys.F12);
            hook.RegisterHotKey(Common.Lib.ModifierKeys.Shift, Keys.F4);
            
            //System.Diagnostics.Debug.WriteLine("taskA Status: {0}", taskA.Status);
        }

        void gatilhoTeclaPressionadaGlobalmente(object sender, KeyPressedEventArgs e)
        {
            if (this.checkBoxCacadorPixelsLigado.Checked == true) this.checkBoxCacadorPixelsLigado.Checked = false;
            else this.checkBoxCacadorPixelsLigado.Checked = true;
            //this.checkBoxCacadorPixelsLigado_CheckedChanged(this.checkBoxCapturadorLigado, EventArgs.Empty);
        }

        #region Iniciar Caça a Pixels

        private void buttonProcurarTemplate_Click(object sender, EventArgs e)
        {
            if (openFileDialogImagemTemplate.ShowDialog() == DialogResult.OK)
            {
                textBoxLocalizacaoImagemTemplate.Text = openFileDialogImagemTemplate.FileName;
            }
        }

        private void checkBoxCacadorPixelsLigado_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(textBoxLocalizacaoImagemTemplate.Text) && !String.IsNullOrEmpty(comboBoxTipoBusca.SelectedValue.ToString()))
            {
                CheckBox objCheckBox = (CheckBox)sender;
                this.checkBoxCacadorPixelsLigado.Checked = objCheckBox.Checked;
                if (objCheckBox.Checked == true)
                {
                    this.checkBoxCacadorPixelsLigado.BackColor = Color.Green;

                    ImagemCaptura.obterInstancia().isUtilizarMascaraLuminosidade = checkBoxMascaraLuminosidade.Checked;

                    Common.Lib.Win32.clicarBotaoEsquerdo(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);

                    Camera.obterInstancia().padronizarDistanciaCamera();

                    // Modificar esse trecho utilizado para teste, porque está sendo validado somente por 'coleta'. Quem sabe um switch não caia melhor?
                    if (comboBoxTipoBusca.SelectedValue.ToString() == "Coleta") {

                        // Responsável por permitir que o loop consiga ser encerrado utilizando as hotkeys ou clique no botão.
                        Task.Factory.StartNew(() =>
                        {
                            while (this.checkBoxCacadorPixelsLigado.Checked)
                            {
                                bool isSucessoNaColeta = ServiceColeta.obterInstancia().coletar(textBoxLocalizacaoImagemTemplate.Text, checkBoxAtivarBaixoConsumo.Checked);
                                if (!isSucessoNaColeta && checkBoxMovimentarAleatoriamente.Checked) {
                                    Personagem.obterInstancia().movimentarRandomicamente();
                                    Thread.Sleep(800);
                                }
                            }
                        });
                    }
                }
                else
                {
                    this.checkBoxCacadorPixelsLigado.BackColor = Color.Gray;
                }
            }
            else
            {
                MessageBox.Show("Preencha os campos obrigatórios.");
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
                using (Bitmap objBitmap = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel())
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
            Bitmap telaOriginal = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela(true);
            telaOriginal.Save(@textBoxLocalizacaoScreenshot.Text);
            telaOriginal.Dispose();
            MessageBox.Show("PrintScreen realizado com sucesso!");
        }
        #endregion

        #region Visualizar Pixel
        private void checkBoxVisualizarPixel_CheckedChanged(object sender, EventArgs e)
        {
            /*
            var Imagem = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Common.Imagem.EnumRegiaoImagem.COMPLETO, true);
            Imagem.Save(@"C:\Users\Public\Antes.png", ImageFormat.Png);
            ImagemTransformacao.obterInstancia().extrairRegiaoImagem(Imagem, Common.Imagem.EnumRegiaoImagem.LADO_ESQUERDO).Save(@"C:\Users\Public\depois_esquerdo.png", ImageFormat.Png);
            ImagemTransformacao.obterInstancia().extrairRegiaoImagem(Imagem, Common.Imagem.EnumRegiaoImagem.LADO_DIREITO).Save(@"C:\Users\Public\depois_direito.png", ImageFormat.Png);
            */
            //Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
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
        

        private void comboBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoBusca.SelectedItem == "Coleta")
            {
                //string[] objDataSourceTipoBusca = new[] { "Coleta", "Batalha" };
                Model.Recurso objRecurso = new Model.Recurso();
                comboBoxTipo.DataSource = new BindingSource(objRecurso.tiposRecurso, null);
                comboBoxTipo.ValueMember = "Value";
                comboBoxTipo.DisplayMember = "Key";
            }
            else
            {
                comboBoxTipo.DataSource = null;
            }
        }

        private void comboBoxTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipo.SelectedValue != null) {
                textBoxLocalizacaoImagemTemplate.Text = comboBoxTipo.SelectedValue.ToString();
                string localizacaoImagemTemplate = ((System.Collections.Generic.KeyValuePair<string, string>)comboBoxTipo.SelectedItem).Value;
                pictureBoxMiniaturaRecurso.Image = Image.FromFile(localizacaoImagemTemplate);
            } else {
                textBoxLocalizacaoImagemTemplate.Text = "";
            }
        }

        private void botaoScreenshotRotacionado_Click(object sender, EventArgs e)
        {
            float anguloRotacao = 315f;
            Bitmap telaOriginal = (Bitmap)ImagemCaptura.obterInstancia().obterImagemTela(true);
            telaOriginal = ImagemTransformacao.obterInstancia().redimensionarImagem(telaOriginal, telaOriginal.Width / 2, telaOriginal.Height);
            telaOriginal = ImagemTransformacao.obterInstancia().rotacionarImagem(telaOriginal, anguloRotacao);
            telaOriginal.Save(@textBoxLocalizacaoScreenshot.Text);
            telaOriginal.Dispose();
            MessageBox.Show("PrintScreen Rotacionado realizado com sucesso!");
        }
    }
}