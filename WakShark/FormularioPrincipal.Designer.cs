namespace WakBoy
{
    public partial class FormularioPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioPrincipal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.capinacao = new System.Windows.Forms.TabPage();
            this.panelAcoes = new System.Windows.Forms.Panel();
            this.groupBoxAcoes = new System.Windows.Forms.GroupBox();
            this.textBoxTempoMaximo_0 = new System.Windows.Forms.TextBox();
            this.labelTempoMaximo = new System.Windows.Forms.Label();
            this.comboBoxRecurso_0 = new System.Windows.Forms.ComboBox();
            this.pictureBox_comboBoxAcao_0 = new System.Windows.Forms.PictureBox();
            this.labelRecurso = new System.Windows.Forms.Label();
            this.pictureBox_comboBoxRecurso_0 = new System.Windows.Forms.PictureBox();
            this.comboBoxAcao_0 = new System.Windows.Forms.ComboBox();
            this.labelAcao = new System.Windows.Forms.Label();
            this.buttonAdicionarAcao = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxProfissao = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxMovimentarAleatoriamente = new System.Windows.Forms.CheckBox();
            this.checkBoxAtivarBaixoConsumo = new System.Windows.Forms.CheckBox();
            this.checkBoxMascaraLuminosidade = new System.Windows.Forms.CheckBox();
            this.labelObrigatorio = new System.Windows.Forms.Label();
            this.comboBoxTipoBusca = new System.Windows.Forms.ComboBox();
            this.labelTipoBusca = new System.Windows.Forms.Label();
            this.checkBoxCacadorPixelsLigado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.abaCapturadorPixels = new System.Windows.Forms.TabPage();
            this.botaoScreenshotRotacionado = new System.Windows.Forms.Button();
            this.labelHorarioFranca = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTransparencia = new System.Windows.Forms.TextBox();
            this.labelTransparencia = new System.Windows.Forms.Label();
            this.checkBoxVisualizarPixel = new System.Windows.Forms.CheckBox();
            this.labelLuminosidade = new System.Windows.Forms.Label();
            this.labelSaturacao = new System.Windows.Forms.Label();
            this.labelMatiz = new System.Windows.Forms.Label();
            this.textBoxLocalizacaoScreenshot = new System.Windows.Forms.TextBox();
            this.botaoScreenshot = new System.Windows.Forms.Button();
            this.checkBoxMostraPixelMovimentoMouse = new System.Windows.Forms.CheckBox();
            this.checkBoxCapturaContinua = new System.Windows.Forms.CheckBox();
            this.textBoxLocalizacaoPixelsCapturados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTituloCaptura = new System.Windows.Forms.Label();
            this.textBoxTituloCaptura = new System.Windows.Forms.TextBox();
            this.labelEixoHorizontalPixel = new System.Windows.Forms.Label();
            this.labelEixoVerticalPixel = new System.Windows.Forms.Label();
            this.panelCorPixel = new System.Windows.Forms.Panel();
            this.checkBoxCapturadorLigado = new System.Windows.Forms.CheckBox();
            this.labelCor = new System.Windows.Forms.Label();
            this.timerHorarioFrances = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogImagemTemplate = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.capinacao.SuspendLayout();
            this.panelAcoes.SuspendLayout();
            this.groupBoxAcoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_comboBoxAcao_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_comboBoxRecurso_0)).BeginInit();
            this.abaCapturadorPixels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.capinacao);
            this.tabControl1.Controls.Add(this.abaCapturadorPixels);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(566, 414);
            this.tabControl1.TabIndex = 1;
            // 
            // capinacao
            // 
            this.capinacao.Controls.Add(this.panelAcoes);
            this.capinacao.Controls.Add(this.label12);
            this.capinacao.Controls.Add(this.label4);
            this.capinacao.Controls.Add(this.comboBoxProfissao);
            this.capinacao.Controls.Add(this.label9);
            this.capinacao.Controls.Add(this.checkBoxMovimentarAleatoriamente);
            this.capinacao.Controls.Add(this.checkBoxAtivarBaixoConsumo);
            this.capinacao.Controls.Add(this.checkBoxMascaraLuminosidade);
            this.capinacao.Controls.Add(this.labelObrigatorio);
            this.capinacao.Controls.Add(this.comboBoxTipoBusca);
            this.capinacao.Controls.Add(this.labelTipoBusca);
            this.capinacao.Controls.Add(this.checkBoxCacadorPixelsLigado);
            this.capinacao.Controls.Add(this.label1);
            this.capinacao.Location = new System.Drawing.Point(4, 22);
            this.capinacao.Name = "capinacao";
            this.capinacao.Padding = new System.Windows.Forms.Padding(3);
            this.capinacao.Size = new System.Drawing.Size(558, 388);
            this.capinacao.TabIndex = 0;
            this.capinacao.Text = "WakShark";
            this.capinacao.UseVisualStyleBackColor = true;
            // 
            // panelAcoes
            // 
            this.panelAcoes.AutoScroll = true;
            this.panelAcoes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAcoes.Controls.Add(this.groupBoxAcoes);
            this.panelAcoes.Controls.Add(this.buttonAdicionarAcao);
            this.panelAcoes.Location = new System.Drawing.Point(9, 35);
            this.panelAcoes.Name = "panelAcoes";
            this.panelAcoes.Size = new System.Drawing.Size(539, 241);
            this.panelAcoes.TabIndex = 31;
            // 
            // groupBoxAcoes
            // 
            this.groupBoxAcoes.Controls.Add(this.textBoxTempoMaximo_0);
            this.groupBoxAcoes.Controls.Add(this.labelTempoMaximo);
            this.groupBoxAcoes.Controls.Add(this.comboBoxRecurso_0);
            this.groupBoxAcoes.Controls.Add(this.pictureBox_comboBoxAcao_0);
            this.groupBoxAcoes.Controls.Add(this.labelRecurso);
            this.groupBoxAcoes.Controls.Add(this.pictureBox_comboBoxRecurso_0);
            this.groupBoxAcoes.Controls.Add(this.comboBoxAcao_0);
            this.groupBoxAcoes.Controls.Add(this.labelAcao);
            this.groupBoxAcoes.Location = new System.Drawing.Point(9, 3);
            this.groupBoxAcoes.Name = "groupBoxAcoes";
            this.groupBoxAcoes.Size = new System.Drawing.Size(423, 68);
            this.groupBoxAcoes.TabIndex = 29;
            this.groupBoxAcoes.TabStop = false;
            this.groupBoxAcoes.Text = "Ações";
            // 
            // textBoxTempoMaximo_0
            // 
            this.textBoxTempoMaximo_0.Location = new System.Drawing.Point(362, 41);
            this.textBoxTempoMaximo_0.Name = "textBoxTempoMaximo_0";
            this.textBoxTempoMaximo_0.ShortcutsEnabled = false;
            this.textBoxTempoMaximo_0.Size = new System.Drawing.Size(21, 20);
            this.textBoxTempoMaximo_0.TabIndex = 25;
            this.textBoxTempoMaximo_0.Text = "0";
            this.textBoxTempoMaximo_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelTempoMaximo
            // 
            this.labelTempoMaximo.AutoSize = true;
            this.labelTempoMaximo.Location = new System.Drawing.Point(342, 12);
            this.labelTempoMaximo.Name = "labelTempoMaximo_0";
            this.labelTempoMaximo.Size = new System.Drawing.Size(66, 26);
            this.labelTempoMaximo.TabIndex = 24;
            this.labelTempoMaximo.Text = "Tempo Max.\r\n(Min)";
            this.labelTempoMaximo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxRecurso_0
            // 
            this.comboBoxRecurso_0.FormattingEnabled = true;
            this.comboBoxRecurso_0.Location = new System.Drawing.Point(79, 12);
            this.comboBoxRecurso_0.Name = "comboBoxRecurso_0";
            this.comboBoxRecurso_0.Size = new System.Drawing.Size(221, 21);
            this.comboBoxRecurso_0.TabIndex = 16;
            this.comboBoxRecurso_0.SelectedIndexChanged += new System.EventHandler(this.comboBoxAcoes_SelectedIndexChanged);
            // 
            // pictureBox_comboBoxAcao_0
            // 
            this.pictureBox_comboBoxAcao_0.Location = new System.Drawing.Point(306, 41);
            this.pictureBox_comboBoxAcao_0.Name = "pictureBox_comboBoxAcao_0";
            this.pictureBox_comboBoxAcao_0.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_comboBoxAcao_0.TabIndex = 23;
            this.pictureBox_comboBoxAcao_0.TabStop = false;
            // 
            // labelRecurso
            // 
            this.labelRecurso.AutoSize = true;
            this.labelRecurso.Location = new System.Drawing.Point(20, 17);
            this.labelRecurso.Name = "labelRecurso";
            this.labelRecurso.Size = new System.Drawing.Size(53, 13);
            this.labelRecurso.TabIndex = 15;
            this.labelRecurso.Text = "Recurso :";
            // 
            // pictureBox_comboBoxRecurso_0
            // 
            this.pictureBox_comboBoxRecurso_0.Location = new System.Drawing.Point(306, 12);
            this.pictureBox_comboBoxRecurso_0.Name = "pictureBox_comboBoxRecurso_0";
            this.pictureBox_comboBoxRecurso_0.Size = new System.Drawing.Size(20, 20);
            this.pictureBox_comboBoxRecurso_0.TabIndex = 17;
            this.pictureBox_comboBoxRecurso_0.TabStop = false;
            // 
            // comboBoxAcao_0
            // 
            this.comboBoxAcao_0.FormattingEnabled = true;
            this.comboBoxAcao_0.Location = new System.Drawing.Point(80, 39);
            this.comboBoxAcao_0.Name = "comboBoxAcao_0";
            this.comboBoxAcao_0.Size = new System.Drawing.Size(221, 21);
            this.comboBoxAcao_0.TabIndex = 22;
            this.comboBoxAcao_0.SelectedIndexChanged += new System.EventHandler(this.comboBoxAcoes_SelectedIndexChanged);
            // 
            // labelAcao
            // 
            this.labelAcao.AutoSize = true;
            this.labelAcao.Location = new System.Drawing.Point(23, 41);
            this.labelAcao.Name = "labelAcao";
            this.labelAcao.Size = new System.Drawing.Size(35, 13);
            this.labelAcao.TabIndex = 21;
            this.labelAcao.Text = "Ação:";
            // 
            // buttonAdicionarAcao
            // 
            this.buttonAdicionarAcao.Location = new System.Drawing.Point(448, 18);
            this.buttonAdicionarAcao.Name = "buttonAdicionarAcao";
            this.buttonAdicionarAcao.Size = new System.Drawing.Size(60, 23);
            this.buttonAdicionarAcao.TabIndex = 30;
            this.buttonAdicionarAcao.Text = "+ Acao";
            this.buttonAdicionarAcao.UseVisualStyleBackColor = true;
            this.buttonAdicionarAcao.Click += new System.EventHandler(this.buttonAdicionarAcao_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Orange;
            this.label12.Location = new System.Drawing.Point(16, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(198, 26);
            this.label12.TabIndex = 28;
            this.label12.Text = "OBS: Para plantar, o recurso deve estar \r\nna tecla de atalho SHIFT + 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(281, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "*";
            // 
            // comboBoxProfissao
            // 
            this.comboBoxProfissao.FormattingEnabled = true;
            this.comboBoxProfissao.Location = new System.Drawing.Point(296, 8);
            this.comboBoxProfissao.Name = "comboBoxProfissao";
            this.comboBoxProfissao.Size = new System.Drawing.Size(121, 21);
            this.comboBoxProfissao.TabIndex = 26;
            this.comboBoxProfissao.SelectedIndexChanged += new System.EventHandler(this.comboBoxProfissao_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(233, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Profissão:";
            // 
            // checkBoxMovimentarAleatoriamente
            // 
            this.checkBoxMovimentarAleatoriamente.AutoSize = true;
            this.checkBoxMovimentarAleatoriamente.Checked = true;
            this.checkBoxMovimentarAleatoriamente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMovimentarAleatoriamente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMovimentarAleatoriamente.Location = new System.Drawing.Point(220, 329);
            this.checkBoxMovimentarAleatoriamente.Name = "checkBoxMovimentarAleatoriamente";
            this.checkBoxMovimentarAleatoriamente.Size = new System.Drawing.Size(152, 17);
            this.checkBoxMovimentarAleatoriamente.TabIndex = 18;
            this.checkBoxMovimentarAleatoriamente.Text = "Ativar Movimento Aleatório";
            this.checkBoxMovimentarAleatoriamente.UseVisualStyleBackColor = true;
            // 
            // checkBoxAtivarBaixoConsumo
            // 
            this.checkBoxAtivarBaixoConsumo.AutoSize = true;
            this.checkBoxAtivarBaixoConsumo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAtivarBaixoConsumo.Location = new System.Drawing.Point(220, 306);
            this.checkBoxAtivarBaixoConsumo.Name = "checkBoxAtivarBaixoConsumo";
            this.checkBoxAtivarBaixoConsumo.Size = new System.Drawing.Size(159, 17);
            this.checkBoxAtivarBaixoConsumo.TabIndex = 17;
            this.checkBoxAtivarBaixoConsumo.Text = "Ativar Modo Baixo Consumo";
            this.checkBoxAtivarBaixoConsumo.UseVisualStyleBackColor = true;
            // 
            // checkBoxMascaraLuminosidade
            // 
            this.checkBoxMascaraLuminosidade.AutoSize = true;
            this.checkBoxMascaraLuminosidade.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxMascaraLuminosidade.Location = new System.Drawing.Point(222, 282);
            this.checkBoxMascaraLuminosidade.Name = "checkBoxMascaraLuminosidade";
            this.checkBoxMascaraLuminosidade.Size = new System.Drawing.Size(180, 17);
            this.checkBoxMascaraLuminosidade.TabIndex = 15;
            this.checkBoxMascaraLuminosidade.Text = "Ativar Máscara de Luminosidade";
            this.checkBoxMascaraLuminosidade.UseVisualStyleBackColor = true;
            // 
            // labelObrigatorio
            // 
            this.labelObrigatorio.AutoSize = true;
            this.labelObrigatorio.ForeColor = System.Drawing.Color.Red;
            this.labelObrigatorio.Location = new System.Drawing.Point(67, 8);
            this.labelObrigatorio.Name = "labelObrigatorio";
            this.labelObrigatorio.Size = new System.Drawing.Size(11, 13);
            this.labelObrigatorio.TabIndex = 13;
            this.labelObrigatorio.Text = "*";
            // 
            // comboBoxTipoBusca
            // 
            this.comboBoxTipoBusca.FormattingEnabled = true;
            this.comboBoxTipoBusca.Location = new System.Drawing.Point(84, 8);
            this.comboBoxTipoBusca.Name = "comboBoxTipoBusca";
            this.comboBoxTipoBusca.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTipoBusca.TabIndex = 9;
            this.comboBoxTipoBusca.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoBusca_SelectedIndexChanged);
            // 
            // labelTipoBusca
            // 
            this.labelTipoBusca.AutoSize = true;
            this.labelTipoBusca.Location = new System.Drawing.Point(6, 8);
            this.labelTipoBusca.Name = "labelTipoBusca";
            this.labelTipoBusca.Size = new System.Drawing.Size(64, 13);
            this.labelTipoBusca.TabIndex = 8;
            this.labelTipoBusca.Text = "Tipo Busca:";
            // 
            // checkBoxCacadorPixelsLigado
            // 
            this.checkBoxCacadorPixelsLigado.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCacadorPixelsLigado.AutoSize = true;
            this.checkBoxCacadorPixelsLigado.Location = new System.Drawing.Point(284, 352);
            this.checkBoxCacadorPixelsLigado.Name = "checkBoxCacadorPixelsLigado";
            this.checkBoxCacadorPixelsLigado.Size = new System.Drawing.Size(45, 23);
            this.checkBoxCacadorPixelsLigado.TabIndex = 7;
            this.checkBoxCacadorPixelsLigado.Text = "Iniciar";
            this.checkBoxCacadorPixelsLigado.UseVisualStyleBackColor = true;
            this.checkBoxCacadorPixelsLigado.CheckedChanged += new System.EventHandler(this.checkBoxCacadorPixelsLigado_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(16, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SHIFT + F4  - INICIAR / PARAR ";
            // 
            // abaCapturadorPixels
            // 
            this.abaCapturadorPixels.Controls.Add(this.botaoScreenshotRotacionado);
            this.abaCapturadorPixels.Controls.Add(this.labelHorarioFranca);
            this.abaCapturadorPixels.Controls.Add(this.label3);
            this.abaCapturadorPixels.Controls.Add(this.textBoxTransparencia);
            this.abaCapturadorPixels.Controls.Add(this.labelTransparencia);
            this.abaCapturadorPixels.Controls.Add(this.checkBoxVisualizarPixel);
            this.abaCapturadorPixels.Controls.Add(this.labelLuminosidade);
            this.abaCapturadorPixels.Controls.Add(this.labelSaturacao);
            this.abaCapturadorPixels.Controls.Add(this.labelMatiz);
            this.abaCapturadorPixels.Controls.Add(this.textBoxLocalizacaoScreenshot);
            this.abaCapturadorPixels.Controls.Add(this.botaoScreenshot);
            this.abaCapturadorPixels.Controls.Add(this.checkBoxMostraPixelMovimentoMouse);
            this.abaCapturadorPixels.Controls.Add(this.checkBoxCapturaContinua);
            this.abaCapturadorPixels.Controls.Add(this.textBoxLocalizacaoPixelsCapturados);
            this.abaCapturadorPixels.Controls.Add(this.label2);
            this.abaCapturadorPixels.Controls.Add(this.labelTituloCaptura);
            this.abaCapturadorPixels.Controls.Add(this.textBoxTituloCaptura);
            this.abaCapturadorPixels.Controls.Add(this.labelEixoHorizontalPixel);
            this.abaCapturadorPixels.Controls.Add(this.labelEixoVerticalPixel);
            this.abaCapturadorPixels.Controls.Add(this.panelCorPixel);
            this.abaCapturadorPixels.Controls.Add(this.checkBoxCapturadorLigado);
            this.abaCapturadorPixels.Controls.Add(this.labelCor);
            this.abaCapturadorPixels.Location = new System.Drawing.Point(4, 22);
            this.abaCapturadorPixels.Name = "abaCapturadorPixels";
            this.abaCapturadorPixels.Padding = new System.Windows.Forms.Padding(3);
            this.abaCapturadorPixels.Size = new System.Drawing.Size(558, 388);
            this.abaCapturadorPixels.TabIndex = 1;
            this.abaCapturadorPixels.Text = "Ferramentas";
            this.abaCapturadorPixels.UseVisualStyleBackColor = true;
            // 
            // botaoScreenshotRotacionado
            // 
            this.botaoScreenshotRotacionado.Location = new System.Drawing.Point(129, 218);
            this.botaoScreenshotRotacionado.Name = "botaoScreenshotRotacionado";
            this.botaoScreenshotRotacionado.Size = new System.Drawing.Size(133, 23);
            this.botaoScreenshotRotacionado.TabIndex = 22;
            this.botaoScreenshotRotacionado.Text = "Screenshot Rotacionado";
            this.botaoScreenshotRotacionado.UseVisualStyleBackColor = true;
            this.botaoScreenshotRotacionado.Click += new System.EventHandler(this.botaoScreenshotRotacionado_Click);
            // 
            // labelHorarioFranca
            // 
            this.labelHorarioFranca.AutoSize = true;
            this.labelHorarioFranca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHorarioFranca.Location = new System.Drawing.Point(125, 315);
            this.labelHorarioFranca.Name = "labelHorarioFranca";
            this.labelHorarioFranca.Size = new System.Drawing.Size(51, 15);
            this.labelHorarioFranca.TabIndex = 21;
            this.labelHorarioFranca.Text = "00:00:00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Horário Atual (França):";
            // 
            // textBoxTransparencia
            // 
            this.textBoxTransparencia.Location = new System.Drawing.Point(138, 292);
            this.textBoxTransparencia.Name = "textBoxTransparencia";
            this.textBoxTransparencia.Size = new System.Drawing.Size(38, 20);
            this.textBoxTransparencia.TabIndex = 19;
            // 
            // labelTransparencia
            // 
            this.labelTransparencia.AutoSize = true;
            this.labelTransparencia.Location = new System.Drawing.Point(9, 295);
            this.labelTransparencia.Name = "labelTransparencia";
            this.labelTransparencia.Size = new System.Drawing.Size(123, 13);
            this.labelTransparencia.TabIndex = 18;
            this.labelTransparencia.Text = "Transparência (0 - 255) :";
            // 
            // checkBoxVisualizarPixel
            // 
            this.checkBoxVisualizarPixel.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxVisualizarPixel.AutoSize = true;
            this.checkBoxVisualizarPixel.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxVisualizarPixel.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxVisualizarPixel.Location = new System.Drawing.Point(9, 223);
            this.checkBoxVisualizarPixel.Name = "checkBoxVisualizarPixel";
            this.checkBoxVisualizarPixel.Size = new System.Drawing.Size(86, 23);
            this.checkBoxVisualizarPixel.TabIndex = 17;
            this.checkBoxVisualizarPixel.Text = "Visualizar Pixel";
            this.checkBoxVisualizarPixel.UseVisualStyleBackColor = false;
            this.checkBoxVisualizarPixel.CheckedChanged += new System.EventHandler(this.checkBoxVisualizarPixel_CheckedChanged);
            // 
            // labelLuminosidade
            // 
            this.labelLuminosidade.AutoSize = true;
            this.labelLuminosidade.Location = new System.Drawing.Point(300, 169);
            this.labelLuminosidade.Name = "labelLuminosidade";
            this.labelLuminosidade.Size = new System.Drawing.Size(75, 13);
            this.labelLuminosidade.TabIndex = 16;
            this.labelLuminosidade.Text = "Luminosidade:";
            // 
            // labelSaturacao
            // 
            this.labelSaturacao.AutoSize = true;
            this.labelSaturacao.Location = new System.Drawing.Point(300, 146);
            this.labelSaturacao.Name = "labelSaturacao";
            this.labelSaturacao.Size = new System.Drawing.Size(59, 13);
            this.labelSaturacao.TabIndex = 15;
            this.labelSaturacao.Text = "Saturação:";
            // 
            // labelMatiz
            // 
            this.labelMatiz.AutoSize = true;
            this.labelMatiz.Location = new System.Drawing.Point(300, 122);
            this.labelMatiz.Name = "labelMatiz";
            this.labelMatiz.Size = new System.Drawing.Size(35, 13);
            this.labelMatiz.TabIndex = 14;
            this.labelMatiz.Text = "Matiz:";
            // 
            // textBoxLocalizacaoScreenshot
            // 
            this.textBoxLocalizacaoScreenshot.Location = new System.Drawing.Point(211, 254);
            this.textBoxLocalizacaoScreenshot.Name = "textBoxLocalizacaoScreenshot";
            this.textBoxLocalizacaoScreenshot.Size = new System.Drawing.Size(164, 20);
            this.textBoxLocalizacaoScreenshot.TabIndex = 13;
            this.textBoxLocalizacaoScreenshot.Text = "C:\\Users\\Public\\imagem.bmp";
            // 
            // botaoScreenshot
            // 
            this.botaoScreenshot.Location = new System.Drawing.Point(129, 252);
            this.botaoScreenshot.Name = "botaoScreenshot";
            this.botaoScreenshot.Size = new System.Drawing.Size(75, 23);
            this.botaoScreenshot.TabIndex = 12;
            this.botaoScreenshot.Text = "Screenshot";
            this.botaoScreenshot.UseVisualStyleBackColor = true;
            this.botaoScreenshot.Click += new System.EventHandler(this.botaoScreenshot_Click);
            // 
            // checkBoxMostraPixelMovimentoMouse
            // 
            this.checkBoxMostraPixelMovimentoMouse.AutoSize = true;
            this.checkBoxMostraPixelMovimentoMouse.Location = new System.Drawing.Point(106, 97);
            this.checkBoxMostraPixelMovimentoMouse.Name = "checkBoxMostraPixelMovimentoMouse";
            this.checkBoxMostraPixelMovimentoMouse.Size = new System.Drawing.Size(156, 17);
            this.checkBoxMostraPixelMovimentoMouse.TabIndex = 11;
            this.checkBoxMostraPixelMovimentoMouse.Text = "Exibir pixel ao mover mouse";
            this.checkBoxMostraPixelMovimentoMouse.UseVisualStyleBackColor = true;
            // 
            // checkBoxCapturaContinua
            // 
            this.checkBoxCapturaContinua.AutoSize = true;
            this.checkBoxCapturaContinua.Checked = true;
            this.checkBoxCapturaContinua.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCapturaContinua.Location = new System.Drawing.Point(106, 74);
            this.checkBoxCapturaContinua.Name = "checkBoxCapturaContinua";
            this.checkBoxCapturaContinua.Size = new System.Drawing.Size(108, 17);
            this.checkBoxCapturaContinua.TabIndex = 10;
            this.checkBoxCapturaContinua.Text = "Captura Continua";
            this.checkBoxCapturaContinua.UseVisualStyleBackColor = true;
            // 
            // textBoxLocalizacaoPixelsCapturados
            // 
            this.textBoxLocalizacaoPixelsCapturados.Location = new System.Drawing.Point(123, 48);
            this.textBoxLocalizacaoPixelsCapturados.Name = "textBoxLocalizacaoPixelsCapturados";
            this.textBoxLocalizacaoPixelsCapturados.Size = new System.Drawing.Size(271, 20);
            this.textBoxLocalizacaoPixelsCapturados.TabIndex = 9;
            this.textBoxLocalizacaoPixelsCapturados.Text = "C:\\Users\\Public\\WAKLocation.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gravar em:";
            // 
            // labelTituloCaptura
            // 
            this.labelTituloCaptura.AutoSize = true;
            this.labelTituloCaptura.Location = new System.Drawing.Point(6, 21);
            this.labelTituloCaptura.Name = "labelTituloCaptura";
            this.labelTituloCaptura.Size = new System.Drawing.Size(75, 13);
            this.labelTituloCaptura.TabIndex = 6;
            this.labelTituloCaptura.Text = "Título Captura";
            // 
            // textBoxTituloCaptura
            // 
            this.textBoxTituloCaptura.AcceptsReturn = true;
            this.textBoxTituloCaptura.Location = new System.Drawing.Point(123, 21);
            this.textBoxTituloCaptura.Name = "textBoxTituloCaptura";
            this.textBoxTituloCaptura.Size = new System.Drawing.Size(271, 20);
            this.textBoxTituloCaptura.TabIndex = 5;
            this.textBoxTituloCaptura.Text = "TituloCaptura";
            // 
            // labelEixoHorizontalPixel
            // 
            this.labelEixoHorizontalPixel.AutoSize = true;
            this.labelEixoHorizontalPixel.Location = new System.Drawing.Point(121, 169);
            this.labelEixoHorizontalPixel.Name = "labelEixoHorizontalPixel";
            this.labelEixoHorizontalPixel.Size = new System.Drawing.Size(80, 13);
            this.labelEixoHorizontalPixel.TabIndex = 4;
            this.labelEixoHorizontalPixel.Text = "Eixo Horizontal:";
            // 
            // labelEixoVerticalPixel
            // 
            this.labelEixoVerticalPixel.AutoSize = true;
            this.labelEixoVerticalPixel.Location = new System.Drawing.Point(121, 146);
            this.labelEixoVerticalPixel.Name = "labelEixoVerticalPixel";
            this.labelEixoVerticalPixel.Size = new System.Drawing.Size(68, 13);
            this.labelEixoVerticalPixel.TabIndex = 0;
            this.labelEixoVerticalPixel.Text = "Eixo Vertical:";
            // 
            // panelCorPixel
            // 
            this.panelCorPixel.Location = new System.Drawing.Point(400, 21);
            this.panelCorPixel.Name = "panelCorPixel";
            this.panelCorPixel.Size = new System.Drawing.Size(25, 47);
            this.panelCorPixel.TabIndex = 3;
            // 
            // checkBoxCapturadorLigado
            // 
            this.checkBoxCapturadorLigado.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCapturadorLigado.AutoSize = true;
            this.checkBoxCapturadorLigado.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxCapturadorLigado.ForeColor = System.Drawing.Color.DimGray;
            this.checkBoxCapturadorLigado.Location = new System.Drawing.Point(9, 252);
            this.checkBoxCapturadorLigado.Name = "checkBoxCapturadorLigado";
            this.checkBoxCapturadorLigado.Size = new System.Drawing.Size(114, 23);
            this.checkBoxCapturadorLigado.TabIndex = 2;
            this.checkBoxCapturadorLigado.Text = "Capturador de Pixels";
            this.checkBoxCapturadorLigado.UseVisualStyleBackColor = false;
            this.checkBoxCapturadorLigado.CheckedChanged += new System.EventHandler(this.checkBoxCapturadorLigado_CheckedChanged);
            // 
            // labelCor
            // 
            this.labelCor.AutoSize = true;
            this.labelCor.Location = new System.Drawing.Point(121, 122);
            this.labelCor.Name = "labelCor";
            this.labelCor.Size = new System.Drawing.Size(55, 13);
            this.labelCor.TabIndex = 1;
            this.labelCor.Text = "Cor (hex) :";
            // 
            // timerHorarioFrances
            // 
            this.timerHorarioFrances.Enabled = true;
            this.timerHorarioFrances.Tick += new System.EventHandler(this.timerHorarioFrances_Tick);
            // 
            // openFileDialogImagemTemplate
            // 
            this.openFileDialogImagemTemplate.FileName = "openFileDialogImagemTemplate";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(587, 438);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioPrincipal";
            this.Text = "Wak5hark";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.tabControl1.ResumeLayout(false);
            this.capinacao.ResumeLayout(false);
            this.capinacao.PerformLayout();
            this.panelAcoes.ResumeLayout(false);
            this.groupBoxAcoes.ResumeLayout(false);
            this.groupBoxAcoes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_comboBoxAcao_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_comboBoxRecurso_0)).EndInit();
            this.abaCapturadorPixels.ResumeLayout(false);
            this.abaCapturadorPixels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage capinacao;
        private System.Windows.Forms.TabPage abaCapturadorPixels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxCacadorPixelsLigado;
        private System.Windows.Forms.Label labelCor;
        private System.Windows.Forms.CheckBox checkBoxCapturadorLigado;
        private System.Windows.Forms.Panel panelCorPixel;
        private System.Windows.Forms.Label labelEixoVerticalPixel;
        private System.Windows.Forms.Label labelEixoHorizontalPixel;
        private System.Windows.Forms.TextBox textBoxTituloCaptura;
        private System.Windows.Forms.CheckBox checkBoxCapturaContinua;
        private System.Windows.Forms.TextBox textBoxLocalizacaoPixelsCapturados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTituloCaptura;
        private System.Windows.Forms.CheckBox checkBoxMostraPixelMovimentoMouse;
        private System.Windows.Forms.Button botaoScreenshot;
        private System.Windows.Forms.TextBox textBoxLocalizacaoScreenshot;
        private System.Windows.Forms.Label labelLuminosidade;
        private System.Windows.Forms.Label labelSaturacao;
        private System.Windows.Forms.Label labelMatiz;
        private System.Windows.Forms.CheckBox checkBoxVisualizarPixel;
        private System.Windows.Forms.TextBox textBoxTransparencia;
        private System.Windows.Forms.Label labelTransparencia;
        private System.Windows.Forms.Label labelHorarioFranca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerHorarioFrances;
        private System.Windows.Forms.ComboBox comboBoxTipoBusca;
        private System.Windows.Forms.Label labelTipoBusca;
        private System.Windows.Forms.OpenFileDialog openFileDialogImagemTemplate;
        private System.Windows.Forms.Label labelObrigatorio;
        private System.Windows.Forms.CheckBox checkBoxMascaraLuminosidade;
        private System.Windows.Forms.ComboBox comboBoxRecurso_0;
        private System.Windows.Forms.Label labelRecurso;
        private System.Windows.Forms.Button botaoScreenshotRotacionado;
        private System.Windows.Forms.CheckBox checkBoxAtivarBaixoConsumo;
        private System.Windows.Forms.PictureBox pictureBox_comboBoxRecurso_0;
        private System.Windows.Forms.CheckBox checkBoxMovimentarAleatoriamente;
        private System.Windows.Forms.ComboBox comboBoxAcao_0;
        private System.Windows.Forms.Label labelAcao;
        private System.Windows.Forms.PictureBox pictureBox_comboBoxAcao_0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxProfissao;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonAdicionarAcao;
        private System.Windows.Forms.GroupBox groupBoxAcoes;
        private System.Windows.Forms.Panel panelAcoes;
        private System.Windows.Forms.TextBox textBoxTempoMaximo_0;
        private System.Windows.Forms.Label labelTempoMaximo;
    }
}

