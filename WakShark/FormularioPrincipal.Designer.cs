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
            this.checkBoxCapinacaoLigado = new System.Windows.Forms.CheckBox();
            this.labelTipoRecurso = new System.Windows.Forms.Label();
            this.comboTipoRecurso = new System.Windows.Forms.ComboBox();
            this.labelRecurso = new System.Windows.Forms.Label();
            this.comboRecurso = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.abaCapturadorPixels = new System.Windows.Forms.TabPage();
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
            this.label3 = new System.Windows.Forms.Label();
            this.labelHorarioFranca = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.capinacao.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(592, 305);
            this.tabControl1.TabIndex = 1;
            // 
            // capinacao
            // 
            this.capinacao.Controls.Add(this.checkBoxCapinacaoLigado);
            this.capinacao.Controls.Add(this.labelTipoRecurso);
            this.capinacao.Controls.Add(this.comboTipoRecurso);
            this.capinacao.Controls.Add(this.labelRecurso);
            this.capinacao.Controls.Add(this.comboRecurso);
            this.capinacao.Controls.Add(this.label1);
            this.capinacao.Location = new System.Drawing.Point(4, 22);
            this.capinacao.Name = "capinacao";
            this.capinacao.Padding = new System.Windows.Forms.Padding(3);
            this.capinacao.Size = new System.Drawing.Size(498, 282);
            this.capinacao.TabIndex = 0;
            this.capinacao.Text = "Capinacao";
            this.capinacao.UseVisualStyleBackColor = true;
            // 
            // checkBoxCapinacaoLigado
            // 
            this.checkBoxCapinacaoLigado.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxCapinacaoLigado.AutoSize = true;
            this.checkBoxCapinacaoLigado.Location = new System.Drawing.Point(6, 259);
            this.checkBoxCapinacaoLigado.Name = "checkBoxCapinacaoLigado";
            this.checkBoxCapinacaoLigado.Size = new System.Drawing.Size(49, 23);
            this.checkBoxCapinacaoLigado.TabIndex = 7;
            this.checkBoxCapinacaoLigado.Text = "Ligado";
            this.checkBoxCapinacaoLigado.UseVisualStyleBackColor = true;
            this.checkBoxCapinacaoLigado.CheckedChanged += new System.EventHandler(this.checkBoxCapinacaoLigado_CheckedChanged);
            // 
            // labelTipoRecurso
            // 
            this.labelTipoRecurso.AutoSize = true;
            this.labelTipoRecurso.Location = new System.Drawing.Point(42, 21);
            this.labelTipoRecurso.Name = "labelTipoRecurso";
            this.labelTipoRecurso.Size = new System.Drawing.Size(92, 13);
            this.labelTipoRecurso.TabIndex = 6;
            this.labelTipoRecurso.Text = "Tipo de Recurso: ";
            // 
            // comboTipoRecurso
            // 
            this.comboTipoRecurso.FormattingEnabled = true;
            this.comboTipoRecurso.Location = new System.Drawing.Point(140, 18);
            this.comboTipoRecurso.Name = "comboTipoRecurso";
            this.comboTipoRecurso.Size = new System.Drawing.Size(121, 21);
            this.comboTipoRecurso.TabIndex = 5;
            this.comboTipoRecurso.SelectedValueChanged += new System.EventHandler(this.comboTipoRecurso_SelectedValueChanged);
            // 
            // labelRecurso
            // 
            this.labelRecurso.AutoSize = true;
            this.labelRecurso.Location = new System.Drawing.Point(81, 48);
            this.labelRecurso.Name = "labelRecurso";
            this.labelRecurso.Size = new System.Drawing.Size(53, 13);
            this.labelRecurso.TabIndex = 4;
            this.labelRecurso.Text = "Recurso: ";
            // 
            // comboRecurso
            // 
            this.comboRecurso.DisplayMember = "trigo";
            this.comboRecurso.FormattingEnabled = true;
            this.comboRecurso.Location = new System.Drawing.Point(140, 45);
            this.comboRecurso.Name = "comboRecurso";
            this.comboRecurso.Size = new System.Drawing.Size(121, 21);
            this.comboRecurso.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pressione \"F4\" para INICIAR ou PARAR.";
            // 
            // abaCapturadorPixels
            // 
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
            this.abaCapturadorPixels.Size = new System.Drawing.Size(584, 279);
            this.abaCapturadorPixels.TabIndex = 1;
            this.abaCapturadorPixels.Text = "Capturador de Pixels";
            this.abaCapturadorPixels.UseVisualStyleBackColor = true;
            // 
            // textBoxTransparencia
            // 
            this.textBoxTransparencia.Location = new System.Drawing.Point(337, 223);
            this.textBoxTransparencia.Name = "textBoxTransparencia";
            this.textBoxTransparencia.Size = new System.Drawing.Size(38, 20);
            this.textBoxTransparencia.TabIndex = 19;
            // 
            // labelTransparencia
            // 
            this.labelTransparencia.AutoSize = true;
            this.labelTransparencia.Location = new System.Drawing.Point(208, 228);
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
            this.textBoxLocalizacaoScreenshot.Size = new System.Drawing.Size(277, 20);
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
            this.panelCorPixel.Size = new System.Drawing.Size(88, 47);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Horário Atual (França):";
            // 
            // labelHorarioFranca
            // 
            this.labelHorarioFranca.AutoSize = true;
            this.labelHorarioFranca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelHorarioFranca.Location = new System.Drawing.Point(514, 228);
            this.labelHorarioFranca.Name = "labelHorarioFranca";
            this.labelHorarioFranca.Size = new System.Drawing.Size(51, 15);
            this.labelHorarioFranca.TabIndex = 21;
            this.labelHorarioFranca.Text = "00:00:00";
            // 
            // FormularioPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(642, 336);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormularioPrincipal";
            this.Text = "WakBoy";
            this.Load += new System.EventHandler(this.FormularioPrincipal_Load);
            this.tabControl1.ResumeLayout(false);
            this.capinacao.ResumeLayout(false);
            this.capinacao.PerformLayout();
            this.abaCapturadorPixels.ResumeLayout(false);
            this.abaCapturadorPixels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage capinacao;
        private System.Windows.Forms.TabPage abaCapturadorPixels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRecurso;
        private System.Windows.Forms.ComboBox comboRecurso;
        private System.Windows.Forms.Label labelTipoRecurso;
        private System.Windows.Forms.ComboBox comboTipoRecurso;
        private System.Windows.Forms.CheckBox checkBoxCapinacaoLigado;
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
    }
}

