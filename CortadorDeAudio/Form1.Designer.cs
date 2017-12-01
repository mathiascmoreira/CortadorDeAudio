namespace CortadorDeAudio
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
            this.ButtonSkipBackward = new System.Windows.Forms.Button();
            this.buttonInicialPosition = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonSkipForward = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.buttonExecuteInterval = new System.Windows.Forms.Button();
            this.buttonAddInterval = new System.Windows.Forms.Button();
            this.buttonInicialDecreaseTime = new System.Windows.Forms.Button();
            this.buttonInicialIncreaseTime = new System.Windows.Forms.Button();
            this.buttonFinalIncreaseTime = new System.Windows.Forms.Button();
            this.buttonFinalDecreaseTime = new System.Windows.Forms.Button();
            this.buttonFinalPosition = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFinalTime = new System.Windows.Forms.TextBox();
            this.txtintervalLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadIntervalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveIntervalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRemoveInterval = new System.Windows.Forms.Button();
            this.buttonUpdateInterval = new System.Windows.Forms.Button();
            this.buttonStopExecuteInterval = new System.Windows.Forms.Button();
            this.volumeControl = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeControl)).BeginInit();
            this.SuspendLayout();
            // 
            // txtInitialTime
            // 
            this.txtInitialTime.Location = new System.Drawing.Point(107, 136);
            this.txtInitialTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInitialTime.Name = "txtInitialTime";
            this.txtInitialTime.ReadOnly = true;
            this.txtInitialTime.Size = new System.Drawing.Size(145, 22);
            this.txtInitialTime.TabIndex = 0;
            this.txtInitialTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cut from:";
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(12, 74);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(29, 23);
            this.buttonPlay.TabIndex = 4;
            this.buttonPlay.Text = "▶";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPause.Location = new System.Drawing.Point(48, 74);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(31, 23);
            this.buttonPause.TabIndex = 5;
            this.buttonPause.Text = "||";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(85, 74);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(31, 23);
            this.buttonStop.TabIndex = 6;
            this.buttonStop.Text = "■";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 48);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Maximum = 1000;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(568, 11);
            this.progressBar.TabIndex = 7;
            // 
            // buttonRetroceder
            // 
            this.ButtonSkipBackward.Location = new System.Drawing.Point(123, 74);
            this.ButtonSkipBackward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonSkipBackward.Name = "buttonRetroceder";
            this.ButtonSkipBackward.Size = new System.Drawing.Size(33, 23);
            this.ButtonSkipBackward.TabIndex = 8;
            this.ButtonSkipBackward.Text = "<";
            this.ButtonSkipBackward.UseVisualStyleBackColor = true;
            this.ButtonSkipBackward.Click += new System.EventHandler(this.ButtonSkipBackward_Click);
            // 
            // buttonInicialPosition
            // 
            this.buttonInicialPosition.Location = new System.Drawing.Point(275, 136);
            this.buttonInicialPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInicialPosition.Name = "buttonInicialPosition";
            this.buttonInicialPosition.Size = new System.Drawing.Size(67, 23);
            this.buttonInicialPosition.TabIndex = 10;
            this.buttonInicialPosition.Text = "Current";
            this.buttonInicialPosition.UseVisualStyleBackColor = true;
            this.buttonInicialPosition.Click += new System.EventHandler(this.buttonInicialPosition_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 270);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(568, 380);
            this.dataGridView.TabIndex = 11;
            this.dataGridView.DoubleClick += new System.EventHandler(this.dataGridView_DoubleClick);
            // 
            // buttonAvancar
            // 
            this.ButtonSkipForward.Location = new System.Drawing.Point(161, 74);
            this.ButtonSkipForward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonSkipForward.Name = "buttonAvancar";
            this.ButtonSkipForward.Size = new System.Drawing.Size(33, 23);
            this.ButtonSkipForward.TabIndex = 14;
            this.ButtonSkipForward.Text = ">";
            this.ButtonSkipForward.UseVisualStyleBackColor = true;
            this.ButtonSkipForward.Click += new System.EventHandler(this.ButtonSkipForward_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timeLabel.Location = new System.Drawing.Point(209, 74);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(165, 23);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonExecuteInterval
            // 
            this.buttonExecuteInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExecuteInterval.Location = new System.Drawing.Point(344, 136);
            this.buttonExecuteInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExecuteInterval.Name = "buttonExecuteInterval";
            this.buttonExecuteInterval.Size = new System.Drawing.Size(25, 50);
            this.buttonExecuteInterval.TabIndex = 16;
            this.buttonExecuteInterval.Text = "▶";
            this.buttonExecuteInterval.UseVisualStyleBackColor = true;
            this.buttonExecuteInterval.Click += new System.EventHandler(this.buttonExecuteInterval_Click);
            // 
            // buttonAddInterval
            // 
            this.buttonAddInterval.Location = new System.Drawing.Point(12, 242);
            this.buttonAddInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddInterval.Name = "buttonAddInterval";
            this.buttonAddInterval.Size = new System.Drawing.Size(47, 24);
            this.buttonAddInterval.TabIndex = 17;
            this.buttonAddInterval.Text = "Add";
            this.buttonAddInterval.UseVisualStyleBackColor = true;
            this.buttonAddInterval.Click += new System.EventHandler(this.buttonAddInterval_Click);
            // 
            // buttonInicialTimeMenos
            // 
            this.buttonInicialDecreaseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicialDecreaseTime.Location = new System.Drawing.Point(87, 136);
            this.buttonInicialDecreaseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInicialDecreaseTime.Name = "buttonInicialTimeMenos";
            this.buttonInicialDecreaseTime.Size = new System.Drawing.Size(19, 23);
            this.buttonInicialDecreaseTime.TabIndex = 18;
            this.buttonInicialDecreaseTime.Text = "-";
            this.buttonInicialDecreaseTime.UseVisualStyleBackColor = true;
            this.buttonInicialDecreaseTime.Click += new System.EventHandler(this.buttonInicialDecreaseTime_Click);
            // 
            // buttonInicialTimeMais
            // 
            this.buttonInicialIncreaseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInicialIncreaseTime.Location = new System.Drawing.Point(255, 136);
            this.buttonInicialIncreaseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInicialIncreaseTime.Name = "buttonInicialTimeMais";
            this.buttonInicialIncreaseTime.Size = new System.Drawing.Size(19, 23);
            this.buttonInicialIncreaseTime.TabIndex = 19;
            this.buttonInicialIncreaseTime.Text = "+";
            this.buttonInicialIncreaseTime.UseVisualStyleBackColor = true;
            this.buttonInicialIncreaseTime.Click += new System.EventHandler(this.buttonInicialIncreaseTime_Click);
            // 
            // buttonFinalTimeMais
            // 
            this.buttonFinalIncreaseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalIncreaseTime.Location = new System.Drawing.Point(255, 164);
            this.buttonFinalIncreaseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFinalIncreaseTime.Name = "buttonFinalTimeMais";
            this.buttonFinalIncreaseTime.Size = new System.Drawing.Size(19, 23);
            this.buttonFinalIncreaseTime.TabIndex = 24;
            this.buttonFinalIncreaseTime.Text = "+";
            this.buttonFinalIncreaseTime.UseVisualStyleBackColor = true;
            this.buttonFinalIncreaseTime.Click += new System.EventHandler(this.buttonFinalIncreaseTime_Click);
            // 
            // buttonFinalTimeMenos
            // 
            this.buttonFinalDecreaseTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalDecreaseTime.Location = new System.Drawing.Point(87, 164);
            this.buttonFinalDecreaseTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFinalDecreaseTime.Name = "buttonFinalTimeMenos";
            this.buttonFinalDecreaseTime.Size = new System.Drawing.Size(19, 23);
            this.buttonFinalDecreaseTime.TabIndex = 23;
            this.buttonFinalDecreaseTime.Text = "-";
            this.buttonFinalDecreaseTime.UseVisualStyleBackColor = true;
            this.buttonFinalDecreaseTime.Click += new System.EventHandler(this.buttonFinalDecreaseTime_Click);
            // 
            // buttonFinalPosition
            // 
            this.buttonFinalPosition.Location = new System.Drawing.Point(275, 164);
            this.buttonFinalPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFinalPosition.Name = "buttonFinalPosition";
            this.buttonFinalPosition.Size = new System.Drawing.Size(67, 23);
            this.buttonFinalPosition.TabIndex = 22;
            this.buttonFinalPosition.Text = "Current";
            this.buttonFinalPosition.UseVisualStyleBackColor = true;
            this.buttonFinalPosition.Click += new System.EventHandler(this.buttonFinalPosition_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "To:";
            // 
            // txtFinalTime
            // 
            this.txtFinalTime.Location = new System.Drawing.Point(107, 164);
            this.txtFinalTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFinalTime.Name = "txtFinalTime";
            this.txtFinalTime.ReadOnly = true;
            this.txtFinalTime.Size = new System.Drawing.Size(145, 22);
            this.txtFinalTime.TabIndex = 20;
            this.txtFinalTime.TextChanged += new System.EventHandler(this.txtTime_TextChanged);
            // 
            // txtTamanhoDoIntervalo
            // 
            this.txtintervalLength.Location = new System.Drawing.Point(107, 194);
            this.txtintervalLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtintervalLength.Name = "txtTamanhoDoIntervalo";
            this.txtintervalLength.ReadOnly = true;
            this.txtintervalLength.Size = new System.Drawing.Size(145, 22);
            this.txtintervalLength.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Interval:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(597, 28);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToolStripMenuItem,
            this.loadIntervalsToolStripMenuItem,
            this.saveIntervalsToolStripMenuItem,
            this.exportFilesToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.openFileToolStripMenuItem.Text = "Open File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // loadIntervalsToolStripMenuItem
            // 
            this.loadIntervalsToolStripMenuItem.Name = "loadIntervalsToolStripMenuItem";
            this.loadIntervalsToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.loadIntervalsToolStripMenuItem.Text = "Load Intervals";
            this.loadIntervalsToolStripMenuItem.Click += new System.EventHandler(this.loadIntervalsToolStripMenuItem_Click);
            // 
            // saveIntervalsToolStripMenuItem
            // 
            this.saveIntervalsToolStripMenuItem.Name = "saveIntervalsToolStripMenuItem";
            this.saveIntervalsToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.saveIntervalsToolStripMenuItem.Text = "Save Intervals";
            this.saveIntervalsToolStripMenuItem.Click += new System.EventHandler(this.saveIntervalsToolStripMenuItem_Click);
            // 
            // exportFilesToolStripMenuItem
            // 
            this.exportFilesToolStripMenuItem.Name = "exportFilesToolStripMenuItem";
            this.exportFilesToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.exportFilesToolStripMenuItem.Text = "Export Files";
            this.exportFilesToolStripMenuItem.Click += new System.EventHandler(this.exportFilesToolStripMenuItem_Click);
            // 
            // buttonRemoveInterval
            // 
            this.buttonRemoveInterval.Location = new System.Drawing.Point(61, 242);
            this.buttonRemoveInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRemoveInterval.Name = "buttonRemoveInterval";
            this.buttonRemoveInterval.Size = new System.Drawing.Size(80, 24);
            this.buttonRemoveInterval.TabIndex = 30;
            this.buttonRemoveInterval.Text = "Remove";
            this.buttonRemoveInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRemoveInterval.UseVisualStyleBackColor = true;
            this.buttonRemoveInterval.Click += new System.EventHandler(this.buttonRemoveInterval_Click);
            // 
            // buttonUpdateInterval
            // 
            this.buttonUpdateInterval.Location = new System.Drawing.Point(143, 242);
            this.buttonUpdateInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdateInterval.Name = "buttonUpdateInterval";
            this.buttonUpdateInterval.Size = new System.Drawing.Size(67, 24);
            this.buttonUpdateInterval.TabIndex = 31;
            this.buttonUpdateInterval.Text = "Update";
            this.buttonUpdateInterval.UseVisualStyleBackColor = true;
            this.buttonUpdateInterval.Click += new System.EventHandler(this.buttonUpdateInterval_Click);
            // 
            // buttonStopExecuteInterval
            // 
            this.buttonStopExecuteInterval.Location = new System.Drawing.Point(371, 136);
            this.buttonStopExecuteInterval.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStopExecuteInterval.Name = "buttonStopExecuteInterval";
            this.buttonStopExecuteInterval.Size = new System.Drawing.Size(25, 50);
            this.buttonStopExecuteInterval.TabIndex = 32;
            this.buttonStopExecuteInterval.Text = "■";
            this.buttonStopExecuteInterval.UseVisualStyleBackColor = true;
            this.buttonStopExecuteInterval.Click += new System.EventHandler(this.buttonStopExecuteInterval_Click);
            // 
            // volumeControl
            // 
            this.volumeControl.AutoSize = false;
            this.volumeControl.Location = new System.Drawing.Point(452, 65);
            this.volumeControl.Margin = new System.Windows.Forms.Padding(4);
            this.volumeControl.Maximum = 100;
            this.volumeControl.Name = "volumeControl";
            this.volumeControl.Size = new System.Drawing.Size(128, 35);
            this.volumeControl.TabIndex = 33;
            this.volumeControl.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.volumeControl.Value = 100;
            this.volumeControl.ValueChanged += new System.EventHandler(this.volumeControl_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "Volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 658);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeControl);
            this.Controls.Add(this.buttonStopExecuteInterval);
            this.Controls.Add(this.buttonUpdateInterval);
            this.Controls.Add(this.buttonRemoveInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtintervalLength);
            this.Controls.Add(this.buttonFinalIncreaseTime);
            this.Controls.Add(this.buttonFinalDecreaseTime);
            this.Controls.Add(this.buttonFinalPosition);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFinalTime);
            this.Controls.Add(this.buttonInicialIncreaseTime);
            this.Controls.Add(this.buttonInicialDecreaseTime);
            this.Controls.Add(this.buttonAddInterval);
            this.Controls.Add(this.buttonExecuteInterval);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.ButtonSkipForward);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonInicialPosition);
            this.Controls.Add(this.ButtonSkipBackward);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInitialTime);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cortador de Audio";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeControl)).EndInit();
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
        private System.Windows.Forms.Button ButtonSkipBackward;
        private System.Windows.Forms.Button buttonInicialPosition;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonSkipForward;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button buttonExecuteInterval;
        private System.Windows.Forms.Button buttonAddInterval;
        private System.Windows.Forms.Button buttonInicialDecreaseTime;
        private System.Windows.Forms.Button buttonInicialIncreaseTime;
        private System.Windows.Forms.Button buttonFinalIncreaseTime;
        private System.Windows.Forms.Button buttonFinalDecreaseTime;
        private System.Windows.Forms.Button buttonFinalPosition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFinalTime;
        private System.Windows.Forms.TextBox txtintervalLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.Button buttonRemoveInterval;
        private System.Windows.Forms.ToolStripMenuItem loadIntervalsToolStripMenuItem;
        private System.Windows.Forms.Button buttonUpdateInterval;
        private System.Windows.Forms.Button buttonStopExecuteInterval;
        private System.Windows.Forms.TrackBar volumeControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem saveIntervalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFilesToolStripMenuItem;
    }
}

