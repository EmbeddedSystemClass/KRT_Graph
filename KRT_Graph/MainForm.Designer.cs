namespace KRT_Graph
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.zGraph = new ZedGraph.ZedGraphControl();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.updTimer300ms = new System.Windows.Forms.Timer(this.components);
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtValueMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoad2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnScreenshot2 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPortFind = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbPort = new System.Windows.Forms.ToolStripComboBox();
            this.cmbBaudRate = new System.Windows.Forms.ToolStripComboBox();
            this.btnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRecAndPlay = new System.Windows.Forms.ToolStripButton();
            this.btnPause = new System.Windows.Forms.ToolStripButton();
            this.btnStopAndClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCropFrom = new System.Windows.Forms.ToolStripButton();
            this.btnCropTo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnScreenshot = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAutoSize = new System.Windows.Forms.ToolStripButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // zGraph
            // 
            this.zGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zGraph.Location = new System.Drawing.Point(12, 115);
            this.zGraph.Name = "zGraph";
            this.zGraph.ScrollGrace = 0D;
            this.zGraph.ScrollMaxX = 0D;
            this.zGraph.ScrollMaxY = 0D;
            this.zGraph.ScrollMaxY2 = 0D;
            this.zGraph.ScrollMinX = 0D;
            this.zGraph.ScrollMinY = 0D;
            this.zGraph.ScrollMinY2 = 0D;
            this.zGraph.Size = new System.Drawing.Size(869, 374);
            this.zGraph.TabIndex = 0;
            // 
            // cmbInterval
            // 
            this.cmbInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Items.AddRange(new object[] {
            "1 сек",
            "5 сек",
            "10 сек",
            "30 сек",
            "1 мин",
            "2 мин",
            "5 мин",
            "10 мин",
            "30 мин",
            "60 мин"});
            this.cmbInterval.Location = new System.Drawing.Point(955, 89);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(98, 21);
            this.cmbInterval.TabIndex = 1;
            this.cmbInterval.SelectedIndexChanged += new System.EventHandler(this.cmbInterval_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(893, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Интервал";
            // 
            // updTimer300ms
            // 
            this.updTimer300ms.Enabled = true;
            this.updTimer300ms.Interval = 300;
            this.updTimer300ms.Tick += new System.EventHandler(this.updTimer200ms_Tick);
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(319, 66);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 8;
            this.txtMax.TextChanged += new System.EventHandler(this.txtMaxValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Maксимальное";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(319, 89);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(100, 20);
            this.txtMin.TabIndex = 11;
            this.txtMin.TextChanged += new System.EventHandler(this.txtMin_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Минимум";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(123, 66);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(100, 20);
            this.txtValue.TabIndex = 13;
            // 
            // txtValueMin
            // 
            this.txtValueMin.Location = new System.Drawing.Point(123, 89);
            this.txtValueMin.Name = "txtValueMin";
            this.txtValueMin.ReadOnly = true;
            this.txtValueMin.Size = new System.Drawing.Size(100, 20);
            this.txtValueMin.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Принимаемое";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Принимаемое - мин";
            // 
            // txtDebug
            // 
            this.txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDebug.Location = new System.Drawing.Point(955, 66);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.Size = new System.Drawing.Size(98, 20);
            this.txtDebug.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.btnPortFind,
            this.btnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1065, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave2,
            this.btnLoad2,
            this.btnScreenshot2});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // btnSave2
            // 
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.Size = new System.Drawing.Size(177, 22);
            this.btnSave2.Text = "Сохранить";
            this.btnSave2.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad2
            // 
            this.btnLoad2.Name = "btnLoad2";
            this.btnLoad2.Size = new System.Drawing.Size(177, 22);
            this.btnLoad2.Text = "Загрузить";
            this.btnLoad2.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnScreenshot2
            // 
            this.btnScreenshot2.Name = "btnScreenshot2";
            this.btnScreenshot2.Size = new System.Drawing.Size(177, 22);
            this.btnScreenshot2.Text = "Сделать скриншот";
            this.btnScreenshot2.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // btnPortFind
            // 
            this.btnPortFind.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbPort,
            this.cmbBaudRate});
            this.btnPortFind.Name = "btnPortFind";
            this.btnPortFind.Size = new System.Drawing.Size(47, 20);
            this.btnPortFind.Text = "Порт";
            this.btnPortFind.DropDownOpening += new System.EventHandler(this.btnPortFind_DropDownOpening);
            // 
            // cmbPort
            // 
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(75, 23);
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(75, 23);
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(65, 20);
            this.btnHelp.Text = "Справка";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRecAndPlay,
            this.btnPause,
            this.btnStopAndClear,
            this.toolStripSeparator1,
            this.btnSave,
            this.btnLoad,
            this.toolStripSeparator2,
            this.btnCropFrom,
            this.btnCropTo,
            this.toolStripSeparator3,
            this.btnScreenshot,
            this.toolStripSeparator4,
            this.btnAutoSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1065, 39);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRecAndPlay
            // 
            this.btnRecAndPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnRecAndPlay.Image")));
            this.btnRecAndPlay.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRecAndPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecAndPlay.Name = "btnRecAndPlay";
            this.btnRecAndPlay.Size = new System.Drawing.Size(82, 36);
            this.btnRecAndPlay.Text = "Запись";
            this.btnRecAndPlay.Click += new System.EventHandler(this.btnRecAndPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Image = ((System.Drawing.Image)(resources.GetObject("btnPause.Image")));
            this.btnPause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 36);
            this.btnPause.Text = "Пауза";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStopAndClear
            // 
            this.btnStopAndClear.Image = ((System.Drawing.Image)(resources.GetObject("btnStopAndClear.Image")));
            this.btnStopAndClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStopAndClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopAndClear.Name = "btnStopAndClear";
            this.btnStopAndClear.Size = new System.Drawing.Size(95, 36);
            this.btnStopAndClear.Text = "Очистить";
            this.btnStopAndClear.Click += new System.EventHandler(this.btnStopAndClear_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 36);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(97, 36);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCropFrom
            // 
            this.btnCropFrom.Image = ((System.Drawing.Image)(resources.GetObject("btnCropFrom.Image")));
            this.btnCropFrom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCropFrom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCropFrom.Name = "btnCropFrom";
            this.btnCropFrom.Size = new System.Drawing.Size(110, 36);
            this.btnCropFrom.Text = "Обрезать до";
            this.btnCropFrom.Click += new System.EventHandler(this.btnCropFrom_Click);
            // 
            // btnCropTo
            // 
            this.btnCropTo.Image = ((System.Drawing.Image)(resources.GetObject("btnCropTo.Image")));
            this.btnCropTo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCropTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCropTo.Name = "btnCropTo";
            this.btnCropTo.Size = new System.Drawing.Size(130, 36);
            this.btnCropTo.Text = "Обрезать после";
            this.btnCropTo.Click += new System.EventHandler(this.btnCropTo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Image = ((System.Drawing.Image)(resources.GetObject("btnScreenshot.Image")));
            this.btnScreenshot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnScreenshot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(101, 36);
            this.btnScreenshot.Text = "Скриншот";
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
            // 
            // btnAutoSize
            // 
            this.btnAutoSize.Checked = true;
            this.btnAutoSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAutoSize.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoSize.Image")));
            this.btnAutoSize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAutoSize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAutoSize.Name = "btnAutoSize";
            this.btnAutoSize.Size = new System.Drawing.Size(119, 36);
            this.btnAutoSize.Text = "Автомасштаб";
            this.btnAutoSize.Click += new System.EventHandler(this.btnAutoSize_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(887, 115);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 374);
            this.textBox1.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 501);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtValueMin);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbInterval);
            this.Controls.Add(this.zGraph);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "График Расходомера";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zGraph;
        private System.Windows.Forms.ComboBox cmbInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer updTimer300ms;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtValueMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSave2;
        private System.Windows.Forms.ToolStripMenuItem btnLoad2;
        private System.Windows.Forms.ToolStripMenuItem btnPortFind;
        private System.Windows.Forms.ToolStripComboBox cmbPort;
        private System.Windows.Forms.ToolStripComboBox cmbBaudRate;
        private System.Windows.Forms.ToolStripMenuItem btnHelp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRecAndPlay;
        private System.Windows.Forms.ToolStripButton btnPause;
        private System.Windows.Forms.ToolStripButton btnStopAndClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnCropFrom;
        private System.Windows.Forms.ToolStripButton btnCropTo;
        private System.Windows.Forms.ToolStripMenuItem btnScreenshot2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnScreenshot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnAutoSize;
        private System.Windows.Forms.TextBox textBox1;
    }
}

