namespace KDATFFSRunner
{
    partial class wKdatffsRunner
    {
        
        private System.ComponentModel.IContainer components = null;

        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 

        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wKdatffsRunner));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenExcelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenCsvFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSqlServer = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.UseDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cTestStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cTestStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cTestRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.chooseBrowserType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ProfileLable = new System.Windows.Forms.ToolStripLabel();
            this.hasProfile = new System.Windows.Forms.ToolStripComboBox();
            this.setProfile = new System.Windows.Forms.ToolStripDropDownButton();
            this.ServerName = new System.Windows.Forms.ToolStripTextBox();
            this.ServerPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.StepSpacingTime = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tscbDataDriver = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.testTreeView = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.wTestStep = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TestTable = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numOfFailStep = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numOfCompletedStep = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numOfTestStep = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOfTest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wTestData = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.testDataTreeView = new System.Windows.Forms.TreeView();
            this.testDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbImportData = new System.Windows.Forms.ToolStripButton();
            this.tsbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.wTestLog = new System.Windows.Forms.TabPage();
            this.ClearLog = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SelectLog = new System.Windows.Forms.ComboBox();
            this.SaveToFile = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TestLog = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExecuteStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openTestFile = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.wTestStep.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.wTestData.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.wTestLog.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1057, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenExcelFile,
            this.OpenCsvFile,
            this.OpenSqlServer,
            this.CloseWindow});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(41, 20);
            this.FileMenu.Text = "File";
            // 
            // OpenExcelFile
            // 
            this.OpenExcelFile.Name = "OpenExcelFile";
            this.OpenExcelFile.Size = new System.Drawing.Size(160, 22);
            this.OpenExcelFile.Text = "Open Excel File";
            this.OpenExcelFile.Click += new System.EventHandler(this.OpenExcelFile_Click);
            // 
            // OpenCsvFile
            // 
            this.OpenCsvFile.Name = "OpenCsvFile";
            this.OpenCsvFile.Size = new System.Drawing.Size(160, 22);
            this.OpenCsvFile.Text = "Open Csv File";
            this.OpenCsvFile.Click += new System.EventHandler(this.OpenCsvFile_Click);
            // 
            // OpenSqlServer
            // 
            this.OpenSqlServer.Name = "OpenSqlServer";
            this.OpenSqlServer.Size = new System.Drawing.Size(160, 22);
            this.OpenSqlServer.Text = "Open SQLSvrDB";
            // 
            // CloseWindow
            // 
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(160, 22);
            this.CloseWindow.Text = "Exit";
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UseDocument,
            this.About});
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(41, 20);
            this.Help.Text = "Help";
            // 
            // UseDocument
            // 
            this.UseDocument.Name = "UseDocument";
            this.UseDocument.Size = new System.Drawing.Size(148, 22);
            this.UseDocument.Text = "Instruction";
            // 
            // About
            // 
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(148, 22);
            this.About.Text = "About KDATFFS";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cTestStart,
            this.toolStripSeparator1,
            this.cTestStop,
            this.toolStripSeparator2,
            this.cTestRefresh,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.chooseBrowserType,
            this.toolStripSeparator5,
            this.ProfileLable,
            this.hasProfile,
            this.setProfile,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.StepSpacingTime,
            this.toolStripLabel3,
            this.tscbDataDriver});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1057, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cTestStart
            // 
            this.cTestStart.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.cTestStart.Image = ((System.Drawing.Image)(resources.GetObject("cTestStart.Image")));
            this.cTestStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cTestStart.Name = "cTestStart";
            this.cTestStart.Size = new System.Drawing.Size(50, 22);
            this.cTestStart.Text = "Start";
            this.cTestStart.Click += new System.EventHandler(this.cTestStart_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // cTestStop
            // 
            this.cTestStop.Image = ((System.Drawing.Image)(resources.GetObject("cTestStop.Image")));
            this.cTestStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cTestStop.Name = "cTestStop";
            this.cTestStop.Size = new System.Drawing.Size(49, 22);
            this.cTestStop.Text = "Stop";
            this.cTestStop.Click += new System.EventHandler(this.cTestStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cTestRefresh
            // 
            this.cTestRefresh.Image = ((System.Drawing.Image)(resources.GetObject("cTestRefresh.Image")));
            this.cTestRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cTestRefresh.Name = "cTestRefresh";
            this.cTestRefresh.Size = new System.Drawing.Size(67, 22);
            this.cTestRefresh.Text = "Refresh";
            this.cTestRefresh.Click += new System.EventHandler(this.cTestRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(83, 22);
            this.toolStripLabel1.Text = "Browser Type:";
            // 
            // chooseBrowserType
            // 
            this.chooseBrowserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.chooseBrowserType.DropDownWidth = 80;
            this.chooseBrowserType.Name = "chooseBrowserType";
            this.chooseBrowserType.Size = new System.Drawing.Size(80, 25);
            this.chooseBrowserType.SelectedIndexChanged += new System.EventHandler(this.chooseBrowserType_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // ProfileLable
            // 
            this.ProfileLable.Name = "ProfileLable";
            this.ProfileLable.Size = new System.Drawing.Size(41, 22);
            this.ProfileLable.Text = "Proxy:";
            // 
            // hasProfile
            // 
            this.hasProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hasProfile.Items.AddRange(new object[] {
            "yes",
            "no"});
            this.hasProfile.Name = "hasProfile";
            this.hasProfile.Size = new System.Drawing.Size(75, 25);
            this.hasProfile.SelectedIndexChanged += new System.EventHandler(this.hasProfile_SelectedIndexChanged);
            // 
            // setProfile
            // 
            this.setProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerName,
            this.ServerPort});
            this.setProfile.Image = ((System.Drawing.Image)(resources.GetObject("setProfile.Image")));
            this.setProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.setProfile.Name = "setProfile";
            this.setProfile.Size = new System.Drawing.Size(96, 22);
            this.setProfile.Text = "Proxy Setting";
            // 
            // ServerName
            // 
            this.ServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(150, 21);
            this.ServerName.ToolTipText = "Proxy Address";
            // 
            // ServerPort
            // 
            this.ServerPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(150, 21);
            this.ServerPort.ToolTipText = "Proxy Port";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel2.Text = "Speed:";
            // 
            // StepSpacingTime
            // 
            this.StepSpacingTime.Items.AddRange(new object[] {
            "0",
            "30",
            "50",
            "100",
            "300",
            "500",
            "800",
            "1000",
            "2000"});
            this.StepSpacingTime.Name = "StepSpacingTime";
            this.StepSpacingTime.Size = new System.Drawing.Size(75, 25);
            this.StepSpacingTime.TextChanged += new System.EventHandler(this.StepSpacingTime_TextChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(77, 22);
            this.toolStripLabel3.Text = "Data Driver:";
            // 
            // tscbDataDriver
            // 
            this.tscbDataDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbDataDriver.Items.AddRange(new object[] {
            "yes",
            "no"});
            this.tscbDataDriver.Name = "tscbDataDriver";
            this.tscbDataDriver.Size = new System.Drawing.Size(75, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.testTreeView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 558);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 2;
            // 
            // testTreeView
            // 
            this.testTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testTreeView.Location = new System.Drawing.Point(0, 25);
            this.testTreeView.Name = "testTreeView";
            this.testTreeView.Size = new System.Drawing.Size(182, 533);
            this.testTreeView.TabIndex = 1;
            this.testTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.testTreeView_AfterCheck);
            this.testTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testTreeView_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(182, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.wTestStep);
            this.tabControl1.Controls.Add(this.wTestData);
            this.tabControl1.Controls.Add(this.wTestLog);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(868, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // wTestStep
            // 
            this.wTestStep.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.wTestStep.Controls.Add(this.groupBox2);
            this.wTestStep.Controls.Add(this.groupBox1);
            this.wTestStep.Location = new System.Drawing.Point(4, 21);
            this.wTestStep.Name = "wTestStep";
            this.wTestStep.Padding = new System.Windows.Forms.Padding(3);
            this.wTestStep.Size = new System.Drawing.Size(860, 508);
            this.wTestStep.TabIndex = 0;
            this.wTestStep.Text = "Test Step";
            this.wTestStep.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.TestTable);
            this.groupBox2.Location = new System.Drawing.Point(7, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 427);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Step";
            // 
            // TestTable
            // 
            this.TestTable.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TestTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status});
            this.TestTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestTable.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TestTable.Location = new System.Drawing.Point(3, 17);
            this.TestTable.Name = "TestTable";
            this.TestTable.RowTemplate.Height = 23;
            this.TestTable.Size = new System.Drawing.Size(842, 407);
            this.TestTable.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Image = global::KDATFFSRunner.Properties.Resources.normal2;
            this.Status.Name = "Status";
            this.Status.Width = 45;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Controls.Add(this.numOfFailStep);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numOfCompletedStep);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numOfTestStep);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numOfTest);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(848, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Test Status";
            // 
            // numOfFailStep
            // 
            this.numOfFailStep.AutoSize = true;
            this.numOfFailStep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numOfFailStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.numOfFailStep.Location = new System.Drawing.Point(586, 26);
            this.numOfFailStep.Name = "numOfFailStep";
            this.numOfFailStep.Size = new System.Drawing.Size(0, 16);
            this.numOfFailStep.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(480, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Failed Number:";
            // 
            // numOfCompletedStep
            // 
            this.numOfCompletedStep.AutoSize = true;
            this.numOfCompletedStep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numOfCompletedStep.ForeColor = System.Drawing.Color.Green;
            this.numOfCompletedStep.Location = new System.Drawing.Point(431, 26);
            this.numOfCompletedStep.Name = "numOfCompletedStep";
            this.numOfCompletedStep.Size = new System.Drawing.Size(0, 16);
            this.numOfCompletedStep.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(318, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Completed Number:";
            // 
            // numOfTestStep
            // 
            this.numOfTestStep.AutoSize = true;
            this.numOfTestStep.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numOfTestStep.Location = new System.Drawing.Point(258, 26);
            this.numOfTestStep.Name = "numOfTestStep";
            this.numOfTestStep.Size = new System.Drawing.Size(0, 16);
            this.numOfTestStep.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(145, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Test Step Number:";
            // 
            // numOfTest
            // 
            this.numOfTest.AutoSize = true;
            this.numOfTest.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numOfTest.ForeColor = System.Drawing.Color.Black;
            this.numOfTest.Location = new System.Drawing.Point(100, 26);
            this.numOfTest.Name = "numOfTest";
            this.numOfTest.Size = new System.Drawing.Size(0, 16);
            this.numOfTest.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Test Number:";
            // 
            // wTestData
            // 
            this.wTestData.Controls.Add(this.splitContainer2);
            this.wTestData.Controls.Add(this.toolStrip3);
            this.wTestData.Location = new System.Drawing.Point(4, 21);
            this.wTestData.Name = "wTestData";
            this.wTestData.Padding = new System.Windows.Forms.Padding(3);
            this.wTestData.Size = new System.Drawing.Size(860, 508);
            this.wTestData.TabIndex = 2;
            this.wTestData.Text = "Test Data";
            this.wTestData.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 28);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.testDataTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.testDataGridView);
            this.splitContainer2.Size = new System.Drawing.Size(854, 477);
            this.splitContainer2.SplitterDistance = 157;
            this.splitContainer2.TabIndex = 1;
            // 
            // testDataTreeView
            // 
            this.testDataTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testDataTreeView.Location = new System.Drawing.Point(0, 0);
            this.testDataTreeView.Name = "testDataTreeView";
            this.testDataTreeView.Size = new System.Drawing.Size(157, 477);
            this.testDataTreeView.TabIndex = 0;
            this.testDataTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testDataTreeView_AfterSelect);
            // 
            // testDataGridView
            // 
            this.testDataGridView.BackgroundColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.testDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testDataGridView.Location = new System.Drawing.Point(0, 0);
            this.testDataGridView.Name = "testDataGridView";
            this.testDataGridView.RowTemplate.Height = 23;
            this.testDataGridView.Size = new System.Drawing.Size(693, 477);
            this.testDataGridView.TabIndex = 0;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbImportData,
            this.tsbRefreshData});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(854, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbImportData
            // 
            this.tsbImportData.Image = ((System.Drawing.Image)(resources.GetObject("tsbImportData.Image")));
            this.tsbImportData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImportData.Name = "tsbImportData";
            this.tsbImportData.Size = new System.Drawing.Size(61, 22);
            this.tsbImportData.Text = "Import";
            this.tsbImportData.Click += new System.EventHandler(this.tsbImportData_Click);
            // 
            // tsbRefreshData
            // 
            this.tsbRefreshData.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshData.Image")));
            this.tsbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshData.Name = "tsbRefreshData";
            this.tsbRefreshData.Size = new System.Drawing.Size(67, 22);
            this.tsbRefreshData.Text = "Refresh";
            this.tsbRefreshData.Click += new System.EventHandler(this.tsbRefreshData_Click);
            // 
            // wTestLog
            // 
            this.wTestLog.Controls.Add(this.ClearLog);
            this.wTestLog.Controls.Add(this.label5);
            this.wTestLog.Controls.Add(this.SelectLog);
            this.wTestLog.Controls.Add(this.SaveToFile);
            this.wTestLog.Controls.Add(this.groupBox3);
            this.wTestLog.Location = new System.Drawing.Point(4, 21);
            this.wTestLog.Name = "wTestLog";
            this.wTestLog.Padding = new System.Windows.Forms.Padding(3);
            this.wTestLog.Size = new System.Drawing.Size(860, 508);
            this.wTestLog.TabIndex = 1;
            this.wTestLog.Text = "Test Log";
            this.wTestLog.UseVisualStyleBackColor = true;
            // 
            // ClearLog
            // 
            this.ClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearLog.Location = new System.Drawing.Point(224, 476);
            this.ClearLog.Name = "ClearLog";
            this.ClearLog.Size = new System.Drawing.Size(75, 23);
            this.ClearLog.TabIndex = 4;
            this.ClearLog.Text = "Clear";
            this.ClearLog.UseVisualStyleBackColor = true;
            this.ClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 484);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Filter Log:";
            // 
            // SelectLog
            // 
            this.SelectLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectLog.FormattingEnabled = true;
            this.SelectLog.Items.AddRange(new object[] {
            "All",
            "Only Error"});
            this.SelectLog.Location = new System.Drawing.Point(93, 479);
            this.SelectLog.Name = "SelectLog";
            this.SelectLog.Size = new System.Drawing.Size(113, 20);
            this.SelectLog.TabIndex = 2;
            // 
            // SaveToFile
            // 
            this.SaveToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveToFile.Location = new System.Drawing.Point(314, 476);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(84, 23);
            this.SaveToFile.TabIndex = 1;
            this.SaveToFile.Text = "Save as";
            this.SaveToFile.UseVisualStyleBackColor = true;
            this.SaveToFile.Click += new System.EventHandler(this.SaveToFile_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TestLog);
            this.groupBox3.Location = new System.Drawing.Point(4, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(851, 462);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Execute Log";
            // 
            // TestLog
            // 
            this.TestLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TestLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestLog.Location = new System.Drawing.Point(3, 17);
            this.TestLog.Name = "TestLog";
            this.TestLog.Size = new System.Drawing.Size(845, 442);
            this.TestLog.TabIndex = 0;
            this.TestLog.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ExecuteStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 585);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1057, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // ExecuteStatus
            // 
            this.ExecuteStatus.Name = "ExecuteStatus";
            this.ExecuteStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // openTestFile
            // 
            this.openTestFile.FileName = "openFileDialog1";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Status";
            this.dataGridViewImageColumn1.Image = global::KDATFFSRunner.Properties.Resources.normal2;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 45;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // wKdatffsRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 607);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "wKdatffsRunner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KDATFFSRunner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.wTestStep.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.wTestData.ResumeLayout(false);
            this.wTestData.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testDataGridView)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.wTestLog.ResumeLayout(false);
            this.wTestLog.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenExcelFile;
        private System.Windows.Forms.ToolStripMenuItem OpenCsvFile;
        private System.Windows.Forms.ToolStripMenuItem OpenSqlServer;
        private System.Windows.Forms.ToolStripMenuItem CloseWindow;
        private System.Windows.Forms.ToolStripMenuItem Help;
        private System.Windows.Forms.ToolStripMenuItem UseDocument;
        private System.Windows.Forms.ToolStripMenuItem About;
        private System.Windows.Forms.TreeView testTreeView;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage wTestStep;
        private System.Windows.Forms.TabPage wTestLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton cTestStart;
        private System.Windows.Forms.ToolStripButton cTestStop;
        private System.Windows.Forms.ToolStripButton cTestRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView TestTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox chooseBrowserType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox hasProfile;
        private System.Windows.Forms.Label numOfTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label numOfFailStep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label numOfCompletedStep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label numOfTestStep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openTestFile;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.Button SaveToFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox TestLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox SelectLog;
        private System.Windows.Forms.Button ClearLog;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox StepSpacingTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ExecuteStatus;
        private System.Windows.Forms.ToolStripDropDownButton setProfile;
        private System.Windows.Forms.ToolStripTextBox ServerName;
        private System.Windows.Forms.ToolStripTextBox ServerPort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel ProfileLable;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage wTestData;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView testDataTreeView;
        private System.Windows.Forms.DataGridView testDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbImportData;
        private System.Windows.Forms.ToolStripButton tsbRefreshData;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox tscbDataDriver;
    }
}

