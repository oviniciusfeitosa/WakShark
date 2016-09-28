// https://github.com/gmamaladze/globalmousekeyhook
using System;
using System.Drawing;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using CapturadorPixel = Common.CapturadorPixel;
using Common;
using ServiceColeta = Service.Coleta;
using ServiceRecurso = Service.Recurso;
using ServiceBotaoAcao = Service.BotaoAcao;
using Service;
using Gma.System.MouseKeyHook;
using Common.Lib;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Model.Base;
using Service.Base;
using Service.Acao;
using Model.Base.Acao;

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
            comboBoxTipoBusca.DataSource = Enum.GetNames(typeof(EnumTipoBusca));
            comboBoxProfissao.DataSource = Enum.GetNames(typeof(EnumProfissoes));

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

        #region Iniciar WakShark
        
        private void checkBoxCacadorPixelsLigado_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!String.IsNullOrEmpty(comboBoxTipoBusca.SelectedValue.ToString()))
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
                    if (EnumUtil.ParseEnum<EnumTipoBusca>(comboBoxTipoBusca.SelectedValue.ToString()) == EnumTipoBusca.Coleta) {
                        ServiceRecurso objRecurso = ServiceRecurso.obterInstancia();
                        ServiceBotaoAcao objServiceBotaoAcao = ServiceBotaoAcao.obterInstancia();
                        string nomeRecurso = ((KeyValuePair<string, string>)comboBoxRecurso.SelectedItem).Key;
                        string nomeAcao = ((KeyValuePair<string, string>)comboBoxAcao.SelectedItem).Key;
                        ServiceColeta objServiceColeta = ServiceColeta.obterInstancia();
                        objServiceColeta.isAtivarModoBaixoConsumo = checkBoxAtivarBaixoConsumo.Checked;

                        string nomeRecurso2 = string.Empty;
                        string nomeAcao2 = string.Empty;
                        string nomeRecurso3 = string.Empty;
                        string nomeAcao3 = string.Empty;
                        bool isUtilizarRecursoSecundario = checkBoxUtilizarRecursoSecundario.Checked;
                        bool isUtilizarRecursoTerciario = checkBoxUtilizarRecursoTerciario.Checked;

                        if (isUtilizarRecursoSecundario == true && comboBoxAcao2.SelectedItem != null && comboBoxRecurso2.SelectedItem != null)
                        {
                            nomeRecurso2 = ((KeyValuePair<string, string>)comboBoxRecurso2.SelectedItem).Key;
                            nomeAcao2 = ((KeyValuePair<string, string>)comboBoxAcao2.SelectedItem).Key;
                            
                            if (isUtilizarRecursoTerciario == true && comboBoxAcao3.SelectedItem != null && comboBoxRecurso3.SelectedItem != null)
                            {
                                nomeRecurso3 = ((KeyValuePair<string, string>)comboBoxRecurso3.SelectedItem).Key;
                                nomeAcao3 = ((KeyValuePair<string, string>)comboBoxAcao3.SelectedItem).Key;
                            }
                        }

                        bool isMovimentarAleatoriamente = checkBoxMovimentarAleatoriamente.Checked;
                        EnumProfissoes objEnumProfissao = EnumUtil.ParseEnum<EnumProfissoes>(comboBoxProfissao.SelectedValue.ToString());
                        
                        ABotaoAcao botaAcao1 = objServiceBotaoAcao.obterBotaoAcao(nomeAcao);
                        AViewModelColeta objAViewModelColeta1 = new Colheita();
                        ABotaoAcao botaAcao2 = objServiceBotaoAcao.obterBotaoAcao(nomeAcao2);
                        AViewModelColeta objAViewModelColeta2 = new Colheita();
                        ABotaoAcao botaAcao3 = objServiceBotaoAcao.obterBotaoAcao(nomeAcao3);
                        AViewModelColeta objAViewModelColeta3 = new Colheita();
                        if(botaAcao1 != null && botaAcao1 is IPlantio)
                        {
                            objAViewModelColeta1 = new Plantio();
                        }
                        if (botaAcao2 != null && botaAcao2 is IPlantio)
                        {
                            objAViewModelColeta2 = new Plantio();
                        }
                        if (botaAcao3 != null && botaAcao3 is IPlantio)
                        {
                            objAViewModelColeta3 = new Plantio();
                        }

                        objAViewModelColeta1.objRecurso = objRecurso.obterRecurso(nomeRecurso, objEnumProfissao);
                        objAViewModelColeta1.objABotaoAcao = botaAcao1;
                        

                        // Responsável por permitir que o loop consiga ser encerrado utilizando as hotkeys ou clique no botão.
                        Task.Factory.StartNew(() =>
                        {
                            while (this.checkBoxCacadorPixelsLigado.Checked)
                            {
                                
                                bool isSucessoNaColeta = objServiceColeta.coletar(objAViewModelColeta1);
                                if (!isSucessoNaColeta) {
                                    if (isUtilizarRecursoSecundario && botaAcao2 != null)
                                    {
                                        objAViewModelColeta2.objRecurso = objRecurso.obterRecurso(nomeRecurso2, objEnumProfissao);
                                        objAViewModelColeta2.objABotaoAcao = botaAcao2;
                                        isSucessoNaColeta = true;
                                        while (isSucessoNaColeta && this.checkBoxCacadorPixelsLigado.Checked)
                                        {
                                            isSucessoNaColeta = objServiceColeta.coletar(objAViewModelColeta2);
                                        }
                                        if (!isSucessoNaColeta && isUtilizarRecursoTerciario && botaAcao3 != null)
                                        {
                                            objAViewModelColeta3.objRecurso = objRecurso.obterRecurso(nomeRecurso3, objEnumProfissao);
                                            objAViewModelColeta3.objABotaoAcao = botaAcao3;
                                            isSucessoNaColeta = true;
                                            while (isSucessoNaColeta && this.checkBoxCacadorPixelsLigado.Checked)
                                            {
                                                isSucessoNaColeta = objServiceColeta.coletar(objAViewModelColeta3);
                                            }
                                        }
                                    }
                                    
                                    if (!isSucessoNaColeta && isMovimentarAleatoriamente) {
                                        Personagem.obterInstancia().movimentarAleatoriamente();
                                        Thread.Sleep(800);
                                    }
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

        private void comboBoxProfissao_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.popularInformacoesWakshark();
        }

        private void comboBoxTipoBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.popularInformacoesWakshark();
        }

        private void popularInformacoesWakshark() {
            comboBoxRecurso.DataSource = null;
            comboBoxAcao.DataSource = null;
            EnumTipoBusca objEnumTipoBusca = EnumUtil.ParseEnum<EnumTipoBusca>(comboBoxTipoBusca.SelectedItem.ToString());
            if (objEnumTipoBusca == EnumTipoBusca.Coleta && comboBoxProfissao.SelectedValue != null)
            {
                EnumProfissoes objEnumProfissao = EnumUtil.ParseEnum<EnumProfissoes>(comboBoxProfissao.SelectedValue.ToString());
                ServiceRecurso objServiceRecurso = ServiceRecurso.obterInstancia();
                Dictionary<string, string> objListaRecursos = objServiceRecurso.obterListaSimplificadaRecursos(objEnumProfissao);

                comboBoxRecurso.DataSource = new BindingSource(objListaRecursos, null);
                comboBoxRecurso.ValueMember = "Value";
                comboBoxRecurso.DisplayMember = "Key";

                comboBoxRecurso2.DataSource = new BindingSource(objListaRecursos, null);
                comboBoxRecurso2.ValueMember = "Value";
                comboBoxRecurso2.DisplayMember = "Key";

                comboBoxRecurso3.DataSource = new BindingSource(objListaRecursos, null);
                comboBoxRecurso3.ValueMember = "Value";
                comboBoxRecurso3.DisplayMember = "Key";

                ServiceBotaoAcao objServiceBotaoAcao = ServiceBotaoAcao.obterInstancia();
                Dictionary<string, string> objListaAcoes = objServiceBotaoAcao.obterListaSimplificadaAcoes();
                comboBoxAcao.DataSource = new BindingSource(objListaAcoes, null);
                comboBoxAcao.ValueMember = "Value";
                comboBoxAcao.DisplayMember = "Key";

                comboBoxAcao2.DataSource = new BindingSource(objListaAcoes, null);
                comboBoxAcao2.ValueMember = "Value";
                comboBoxAcao2.DisplayMember = "Key";

                comboBoxAcao3.DataSource = new BindingSource(objListaAcoes, null);
                comboBoxAcao3.ValueMember = "Value";
                comboBoxAcao3.DisplayMember = "Key";
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

        #region Seleção de quantidades de recursos
        private void checkBoxUtilizarRecursoSecundario_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objCheckbox = (CheckBox)sender;
            groupBoxRecursoSecundario.Visible = false;
            if (objCheckbox.Checked)
            {
                groupBoxRecursoSecundario.Visible = true;
            }
        }

        private void checkBoxUtilizarRecursoTerciario_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox objCheckbox = (CheckBox)sender;
            groupBoxRecursoTerciario.Visible = false;
            if (objCheckbox.Checked)
            {
                groupBoxRecursoTerciario.Visible = true;
            }
        }
        #endregion

        #region Carregamento de recursos
        private void comboBoxRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null) {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;
                pictureBoxMiniaturaRecurso.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }

        private void comboBoxRecurso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null)
            {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;
                
                pictureBoxMiniaturaRecurso2.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }

        private void comboBoxRecurso3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null)
            {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;

                pictureBoxMiniaturaRecurso3.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }
        #endregion

        #region carregamento de ações
        private void comboBoxAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAcao.Items.Count > 0 && comboBoxAcao.SelectedItem != null)
            {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)comboBoxAcao.SelectedItem).Value;
                pictureBoxMiniaturaAcao.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }

        private void comboBoxAcao2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null)
            {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;
                pictureBoxMiniaturaAcao2.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }

        private void comboBoxAcao3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null)
            {
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;
                pictureBoxMiniaturaAcao3.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }
        #endregion

        
    }
}