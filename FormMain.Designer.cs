
namespace zanac.VGMPlayer
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuStrip1 = new MenuStrip();
            fILEToolStripMenuItem = new ToolStripMenuItem();
            eXITToolStripMenuItem = new ToolStripMenuItem();
            aBOUTToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanelButton = new TableLayoutPanel();
            buttonPrev = new Button();
            imageListSmall = new ImageList(components);
            buttonPlay = new Button();
            imageListBig = new ImageList(components);
            buttonStop = new Button();
            buttonNext = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            comboBoxOpmClock = new ComboBox();
            comboBoxOpnaClock = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            comboBoxLight = new ComboBox();
            labelPort = new Label();
            comboBoxSerial = new ComboBox();
            buttonConnect = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            label7 = new Label();
            textBoxTitle = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            toolTip1 = new ToolTip(components);
            columnHeaderFile = new ColumnHeader();
            listViewList = new ListView();
            columnHeaderFileName = new ColumnHeader();
            columnHeaderSize = new ColumnHeader();
            columnHeaderDateTime = new ColumnHeader();
            columnHeaderLongFileName = new ColumnHeader();
            tableLayoutPanel1 = new TableLayoutPanel();
            buttonReset = new Button();
            label3 = new Label();
            numericUpDownTimeout = new NumericUpDown();
            menuStrip1.SuspendLayout();
            tableLayoutPanelButton.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fILEToolStripMenuItem, aBOUTToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(787, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            fILEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { eXITToolStripMenuItem });
            fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            fILEToolStripMenuItem.Size = new Size(40, 20);
            fILEToolStripMenuItem.Text = "&FILE";
            // 
            // eXITToolStripMenuItem
            // 
            eXITToolStripMenuItem.Name = "eXITToolStripMenuItem";
            eXITToolStripMenuItem.Size = new Size(96, 22);
            eXITToolStripMenuItem.Text = "&EXIT";
            // 
            // aBOUTToolStripMenuItem
            // 
            aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            aBOUTToolStripMenuItem.Size = new Size(57, 20);
            aBOUTToolStripMenuItem.Text = "&ABOUT";
            aBOUTToolStripMenuItem.Click += aBOUTToolStripMenuItem_Click;
            // 
            // tableLayoutPanelButton
            // 
            tableLayoutPanelButton.ColumnCount = 11;
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelButton.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelButton.Controls.Add(buttonPrev, 0, 0);
            tableLayoutPanelButton.Controls.Add(buttonPlay, 1, 0);
            tableLayoutPanelButton.Controls.Add(buttonStop, 3, 0);
            tableLayoutPanelButton.Controls.Add(buttonNext, 2, 0);
            tableLayoutPanelButton.Controls.Add(tableLayoutPanel3, 10, 0);
            tableLayoutPanelButton.Dock = DockStyle.Bottom;
            tableLayoutPanelButton.Location = new Point(0, 701);
            tableLayoutPanelButton.Margin = new Padding(4);
            tableLayoutPanelButton.Name = "tableLayoutPanelButton";
            tableLayoutPanelButton.RowCount = 3;
            tableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            tableLayoutPanelButton.RowStyles.Add(new RowStyle());
            tableLayoutPanelButton.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelButton.Size = new Size(787, 90);
            tableLayoutPanelButton.TabIndex = 4;
            // 
            // buttonPrev
            // 
            buttonPrev.AutoSize = true;
            buttonPrev.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonPrev.Dock = DockStyle.Fill;
            buttonPrev.FlatAppearance.BorderSize = 0;
            buttonPrev.FlatStyle = FlatStyle.Flat;
            buttonPrev.ImageIndex = 0;
            buttonPrev.ImageList = imageListSmall;
            buttonPrev.Location = new Point(4, 4);
            buttonPrev.Margin = new Padding(4);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(38, 47);
            buttonPrev.TabIndex = 0;
            buttonPrev.TextAlign = ContentAlignment.BottomCenter;
            toolTip1.SetToolTip(buttonPrev, "Previous Track");
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // imageListSmall
            // 
            imageListSmall.ColorDepth = ColorDepth.Depth32Bit;
            imageListSmall.ImageStream = (ImageListStreamer)resources.GetObject("imageListSmall.ImageStream");
            imageListSmall.TransparentColor = Color.Transparent;
            imageListSmall.Images.SetKeyName(0, "Prev.png");
            imageListSmall.Images.SetKeyName(1, "Next.png");
            imageListSmall.Images.SetKeyName(2, "Stop.png");
            imageListSmall.Images.SetKeyName(3, "Freeze.png");
            imageListSmall.Images.SetKeyName(4, "Slow.png");
            imageListSmall.Images.SetKeyName(5, "Fast.png");
            imageListSmall.Images.SetKeyName(6, "Loop.png");
            imageListSmall.Images.SetKeyName(7, "Clear.png");
            imageListSmall.Images.SetKeyName(8, "Eject.png");
            imageListSmall.Images.SetKeyName(9, "Loop_Time.png");
            // 
            // buttonPlay
            // 
            buttonPlay.AllowDrop = true;
            buttonPlay.Dock = DockStyle.Fill;
            buttonPlay.FlatAppearance.BorderSize = 0;
            buttonPlay.FlatStyle = FlatStyle.Flat;
            buttonPlay.ImageIndex = 0;
            buttonPlay.ImageList = imageListBig;
            buttonPlay.Location = new Point(50, 4);
            buttonPlay.Margin = new Padding(4);
            buttonPlay.Name = "buttonPlay";
            tableLayoutPanelButton.SetRowSpan(buttonPlay, 2);
            buttonPlay.Size = new Size(108, 80);
            buttonPlay.TabIndex = 1;
            buttonPlay.TextAlign = ContentAlignment.BottomCenter;
            toolTip1.SetToolTip(buttonPlay, "Play/Pause");
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // imageListBig
            // 
            imageListBig.ColorDepth = ColorDepth.Depth32Bit;
            imageListBig.ImageStream = (ImageListStreamer)resources.GetObject("imageListBig.ImageStream");
            imageListBig.TransparentColor = Color.Transparent;
            imageListBig.Images.SetKeyName(0, "Play.png");
            imageListBig.Images.SetKeyName(1, "Pause.png");
            // 
            // buttonStop
            // 
            buttonStop.AutoSize = true;
            buttonStop.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonStop.Dock = DockStyle.Fill;
            buttonStop.FlatAppearance.BorderSize = 0;
            buttonStop.FlatStyle = FlatStyle.Flat;
            buttonStop.ImageIndex = 2;
            buttonStop.ImageList = imageListSmall;
            buttonStop.Location = new Point(212, 4);
            buttonStop.Margin = new Padding(4);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(38, 47);
            buttonStop.TabIndex = 3;
            buttonStop.TextAlign = ContentAlignment.BottomCenter;
            toolTip1.SetToolTip(buttonStop, "Stop");
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonNext
            // 
            buttonNext.AutoSize = true;
            buttonNext.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonNext.Dock = DockStyle.Fill;
            buttonNext.FlatAppearance.BorderSize = 0;
            buttonNext.FlatStyle = FlatStyle.Flat;
            buttonNext.ImageIndex = 1;
            buttonNext.ImageList = imageListSmall;
            buttonNext.Location = new Point(166, 4);
            buttonNext.Margin = new Padding(4);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(38, 47);
            buttonNext.TabIndex = 2;
            buttonNext.TextAlign = ContentAlignment.BottomCenter;
            toolTip1.SetToolTip(buttonNext, "Next Track");
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(comboBoxOpmClock, 1, 0);
            tableLayoutPanel3.Controls.Add(comboBoxOpnaClock, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Controls.Add(label4, 2, 0);
            tableLayoutPanel3.Controls.Add(comboBoxLight, 3, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(500, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanelButton.SetRowSpan(tableLayoutPanel3, 2);
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(284, 82);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // comboBoxOpmClock
            // 
            comboBoxOpmClock.Dock = DockStyle.Fill;
            comboBoxOpmClock.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOpmClock.FormattingEnabled = true;
            comboBoxOpmClock.Items.AddRange(new object[] { "Auto", "3.57MHz", "4.00MHz" });
            comboBoxOpmClock.Location = new Point(91, 3);
            comboBoxOpmClock.Name = "comboBoxOpmClock";
            comboBoxOpmClock.Size = new Size(80, 23);
            comboBoxOpmClock.TabIndex = 1;
            // 
            // comboBoxOpnaClock
            // 
            comboBoxOpnaClock.Dock = DockStyle.Fill;
            comboBoxOpnaClock.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOpnaClock.FormattingEnabled = true;
            comboBoxOpnaClock.Items.AddRange(new object[] { "Auto", "8.00MHz", "7.98MHz" });
            comboBoxOpnaClock.Location = new Point(91, 32);
            comboBoxOpnaClock.Name = "comboBoxOpnaClock";
            comboBoxOpnaClock.Size = new Size(80, 23);
            comboBoxOpnaClock.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 29);
            label1.TabIndex = 0;
            label1.Text = "OP&M Clock:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(82, 29);
            label2.TabIndex = 2;
            label2.Text = "OP&NA Clock:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(177, 0);
            label4.Name = "label4";
            label4.Size = new Size(34, 29);
            label4.TabIndex = 4;
            label4.Text = "&Light";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxLight
            // 
            comboBoxLight.Dock = DockStyle.Fill;
            comboBoxLight.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLight.FormattingEnabled = true;
            comboBoxLight.Items.AddRange(new object[] { "Off", "On" });
            comboBoxLight.Location = new Point(217, 3);
            comboBoxLight.Name = "comboBoxLight";
            comboBoxLight.Size = new Size(64, 23);
            comboBoxLight.TabIndex = 5;
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Dock = DockStyle.Fill;
            labelPort.Location = new Point(3, 0);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(32, 29);
            labelPort.TabIndex = 0;
            labelPort.Text = "&Port:";
            labelPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxSerial
            // 
            comboBoxSerial.Dock = DockStyle.Fill;
            comboBoxSerial.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSerial.FormattingEnabled = true;
            comboBoxSerial.Location = new Point(41, 3);
            comboBoxSerial.Name = "comboBoxSerial";
            comboBoxSerial.Size = new Size(405, 23);
            comboBoxSerial.TabIndex = 1;
            comboBoxSerial.DropDown += comboBoxSerial_DropDown;
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(582, 3);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(98, 23);
            buttonConnect.TabIndex = 4;
            buttonConnect.Text = "&Connect";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(label7, 0, 0);
            tableLayoutPanel2.Controls.Add(textBoxTitle, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Bottom;
            tableLayoutPanel2.Location = new Point(0, 669);
            tableLayoutPanel2.Margin = new Padding(4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(787, 32);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(4, 0);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(46, 32);
            label7.TabIndex = 0;
            label7.Text = "&Current";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxTitle
            // 
            textBoxTitle.BorderStyle = BorderStyle.FixedSingle;
            textBoxTitle.Dock = DockStyle.Fill;
            textBoxTitle.Location = new Point(58, 4);
            textBoxTitle.Margin = new Padding(4);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.ReadOnly = true;
            textBoxTitle.ShortcutsEnabled = false;
            textBoxTitle.Size = new Size(725, 23);
            textBoxTitle.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip1.Location = new Point(0, 791);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 12, 0);
            statusStrip1.Size = new Size(787, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(0, 17);
            // 
            // columnHeaderFile
            // 
            columnHeaderFile.Text = "File name";
            columnHeaderFile.Width = 325;
            // 
            // listViewList
            // 
            listViewList.Columns.AddRange(new ColumnHeader[] { columnHeaderFileName, columnHeaderSize, columnHeaderDateTime, columnHeaderLongFileName });
            listViewList.Dock = DockStyle.Fill;
            listViewList.FullRowSelect = true;
            listViewList.GridLines = true;
            listViewList.Location = new Point(0, 65);
            listViewList.MultiSelect = false;
            listViewList.Name = "listViewList";
            listViewList.Size = new Size(787, 604);
            listViewList.TabIndex = 2;
            listViewList.UseCompatibleStateImageBehavior = false;
            listViewList.View = View.Details;
            listViewList.ColumnClick += listViewList_ColumnClick;
            listViewList.ItemSelectionChanged += listViewList_ItemSelectionChanged;
            listViewList.DoubleClick += listViewList_DoubleClick;
            listViewList.KeyDown += listViewList_KeyDown;
            // 
            // columnHeaderFileName
            // 
            columnHeaderFileName.Text = "File name";
            // 
            // columnHeaderSize
            // 
            columnHeaderSize.Text = "Size";
            // 
            // columnHeaderDateTime
            // 
            columnHeaderDateTime.Text = "Date";
            // 
            // columnHeaderLongFileName
            // 
            columnHeaderLongFileName.Text = "Long file name";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(comboBoxSerial, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonConnect, 4, 0);
            tableLayoutPanel1.Controls.Add(labelPort, 0, 0);
            tableLayoutPanel1.Controls.Add(buttonReset, 5, 0);
            tableLayoutPanel1.Controls.Add(label3, 2, 0);
            tableLayoutPanel1.Controls.Add(numericUpDownTimeout, 3, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 24);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(787, 41);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(686, 3);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(98, 23);
            buttonReset.TabIndex = 5;
            buttonReset.Text = "Pan&ic";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(452, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 29);
            label3.TabIndex = 2;
            label3.Text = "&Timeout:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownTimeout
            // 
            numericUpDownTimeout.Location = new Point(511, 3);
            numericUpDownTimeout.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownTimeout.Minimum = new decimal(new int[] { 300, 0, 0, 0 });
            numericUpDownTimeout.Name = "numericUpDownTimeout";
            numericUpDownTimeout.Size = new Size(65, 23);
            numericUpDownTimeout.TabIndex = 3;
            numericUpDownTimeout.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 813);
            Controls.Add(listViewList);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanelButton);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "FormMain";
            Text = "OPNAM Player V1.2";
            KeyDown += FormMain_KeyDown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanelButton.ResumeLayout(false);
            tableLayoutPanelButton.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eXITToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelButton;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ColumnHeader columnHeaderFile;
        private System.Windows.Forms.Button buttonPrev;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ImageList imageListBig;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private ListView listViewList;
        private Label labelPort;
        private ComboBox comboBoxSerial;
        private ColumnHeader columnHeaderFileName;
        private Button buttonConnect;
        private ColumnHeader columnHeaderSize;
        private ColumnHeader columnHeaderDateTime;
        private ColumnHeader columnHeaderLongFileName;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonReset;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox comboBoxOpmClock;
        private ComboBox comboBoxOpnaClock;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown numericUpDownTimeout;
        private Label label4;
        private ToolStripStatusLabel toolStripStatusLabel;
        private ComboBox comboBoxLight;
    }
}