﻿namespace CortadorDeAudio
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInitialTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonRetroceder = new System.Windows.Forms.Button();
            this.buttonInicialPosition = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonAvancar = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.buttonExecuteInterval = new System.Windows.Forms.Button();
            this.buttonAddInterval = new System.Windows.Forms.Button();
            this.buttonInicialTimeMenos = new System.Windows.Forms.Button();
            this.buttonInicialTimeMais = new System.Windows.Forms.Button();
            this.buttonFinalTimeMais = new System.Windows.Forms.Button();
            this.buttonFinalTimeMenos = new System.Windows.Forms.Button();
            this.buttonFinalPosition = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalTime = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.txtTamanhoDoIntervalo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirArquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRemoveInterval = new System.Windows.Forms.Button();
            this.inicialMark = new System.Windows.Forms.Label();
            this.finalMark = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInitialTime
            // 
            this.txtInitialTime.Location = new System.Drawing.Point(79, 96);
            this.txtInitialTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInitialTime.Name = "txtInitialTime";
            this.txtInitialTime.Size = new System.Drawing.Size(76, 20);
            this.txtInitialTime.TabIndex = 0;
            this.txtInitialTime.TextChanged += new System.EventHandler(this.txtInitialTime_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cortar de:";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(9, 60);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(22, 19);
            this.buttonPlay.TabIndex = 4;
            this.buttonPlay.Text = "▶";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPause.Location = new System.Drawing.Point(36, 60);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(23, 19);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "||";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(64, 60);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(23, 19);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "■";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 39);
            this.progressBar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(328, 9);
            this.progressBar.TabIndex = 7;
            // 
            // buttonRetroceder
            // 
            this.buttonRetroceder.Location = new System.Drawing.Point(92, 60);
            this.buttonRetroceder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRetroceder.Name = "buttonRetroceder";
            this.buttonRetroceder.Size = new System.Drawing.Size(25, 19);
            this.buttonRetroceder.TabIndex = 8;
            this.buttonRetroceder.Text = "<";
            this.buttonRetroceder.UseVisualStyleBackColor = true;
            this.buttonRetroceder.Click += new System.EventHandler(this.buttonRetroceder_Click);
            // 
            // buttonInicialPosition
            // 
            this.buttonInicialPosition.Location = new System.Drawing.Point(172, 96);
            this.buttonInicialPosition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInicialPosition.Name = "buttonInicialPosition";
            this.buttonInicialPosition.Size = new System.Drawing.Size(87, 19);
            this.buttonInicialPosition.TabIndex = 10;
            this.buttonInicialPosition.Text = "Posição Atual";
            this.buttonInicialPosition.UseVisualStyleBackColor = true;
            this.buttonInicialPosition.Click += new System.EventHandler(this.buttonInicialPosition_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 215);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(328, 215);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.Enter += new System.EventHandler(this.dataGridView_Enter);
            this.dataGridView.Leave += new System.EventHandler(this.dataGridView_Leave);
            // 
            // buttonAvancar
            // 
            this.buttonAvancar.Location = new System.Drawing.Point(121, 60);
            this.buttonAvancar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAvancar.Name = "buttonAvancar";
            this.buttonAvancar.Size = new System.Drawing.Size(25, 19);
            this.buttonAvancar.TabIndex = 14;
            this.buttonAvancar.Text = ">";
            this.buttonAvancar.UseVisualStyleBackColor = true;
            this.buttonAvancar.Click += new System.EventHandler(this.buttonAvancar_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Location = new System.Drawing.Point(213, 60);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(124, 19);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonExecuteInterval
            // 
            this.buttonExecuteInterval.Location = new System.Drawing.Point(8, 192);
            this.buttonExecuteInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExecuteInterval.Name = "buttonExecuteInterval";
            this.buttonExecuteInterval.Size = new System.Drawing.Size(108, 19);
            this.buttonExecuteInterval.TabIndex = 16;
            this.buttonExecuteInterval.Text = "Executar Intervalo";
            this.buttonExecuteInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExecuteInterval.UseVisualStyleBackColor = true;
            this.buttonExecuteInterval.Click += new System.EventHandler(this.buttonExecuteInterval_Click);
            // 
            // buttonAddInterval
            // 
            this.buttonAddInterval.Location = new System.Drawing.Point(263, 96);
            this.buttonAddInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddInterval.Name = "buttonAddInterval";
            this.buttonAddInterval.Size = new System.Drawing.Size(66, 50);
            this.buttonAddInterval.TabIndex = 17;
            this.buttonAddInterval.Text = "Adicionar Intervalo";
            this.buttonAddInterval.UseVisualStyleBackColor = true;
            this.buttonAddInterval.Click += new System.EventHandler(this.buttonAddInterval_Click);
            // 
            // buttonInicialTimeMenos
            // 
            this.buttonInicialTimeMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicialTimeMenos.Location = new System.Drawing.Point(64, 96);
            this.buttonInicialTimeMenos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInicialTimeMenos.Name = "buttonInicialTimeMenos";
            this.buttonInicialTimeMenos.Size = new System.Drawing.Size(14, 19);
            this.buttonInicialTimeMenos.TabIndex = 18;
            this.buttonInicialTimeMenos.Text = "-";
            this.buttonInicialTimeMenos.UseVisualStyleBackColor = true;
            this.buttonInicialTimeMenos.Click += new System.EventHandler(this.buttonInicialTimeMenos_Click);
            // 
            // buttonInicialTimeMais
            // 
            this.buttonInicialTimeMais.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicialTimeMais.Location = new System.Drawing.Point(157, 96);
            this.buttonInicialTimeMais.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonInicialTimeMais.Name = "buttonInicialTimeMais";
            this.buttonInicialTimeMais.Size = new System.Drawing.Size(14, 19);
            this.buttonInicialTimeMais.TabIndex = 19;
            this.buttonInicialTimeMais.Text = "+";
            this.buttonInicialTimeMais.UseVisualStyleBackColor = true;
            this.buttonInicialTimeMais.Click += new System.EventHandler(this.buttonInicialTimeMais_Click);
            // 
            // buttonFinalTimeMais
            // 
            this.buttonFinalTimeMais.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalTimeMais.Location = new System.Drawing.Point(157, 128);
            this.buttonFinalTimeMais.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFinalTimeMais.Name = "buttonFinalTimeMais";
            this.buttonFinalTimeMais.Size = new System.Drawing.Size(14, 19);
            this.buttonFinalTimeMais.TabIndex = 24;
            this.buttonFinalTimeMais.Text = "+";
            this.buttonFinalTimeMais.UseVisualStyleBackColor = true;
            this.buttonFinalTimeMais.Click += new System.EventHandler(this.buttonFinalTimeMais_Click);
            // 
            // buttonFinalTimeMenos
            // 
            this.buttonFinalTimeMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalTimeMenos.Location = new System.Drawing.Point(64, 128);
            this.buttonFinalTimeMenos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFinalTimeMenos.Name = "buttonFinalTimeMenos";
            this.buttonFinalTimeMenos.Size = new System.Drawing.Size(14, 19);
            this.buttonFinalTimeMenos.TabIndex = 23;
            this.buttonFinalTimeMenos.Text = "-";
            this.buttonFinalTimeMenos.UseVisualStyleBackColor = true;
            this.buttonFinalTimeMenos.Click += new System.EventHandler(this.buttonFinalTimeMenos_Click);
            // 
            // buttonFinalPosition
            // 
            this.buttonFinalPosition.Location = new System.Drawing.Point(172, 128);
            this.buttonFinalPosition.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFinalPosition.Name = "buttonFinalPosition";
            this.buttonFinalPosition.Size = new System.Drawing.Size(87, 19);
            this.buttonFinalPosition.TabIndex = 22;
            this.buttonFinalPosition.Text = "Posição Atual";
            this.buttonFinalPosition.UseVisualStyleBackColor = true;
            this.buttonFinalPosition.Click += new System.EventHandler(this.buttonFinalPosition_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Até:";
            // 
            // txtFinalTime
            // 
            this.txtFinalTime.Location = new System.Drawing.Point(79, 128);
            this.txtFinalTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFinalTime.Name = "txtFinalTime";
            this.txtFinalTime.Size = new System.Drawing.Size(76, 20);
            this.txtFinalTime.TabIndex = 20;
            this.txtFinalTime.TextChanged += new System.EventHandler(this.txtFinalTime_TextChanged);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(104, 436);
            this.button14.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(98, 19);
            this.button14.TabIndex = 25;
            this.button14.Text = "Salvar Intervalos";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(9, 436);
            this.button15.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(90, 19);
            this.button15.TabIndex = 26;
            this.button15.Text = "Cortar Audio";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // txtTamanhoDoIntervalo
            // 
            this.txtTamanhoDoIntervalo.Location = new System.Drawing.Point(123, 158);
            this.txtTamanhoDoIntervalo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTamanhoDoIntervalo.Name = "txtTamanhoDoIntervalo";
            this.txtTamanhoDoIntervalo.Size = new System.Drawing.Size(76, 20);
            this.txtTamanhoDoIntervalo.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 161);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tamanho do Intervalo:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(348, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirArquivoToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirArquivoToolStripMenuItem
            // 
            this.abrirArquivoToolStripMenuItem.Name = "abrirArquivoToolStripMenuItem";
            this.abrirArquivoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.abrirArquivoToolStripMenuItem.Text = "Abrir Arquivo";
            this.abrirArquivoToolStripMenuItem.Click += new System.EventHandler(this.StripMenuItemOpen_Click);
            // 
            // buttonRemoveInterval
            // 
            this.buttonRemoveInterval.Location = new System.Drawing.Point(123, 192);
            this.buttonRemoveInterval.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemoveInterval.Name = "buttonRemoveInterval";
            this.buttonRemoveInterval.Size = new System.Drawing.Size(102, 19);
            this.buttonRemoveInterval.TabIndex = 30;
            this.buttonRemoveInterval.Text = "Remover Intervalo";
            this.buttonRemoveInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemoveInterval.UseVisualStyleBackColor = true;
            this.buttonRemoveInterval.Click += new System.EventHandler(this.buttonRemoveInterval_Click);
            // 
            // inicialMark
            // 
            this.inicialMark.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inicialMark.Location = new System.Drawing.Point(12, 24);
            this.inicialMark.Name = "inicialMark";
            this.inicialMark.Size = new System.Drawing.Size(2, 10);
            this.inicialMark.TabIndex = 31;
            // 
            // finalMark
            // 
            this.finalMark.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.finalMark.Location = new System.Drawing.Point(20, 24);
            this.finalMark.Name = "finalMark";
            this.finalMark.Size = new System.Drawing.Size(2, 10);
            this.finalMark.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 464);
            this.Controls.Add(this.finalMark);
            this.Controls.Add(this.inicialMark);
            this.Controls.Add(this.buttonRemoveInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTamanhoDoIntervalo);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.buttonFinalTimeMais);
            this.Controls.Add(this.buttonFinalTimeMenos);
            this.Controls.Add(this.buttonFinalPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFinalTime);
            this.Controls.Add(this.buttonInicialTimeMais);
            this.Controls.Add(this.buttonInicialTimeMenos);
            this.Controls.Add(this.buttonAddInterval);
            this.Controls.Add(this.buttonExecuteInterval);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.buttonAvancar);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonInicialPosition);
            this.Controls.Add(this.buttonRetroceder);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInitialTime);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Cortador de Audio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInitialTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonRetroceder;
        private System.Windows.Forms.Button buttonInicialPosition;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAvancar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button buttonExecuteInterval;
        private System.Windows.Forms.Button buttonAddInterval;
        private System.Windows.Forms.Button buttonInicialTimeMenos;
        private System.Windows.Forms.Button buttonInicialTimeMais;
        private System.Windows.Forms.Button buttonFinalTimeMais;
        private System.Windows.Forms.Button buttonFinalTimeMenos;
        private System.Windows.Forms.Button buttonFinalPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinalTime;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.TextBox txtTamanhoDoIntervalo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirArquivoToolStripMenuItem;
        private System.Windows.Forms.Button buttonRemoveInterval;
        private System.Windows.Forms.Label inicialMark;
        private System.Windows.Forms.Label finalMark;
    }
}

