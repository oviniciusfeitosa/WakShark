// https://github.com/gmamaladze/globalmousekeyhook
using System;
using System.Drawing;
using System.Windows.Forms;
using ModelTela = Model.Tela;
using CapturadorPixel = Common.CapturadorPixel;
using Common;
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

        int IndiceUltimaAcao = 1;

        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            try
            {

                comboBoxTipoBusca.DataSource = Enum.GetNames(typeof(EnumTipoBusca));
                comboBoxProfissao.DataSource = Enum.GetNames(typeof(EnumProfissoes));

                hook = new KeyboardHook();
                hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(gatilhoTeclaPressionadaGlobalmente);
                // register the control + alt + F12 combination as hot key.
                // hook.RegisterHotKey(Common.Lib.ModifierKeys.Control | ModifierKeys.Alt, Keys.F12);
                hook.RegisterHotKey(Common.Lib.ModifierKeys.Shift, Keys.F4);

                //System.Diagnostics.Debug.WriteLine("taskA Status: {0}", taskA.Status);
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
            }
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
            try
            {

                if (!String.IsNullOrEmpty(comboBoxTipoBusca.SelectedValue.ToString()))
                {
                    CheckBox objCheckBox = (CheckBox)sender;
                    this.checkBoxCacadorPixelsLigado.Checked = objCheckBox.Checked;
                    this.checkBoxCacadorPixelsLigado.BackColor = Color.Gray;
                    if (objCheckBox.Checked == true)
                    {
                        this.checkBoxCacadorPixelsLigado.BackColor = Color.Green;

                        ImagemCaptura.obterInstancia().isUtilizarMascaraLuminosidade = checkBoxMascaraLuminosidade.Checked;

                        Common.Lib.Win32.clicarBotaoEsquerdo(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);

                        Camera.obterInstancia().padronizarDistanciaCamera();

                        // Modificar esse trecho utilizado para teste, porque está sendo validado somente por 'coleta'. Quem sabe um switch não caia melhor?
                        if (EnumUtil.ParseEnum<EnumTipoBusca>(comboBoxTipoBusca.SelectedValue.ToString()) == EnumTipoBusca.Coleta)
                        {
                            ServiceRecurso objRecurso = ServiceRecurso.obterInstancia();
                            ServiceBotaoAcao objServiceBotaoAcao = ServiceBotaoAcao.obterInstancia();
                            Service.Busca objServiceBusca = Service.Busca.obterInstancia();
                            objServiceBusca.isAtivarModoBaixoConsumo = checkBoxAtivarBaixoConsumo.Checked;
                            
                            bool isMovimentarAleatoriamente = checkBoxMovimentarAleatoriamente.Checked;
                            EnumProfissoes objEnumProfissao = EnumUtil.ParseEnum<EnumProfissoes>(comboBoxProfissao.SelectedValue.ToString());

                            List<AViewModelColeta> listaColetas = new List<AViewModelColeta>();
                            for (int indice = 0; indice < this.IndiceUltimaAcao; indice++)
                            {
                                ComboBox comboboxRecurso = (ComboBox)this.obterControlPorName(this, "comboBoxRecurso_" + indice.ToString());
                                ComboBox comboboxAcao = (ComboBox)this.obterControlPorName(this, "comboBoxAcao_" + indice.ToString());

                                string nomeRecurso = ((KeyValuePair<string, string>)comboboxRecurso.SelectedItem).Key;
                                string nomeAcao = ((KeyValuePair<string, string>)comboboxAcao.SelectedItem).Key;

                                ABotaoAcao botaAcao = objServiceBotaoAcao.obterBotaoAcao(nomeAcao);
                                AViewModelColeta objAViewModelColeta = new Colheita();
                            
                                if (botaAcao != null && botaAcao is IPlantio)
                                {
                                    objAViewModelColeta = new Plantio();
                                }

                                objAViewModelColeta.objRecurso = objRecurso.obterRecurso(nomeRecurso, objEnumProfissao);
                                objAViewModelColeta.objABotaoAcao = botaAcao;
                                listaColetas.Add(objAViewModelColeta);
                            }

                            // Responsável por permitir que o loop consiga ser encerrado utilizando as hotkeys ou clique no botão.
                            Task.Factory.StartNew(() =>
                            {
                                while (this.checkBoxCacadorPixelsLigado.Checked)
                                {
                                    bool isSucessoNaColeta = true;
                                    foreach (AViewModelColeta objAViewModelColeta in listaColetas)
                                    {
                                        isSucessoNaColeta = true;
                                        while (isSucessoNaColeta && this.checkBoxCacadorPixelsLigado.Checked) {
                                            isSucessoNaColeta = objServiceBusca.buscar(objAViewModelColeta);
                                        }
                                    }
                                    if (!isSucessoNaColeta && isMovimentarAleatoriamente && this.checkBoxCacadorPixelsLigado.Checked)
                                    {
                                        Personagem.obterInstancia().movimentarAleatoriamente();
                                        Thread.Sleep(800);
                                    }
                                }
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Preencha os campos obrigatórios.");
                }
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message);
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

        private void popularInformacoesWakshark()
        {
            this.popularInformacoesWakshark(0);
        }

        private void popularInformacoesWakshark(int indiceInicial)
        {
            for(int indice = indiceInicial; indice < this.IndiceUltimaAcao; indice++)
            {
                ComboBox comboboxRecurso = (ComboBox)this.obterControlPorName(this, "comboBoxRecurso_" + indice.ToString());
                ComboBox comboboxAcao = (ComboBox)this.obterControlPorName(this, "comboBoxAcao_" + indice.ToString());

                comboboxRecurso.DataSource = null;
                comboboxAcao.DataSource = null;
                EnumTipoBusca objEnumTipoBusca = EnumUtil.ParseEnum<EnumTipoBusca>(comboBoxTipoBusca.SelectedItem.ToString());
                if (objEnumTipoBusca == EnumTipoBusca.Coleta && comboBoxProfissao.SelectedValue != null)
                {
                    EnumProfissoes objEnumProfissao = EnumUtil.ParseEnum<EnumProfissoes>(comboBoxProfissao.SelectedValue.ToString());
                    ServiceRecurso objServiceRecurso = ServiceRecurso.obterInstancia();
                    Dictionary<string, string> objListaRecursos = objServiceRecurso.obterListaSimplificadaRecursos(objEnumProfissao);

                    comboboxRecurso.DataSource = new BindingSource(objListaRecursos, null);
                    comboboxRecurso.ValueMember = "Value";
                    comboboxRecurso.DisplayMember = "Key";

                    ServiceBotaoAcao objServiceBotaoAcao = ServiceBotaoAcao.obterInstancia();
                    Dictionary<string, string> objListaAcoes = objServiceBotaoAcao.obterListaSimplificadaAcoes();
                    comboboxAcao.DataSource = new BindingSource(objListaAcoes, null);
                    comboboxAcao.ValueMember = "Value";
                    comboboxAcao.DisplayMember = "Key";
                }
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

        #region Carregamento de recursos
        private void comboBoxAcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox objComboBox = (ComboBox)sender;
            if (objComboBox.SelectedValue != null)
            {
                PictureBox objPictureBox = (PictureBox)obterControlPorName(this, "pictureBox_" + objComboBox.Name);
                string localizacaoImagemTemplate = ((KeyValuePair<string, string>)objComboBox.SelectedItem).Value;
                objPictureBox.Image = Image.FromFile(localizacaoImagemTemplate);
            }
        }
        #endregion

        #region Obtem um Control de acordo com o nome.
        public Control obterControlPorName(Control ParentCntl, string NameToSearch)
        {
            if (ParentCntl.Name == NameToSearch)
                return ParentCntl;

            foreach (Control ChildCntl in ParentCntl.Controls)
            {
                Control ResultCntl = obterControlPorName(ChildCntl, NameToSearch);
                if (ResultCntl != null)
                    return ResultCntl;
            }
            return null;
        }
        #endregion

        private void buttonAdicionarAcao_Click(object sender, EventArgs e)
        {
            GroupBox groupBox = CriarEstruturaAcoes();
            this.panelAcoes.Controls.Add(groupBox);
            this.popularInformacoesWakshark(IndiceUltimaAcao - 1);
        }

        public GroupBox CriarEstruturaAcoes()
        {

            int Top = IndiceUltimaAcao * 78;
            int Left = 9;
            
            Label labelRecurso = new System.Windows.Forms.Label();
            labelRecurso.AutoSize = true;
            labelRecurso.Location = this.labelRecurso.Location;
            labelRecurso.Name = "labelRecurso_" + IndiceUltimaAcao.ToString();
            labelRecurso.Size = this.labelRecurso.Size;
            labelRecurso.TabIndex = this.labelRecurso.TabIndex + IndiceUltimaAcao;
            labelRecurso.Text = this.labelRecurso.Text;

            ComboBox comboRecurso = new System.Windows.Forms.ComboBox();
            comboRecurso.FormattingEnabled = true;
            comboRecurso.Location = this.comboBoxRecurso_0.Location;
            comboRecurso.Name = "comboBoxRecurso_" + IndiceUltimaAcao.ToString();
            comboRecurso.Size = this.comboBoxRecurso_0.Size;
            comboRecurso.TabIndex = this.comboBoxRecurso_0.TabIndex + IndiceUltimaAcao;
            comboRecurso.SelectedIndexChanged += new System.EventHandler(this.comboBoxAcoes_SelectedIndexChanged);

            PictureBox pictureBoxRecurso = new PictureBox(); //pictureBox_comboBoxRecurso_0
            pictureBoxRecurso.Location = this.pictureBox_comboBoxRecurso_0.Location;
            pictureBoxRecurso.Name = "pictureBox_comboBoxRecurso_" + IndiceUltimaAcao.ToString();
            pictureBoxRecurso.Size = this.pictureBox_comboBoxRecurso_0.Size;
            pictureBoxRecurso.TabIndex = 17;
            pictureBoxRecurso.TabStop = false;

            Label labelAcao = new System.Windows.Forms.Label();
            labelAcao.AutoSize = true;
            labelAcao.Location = this.labelAcao.Location;
            labelAcao.Name = "labelAcao_" + IndiceUltimaAcao.ToString();
            labelAcao.Size = this.labelAcao.Size;
            labelAcao.TabIndex = this.labelAcao.TabIndex + IndiceUltimaAcao;
            labelAcao.Text = this.labelAcao.Text;

            ComboBox comboBoxAcao = new System.Windows.Forms.ComboBox();
            comboBoxAcao.FormattingEnabled = true;
            comboBoxAcao.Location = this.comboBoxAcao_0.Location;
            comboBoxAcao.Name = "comboBoxAcao_" + IndiceUltimaAcao.ToString();
            comboBoxAcao.Size = this.comboBoxAcao_0.Size;
            comboBoxAcao.TabIndex = this.comboBoxAcao_0.TabIndex + IndiceUltimaAcao;
            comboBoxAcao.SelectedIndexChanged += new System.EventHandler(this.comboBoxAcoes_SelectedIndexChanged);

            PictureBox pictureBoxAcao = new PictureBox(); //pictureBox_comboBoxRecurso_0
            pictureBoxAcao.Location = this.pictureBox_comboBoxAcao_0.Location;
            pictureBoxAcao.Name = "pictureBox_comboBoxAcao_" + IndiceUltimaAcao.ToString();
            pictureBoxAcao.Size = this.pictureBox_comboBoxAcao_0.Size;
            pictureBoxAcao.TabIndex = 17;
            pictureBoxAcao.TabStop = false;

            Label labelTempoMaximo = new System.Windows.Forms.Label();
            labelTempoMaximo.AutoSize = true;
            labelTempoMaximo.Location = this.labelTempoMaximo.Location;
            labelTempoMaximo.Name = "labelTempoMaximo_" + IndiceUltimaAcao.ToString();
            labelTempoMaximo.Size = this.labelTempoMaximo.Size;
            labelTempoMaximo.TabIndex = 24;
            labelTempoMaximo.Text = "Tempo Max.\r\n(Min)";
            labelTempoMaximo.TextAlign = System.Drawing.ContentAlignment.TopCenter;

            TextBox textBoxTempoMaximo = new TextBox();
            textBoxTempoMaximo.Location = this.textBoxTempoMaximo_0.Location;
            textBoxTempoMaximo.Name = "textBoxTempoMaximo_" + IndiceUltimaAcao;
            textBoxTempoMaximo.ShortcutsEnabled = false;
            textBoxTempoMaximo.Size = this.textBoxTempoMaximo_0.Size;
            textBoxTempoMaximo.TabIndex = this.textBoxTempoMaximo_0.TabIndex + IndiceUltimaAcao;
            textBoxTempoMaximo.Text = this.textBoxTempoMaximo_0.Text;
            textBoxTempoMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;


            GroupBox groupBox = new System.Windows.Forms.GroupBox();
            groupBox.Name = "groupBoxAcoes";
            groupBox.Size = new System.Drawing.Size(423, 68);
            groupBox.Location = new System.Drawing.Point(Left, Top);
            groupBox.TabIndex = 29 + IndiceUltimaAcao;
            groupBox.TabStop = false;
            groupBox.Text = "Ações";
            groupBox.Controls.Add(labelRecurso);
            groupBox.Controls.Add(comboRecurso);
            groupBox.Controls.Add(pictureBoxRecurso);
            groupBox.Controls.Add(labelAcao);
            groupBox.Controls.Add(comboBoxAcao);
            groupBox.Controls.Add(pictureBoxAcao);
            groupBox.Controls.Add(labelTempoMaximo);
            groupBox.Controls.Add(textBoxTempoMaximo);

            IndiceUltimaAcao = IndiceUltimaAcao + 1;

            return groupBox;
        }

    }
}