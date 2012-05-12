namespace KDATFFSRecorder
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tssmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFavorities = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFavoritiesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFavoritiesOrganize = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscBack = new System.Windows.Forms.ToolStripButton();
            this.tscForward = new System.Windows.Forms.ToolStripButton();
            this.tscStop = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscUrl = new System.Windows.Forms.ToolStripComboBox();
            this.tscGoto = new System.Windows.Forms.ToolStripButton();
            this.ClosePage = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.curTest = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspLoadProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cEXWB1 = new csExWB.cEXWB();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.testTreeView = new System.Windows.Forms.TreeView();
            this.TestGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstTestName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDeleteStep = new System.Windows.Forms.ToolStripButton();
            this.tsbClearTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstbSheetName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.InputEcel = new System.Windows.Forms.ToolStripMenuItem();
            this.InputCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.tsdOutput = new System.Windows.Forms.ToolStripDropDownButton();
            this.excelOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.CsvOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRecorder = new System.Windows.Forms.ToolStripButton();
            this.tsbRecordComment = new System.Windows.Forms.ToolStripButton();
            this.tsbFindElement = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuElement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ttsmAddBrowserStep = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executeScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToAlertAcceptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToAlertDismissToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waitForPageLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttsmAddTestStep = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ttsmAddValitation = new System.Windows.Forms.ToolStripMenuItem();
            this.ValidateItemValue = new System.Windows.Forms.ToolStripMenuItem();
            this.ValidateItemText = new System.Windows.Forms.ToolStripMenuItem();
            this.ValidateBrowserTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.validateBrowserUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateAlertTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateContainTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeElementCheck = new System.Windows.Forms.Timer(this.components);
            this.fswFavorities = new System.IO.FileSystemWatcher();
            this.saveToFile = new System.Windows.Forms.SaveFileDialog();
            this.InputFromFile = new System.Windows.Forms.OpenFileDialog();
            this.getTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TestGrid)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.contextMenuElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fswFavorities)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.tsmFavorities,
            this.HelpHToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.tssmExit});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.FileToolStripMenuItem.Text = "File(&F)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(109, 6);
            // 
            // tssmExit
            // 
            this.tssmExit.Name = "tssmExit";
            this.tssmExit.Size = new System.Drawing.Size(112, 22);
            this.tssmExit.Text = "Exit(&X)";
            this.tssmExit.Click += new System.EventHandler(this.tssmExit_Click);
            // 
            // tsmFavorities
            // 
            this.tsmFavorities.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmFavoritiesAdd,
            this.tsmFavoritiesOrganize});
            this.tsmFavorities.Name = "tsmFavorities";
            this.tsmFavorities.Size = new System.Drawing.Size(89, 20);
            this.tsmFavorities.Text = "Favorites(&A)";
            // 
            // tsmFavoritiesAdd
            // 
            this.tsmFavoritiesAdd.Name = "tsmFavoritiesAdd";
            this.tsmFavoritiesAdd.Size = new System.Drawing.Size(178, 22);
            this.tsmFavoritiesAdd.Text = "Add Favorites";
            this.tsmFavoritiesAdd.Click += new System.EventHandler(this.FavoritiesOpeartionHandler);
            // 
            // tsmFavoritiesOrganize
            // 
            this.tsmFavoritiesOrganize.Name = "tsmFavoritiesOrganize";
            this.tsmFavoritiesOrganize.Size = new System.Drawing.Size(178, 22);
            this.tsmFavoritiesOrganize.Text = "Organize Favorites";
            this.tsmFavoritiesOrganize.Click += new System.EventHandler(this.FavoritiesOpeartionHandler);
            // 
            // HelpHToolStripMenuItem
            // 
            this.HelpHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutAToolStripMenuItem});
            this.HelpHToolStripMenuItem.Name = "HelpHToolStripMenuItem";
            this.HelpHToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.HelpHToolStripMenuItem.Text = "Help(&H)";
            // 
            // AboutAToolStripMenuItem
            // 
            this.AboutAToolStripMenuItem.Name = "AboutAToolStripMenuItem";
            this.AboutAToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.AboutAToolStripMenuItem.Text = "About(&A)...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscBack,
            this.tscForward,
            this.tscStop,
            this.tsbRefresh,
            this.toolStripLabel1,
            this.tscUrl,
            this.tscGoto,
            this.ClosePage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(959, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscBack
            // 
            this.tscBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscBack.Image = ((System.Drawing.Image)(resources.GetObject("tscBack.Image")));
            this.tscBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscBack.Name = "tscBack";
            this.tscBack.Size = new System.Drawing.Size(23, 22);
            this.tscBack.Text = "Back";
            this.tscBack.Click += new System.EventHandler(this.tscBack_Click);
            // 
            // tscForward
            // 
            this.tscForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscForward.Image = ((System.Drawing.Image)(resources.GetObject("tscForward.Image")));
            this.tscForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscForward.Name = "tscForward";
            this.tscForward.Size = new System.Drawing.Size(23, 22);
            this.tscForward.Text = "Forward";
            this.tscForward.Click += new System.EventHandler(this.tscForward_Click);
            // 
            // tscStop
            // 
            this.tscStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscStop.Image = ((System.Drawing.Image)(resources.GetObject("tscStop.Image")));
            this.tscStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscStop.Name = "tscStop";
            this.tscStop.Size = new System.Drawing.Size(23, 22);
            this.tscStop.Text = "Stop";
            this.tscStop.Click += new System.EventHandler(this.tscStop_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "URL:";
            // 
            // tscUrl
            // 
            this.tscUrl.Name = "tscUrl";
            this.tscUrl.Size = new System.Drawing.Size(600, 25);
            this.tscUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tscUrl_KeyUp);
            // 
            // tscGoto
            // 
            this.tscGoto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tscGoto.Image = ((System.Drawing.Image)(resources.GetObject("tscGoto.Image")));
            this.tscGoto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscGoto.Name = "tscGoto";
            this.tscGoto.Size = new System.Drawing.Size(23, 22);
            this.tscGoto.Text = "toolStripButton4";
            this.tscGoto.Click += new System.EventHandler(this.tscGoto_Click);
            // 
            // ClosePage
            // 
            this.ClosePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClosePage.Image = ((System.Drawing.Image)(resources.GetObject("ClosePage.Image")));
            this.ClosePage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClosePage.Name = "ClosePage";
            this.ClosePage.Size = new System.Drawing.Size(23, 22);
            this.ClosePage.Text = "toolStripButton1";
            this.ClosePage.Click += new System.EventHandler(this.ClosePage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.curTest,
            this.tsStatus,
            this.tspLoadProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "Current Test:";
            // 
            // curTest
            // 
            this.curTest.Name = "curTest";
            this.curTest.Size = new System.Drawing.Size(0, 17);
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(861, 17);
            this.tsStatus.Spring = true;
            this.tsStatus.Text = "Ready...";
            this.tsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspLoadProgress
            // 
            this.tspLoadProgress.Name = "tspLoadProgress";
            this.tspLoadProgress.Size = new System.Drawing.Size(100, 16);
            this.tspLoadProgress.Step = 1;
            this.tspLoadProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.tspLoadProgress.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cEXWB1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(959, 590);
            this.splitContainer1.SplitterDistance = 360;
            this.splitContainer1.TabIndex = 3;
            // 
            // cEXWB1
            // 
            this.cEXWB1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cEXWB1.Border3DEnabled = false;
            this.cEXWB1.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.cEXWB1.DocumentTitle = "";
            this.cEXWB1.DownloadActiveX = true;
            this.cEXWB1.DownloadFrames = true;
            this.cEXWB1.DownloadImages = true;
            this.cEXWB1.DownloadJava = true;
            this.cEXWB1.DownloadScripts = true;
            this.cEXWB1.DownloadSounds = true;
            this.cEXWB1.DownloadVideo = true;
            this.cEXWB1.FileDownloadDirectory = "C:\\Documents and settings\\felix_ada\\My Documents\\";
            this.cEXWB1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cEXWB1.Location = new System.Drawing.Point(3, 0);
            this.cEXWB1.LocationUrl = "about:blank";
            this.cEXWB1.Name = "cEXWB1";
            this.cEXWB1.ObjectForScripting = null;
            this.cEXWB1.OffLine = false;
            this.cEXWB1.RegisterAsBrowser = false;
            this.cEXWB1.RegisterAsDropTarget = false;
            this.cEXWB1.RegisterForInternalDragDrop = true;
            this.cEXWB1.ScrollBarsEnabled = true;
            this.cEXWB1.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB1.Silent = false;
            this.cEXWB1.Size = new System.Drawing.Size(953, 357);
            this.cEXWB1.TabIndex = 0;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.UseInternalDownloadManager = true;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB1.DownloadComplete += new csExWB.DownloadCompleteEventHandler(this.cEXWB1_DownloadComplete);
            this.cEXWB1.DocumentComplete += new csExWB.DocumentCompleteEventHandler(this.cEXWB1_DocumentComplete);
            this.cEXWB1.WBKeyUp += new csExWB.WBKeyUpEventHandler(this.cEXWB1_WBKeyUp);
            this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(this.cEXWB1_TitleChange);
            this.cEXWB1.NewWindow2 += new csExWB.NewWindow2EventHandler(this.cEXWB1_NewWindow2);
            this.cEXWB1.ScriptError += new csExWB.ScriptErrorEventHandler(this.cEXWB1_ScriptError);
            this.cEXWB1.WBMouseMove += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBMouseMove);
            this.cEXWB1.WBDocHostShowUIShowMessage += new csExWB.DocHostShowUIShowMessageEventHandler(this.cEXWB1_WBDocHostShowUIShowMessage);
            this.cEXWB1.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
            this.cEXWB1.WBLButtonUp += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBLButtonUp);
            this.cEXWB1.WindowClosing += new csExWB.WindowClosingEventHandler(this.cEXWB1_WindowClosing);
            this.cEXWB1.DownloadBegin += new csExWB.DownloadBeginEventHandler(this.cEXWB1_DownloadBegin);
            this.cEXWB1.WBEvaluteNewWindow += new csExWB.EvaluateNewWindowEventHandler(this.cEXWB1_WBEvaluteNewWindow);
            this.cEXWB1.NewWindow3 += new csExWB.NewWindow3EventHandler(this.cEXWB1_NewWindow3);
            this.cEXWB1.ProgressChange += new csExWB.ProgressChangeEventHandler(this.cEXWB1_ProgressChange);
            this.cEXWB1.WBLButtonDown += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBLButtonDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(953, 223);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Controls.Add(this.toolStrip2);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(945, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Test Record";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 28);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.testTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TestGrid);
            this.splitContainer2.Size = new System.Drawing.Size(939, 167);
            this.splitContainer2.SplitterDistance = 102;
            this.splitContainer2.TabIndex = 1;
            // 
            // testTreeView
            // 
            this.testTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.testTreeView.CheckBoxes = true;
            this.testTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testTreeView.Location = new System.Drawing.Point(0, 0);
            this.testTreeView.Name = "testTreeView";
            this.testTreeView.Size = new System.Drawing.Size(102, 167);
            this.testTreeView.TabIndex = 0;
            this.testTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.testTreeView_AfterSelect);
            // 
            // TestGrid
            // 
            this.TestGrid.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestGrid.Location = new System.Drawing.Point(0, 0);
            this.TestGrid.Name = "TestGrid";
            this.TestGrid.RowTemplate.Height = 23;
            this.TestGrid.Size = new System.Drawing.Size(833, 167);
            this.TestGrid.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tstTestName,
            this.tsbAdd,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbDeleteStep,
            this.tsbClearTable,
            this.toolStripLabel3,
            this.tstbSheetName,
            this.toolStripDropDownButton1,
            this.tsdOutput,
            this.toolStripSeparator2,
            this.tsbRecorder,
            this.tsbRecordComment,
            this.tsbFindElement,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(939, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel2.Text = "Test Name:";
            // 
            // tstTestName
            // 
            this.tstTestName.Name = "tstTestName";
            this.tstTestName.Size = new System.Drawing.Size(120, 25);
            this.tstTestName.ToolTipText = "Test Name";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Text = "toolStripButton1";
            this.tsbAdd.ToolTipText = "Add Test";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Text = "toolStripButton2";
            this.tsbDelete.ToolTipText = "Delete Test";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDeleteStep
            // 
            this.tsbDeleteStep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteStep.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteStep.Image")));
            this.tsbDeleteStep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteStep.Name = "tsbDeleteStep";
            this.tsbDeleteStep.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteStep.Text = "toolStripButton1";
            this.tsbDeleteStep.ToolTipText = "Delete Test Step";
            this.tsbDeleteStep.Click += new System.EventHandler(this.tsbDeleteStep_Click);
            // 
            // tsbClearTable
            // 
            this.tsbClearTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClearTable.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearTable.Image")));
            this.tsbClearTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearTable.Name = "tsbClearTable";
            this.tsbClearTable.Size = new System.Drawing.Size(23, 22);
            this.tsbClearTable.Text = "toolStripButton2";
            this.tsbClearTable.ToolTipText = "Clear Test Step";
            this.tsbClearTable.Click += new System.EventHandler(this.tsbClearTable_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(71, 22);
            this.toolStripLabel3.Text = "Sheet Name:";
            // 
            // tstbSheetName
            // 
            this.tstbSheetName.Name = "tstbSheetName";
            this.tstbSheetName.Size = new System.Drawing.Size(100, 25);
            this.tstbSheetName.ToolTipText = "Sheet Name";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InputEcel,
            this.InputCsv});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Import";
            this.toolStripDropDownButton1.ToolTipText = "Import";
            // 
            // InputEcel
            // 
            this.InputEcel.Image = global::KDATFFSRecorder.Properties.Resources.xls;
            this.InputEcel.Name = "InputEcel";
            this.InputEcel.Size = new System.Drawing.Size(172, 22);
            this.InputEcel.Text = "Import from Excel";
            this.InputEcel.Click += new System.EventHandler(this.InputEcel_Click);
            // 
            // InputCsv
            // 
            this.InputCsv.Image = global::KDATFFSRecorder.Properties.Resources.csv;
            this.InputCsv.Name = "InputCsv";
            this.InputCsv.Size = new System.Drawing.Size(172, 22);
            this.InputCsv.Text = "Import from Csv";
            this.InputCsv.Click += new System.EventHandler(this.InputCsv_Click);
            // 
            // tsdOutput
            // 
            this.tsdOutput.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsdOutput.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excelOutput,
            this.CsvOutput});
            this.tsdOutput.Image = ((System.Drawing.Image)(resources.GetObject("tsdOutput.Image")));
            this.tsdOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsdOutput.Name = "tsdOutput";
            this.tsdOutput.Size = new System.Drawing.Size(29, 22);
            this.tsdOutput.Text = "Export";
            // 
            // excelOutput
            // 
            this.excelOutput.Image = global::KDATFFSRecorder.Properties.Resources.xls;
            this.excelOutput.Name = "excelOutput";
            this.excelOutput.Size = new System.Drawing.Size(160, 22);
            this.excelOutput.Text = "Export to Excel";
            this.excelOutput.Click += new System.EventHandler(this.excelOutput_Click);
            // 
            // CsvOutput
            // 
            this.CsvOutput.Image = global::KDATFFSRecorder.Properties.Resources.csv;
            this.CsvOutput.Name = "CsvOutput";
            this.CsvOutput.Size = new System.Drawing.Size(160, 22);
            this.CsvOutput.Text = "Export to Csv";
            this.CsvOutput.Click += new System.EventHandler(this.CsvOutput_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRecorder
            // 
            this.tsbRecorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRecorder.Image = ((System.Drawing.Image)(resources.GetObject("tsbRecorder.Image")));
            this.tsbRecorder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecorder.Name = "tsbRecorder";
            this.tsbRecorder.Size = new System.Drawing.Size(23, 22);
            this.tsbRecorder.Text = "toolStripButton3";
            this.tsbRecorder.ToolTipText = "Is Record Step";
            this.tsbRecorder.Click += new System.EventHandler(this.tsbRecorder_Click);
            // 
            // tsbRecordComment
            // 
            this.tsbRecordComment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRecordComment.Image = ((System.Drawing.Image)(resources.GetObject("tsbRecordComment.Image")));
            this.tsbRecordComment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRecordComment.Name = "tsbRecordComment";
            this.tsbRecordComment.Size = new System.Drawing.Size(23, 22);
            this.tsbRecordComment.Text = "toolStripButton1";
            this.tsbRecordComment.ToolTipText = "Is Record Comment";
            this.tsbRecordComment.Click += new System.EventHandler(this.tsbRecordComment_Click);
            // 
            // tsbFindElement
            // 
            this.tsbFindElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFindElement.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindElement.Image")));
            this.tsbFindElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindElement.Name = "tsbFindElement";
            this.tsbFindElement.Size = new System.Drawing.Size(23, 22);
            this.tsbFindElement.Text = "toolStripButton1";
            this.tsbFindElement.ToolTipText = "Is Find Element";
            this.tsbFindElement.CheckedChanged += new System.EventHandler(this.tsbFindElement_CheckedChanged);
            this.tsbFindElement.Click += new System.EventHandler(this.tsbFindElement_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // contextMenuElement
            // 
            this.contextMenuElement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttsmAddBrowserStep,
            this.ttsmAddTestStep,
            this.ttsmAddValitation});
            this.contextMenuElement.Name = "contextMenuStrip1";
            this.contextMenuElement.Size = new System.Drawing.Size(155, 92);
            // 
            // ttsmAddBrowserStep
            // 
            this.ttsmAddBrowserStep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.gotoToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.executeScriptToolStripMenuItem,
            this.switchToAlertAcceptToolStripMenuItem,
            this.switchToAlertDismissToolStripMenuItem,
            this.waitForPageLoadToolStripMenuItem});
            this.ttsmAddBrowserStep.Name = "ttsmAddBrowserStep";
            this.ttsmAddBrowserStep.Size = new System.Drawing.Size(154, 22);
            this.ttsmAddBrowserStep.Text = "AddBrowserStep";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // gotoToolStripMenuItem
            // 
            this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
            this.gotoToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.gotoToolStripMenuItem.Text = "Goto";
            this.gotoToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // executeScriptToolStripMenuItem
            // 
            this.executeScriptToolStripMenuItem.Name = "executeScriptToolStripMenuItem";
            this.executeScriptToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.executeScriptToolStripMenuItem.Text = "ExecuteScript";
            this.executeScriptToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // switchToAlertAcceptToolStripMenuItem
            // 
            this.switchToAlertAcceptToolStripMenuItem.Name = "switchToAlertAcceptToolStripMenuItem";
            this.switchToAlertAcceptToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.switchToAlertAcceptToolStripMenuItem.Text = "SwitchToAlertAccept";
            this.switchToAlertAcceptToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // switchToAlertDismissToolStripMenuItem
            // 
            this.switchToAlertDismissToolStripMenuItem.Name = "switchToAlertDismissToolStripMenuItem";
            this.switchToAlertDismissToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.switchToAlertDismissToolStripMenuItem.Text = "SwitchToAlertDismiss";
            this.switchToAlertDismissToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // waitForPageLoadToolStripMenuItem
            // 
            this.waitForPageLoadToolStripMenuItem.Name = "waitForPageLoadToolStripMenuItem";
            this.waitForPageLoadToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.waitForPageLoadToolStripMenuItem.Text = "WaitForPageLoad";
            this.waitForPageLoadToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // ttsmAddTestStep
            // 
            this.ttsmAddTestStep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem,
            this.ClickToolStripMenuItem,
            this.SendKeysToolStripMenuItem,
            this.selectToolStripMenuItem,
            this.getTextToolStripMenuItem});
            this.ttsmAddTestStep.Name = "ttsmAddTestStep";
            this.ttsmAddTestStep.Size = new System.Drawing.Size(154, 22);
            this.ttsmAddTestStep.Text = "AddElementStep";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ClearToolStripMenuItem.Text = "Clear";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // ClickToolStripMenuItem
            // 
            this.ClickToolStripMenuItem.Name = "ClickToolStripMenuItem";
            this.ClickToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.ClickToolStripMenuItem.Text = "Click";
            this.ClickToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // SendKeysToolStripMenuItem
            // 
            this.SendKeysToolStripMenuItem.Name = "SendKeysToolStripMenuItem";
            this.SendKeysToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.SendKeysToolStripMenuItem.Text = "SendKeys";
            this.SendKeysToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.selectToolStripMenuItem.Text = "Select";
            this.selectToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // ttsmAddValitation
            // 
            this.ttsmAddValitation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ValidateItemValue,
            this.ValidateItemText,
            this.ValidateBrowserTitle,
            this.validateBrowserUrlToolStripMenuItem,
            this.validateAlertTextToolStripMenuItem,
            this.validateImageToolStripMenuItem,
            this.validateContainTextToolStripMenuItem});
            this.ttsmAddValitation.Name = "ttsmAddValitation";
            this.ttsmAddValitation.Size = new System.Drawing.Size(154, 22);
            this.ttsmAddValitation.Text = "AddValidate";
            // 
            // ValidateItemValue
            // 
            this.ValidateItemValue.Name = "ValidateItemValue";
            this.ValidateItemValue.Size = new System.Drawing.Size(190, 22);
            this.ValidateItemValue.Text = "ValidateItemValue";
            this.ValidateItemValue.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // ValidateItemText
            // 
            this.ValidateItemText.Name = "ValidateItemText";
            this.ValidateItemText.Size = new System.Drawing.Size(190, 22);
            this.ValidateItemText.Text = "ValidateItemText";
            this.ValidateItemText.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // ValidateBrowserTitle
            // 
            this.ValidateBrowserTitle.Name = "ValidateBrowserTitle";
            this.ValidateBrowserTitle.Size = new System.Drawing.Size(190, 22);
            this.ValidateBrowserTitle.Text = "ValidateBrowserTitle";
            this.ValidateBrowserTitle.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // validateBrowserUrlToolStripMenuItem
            // 
            this.validateBrowserUrlToolStripMenuItem.Name = "validateBrowserUrlToolStripMenuItem";
            this.validateBrowserUrlToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateBrowserUrlToolStripMenuItem.Text = "ValidateBrowserUrl";
            this.validateBrowserUrlToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // validateAlertTextToolStripMenuItem
            // 
            this.validateAlertTextToolStripMenuItem.Name = "validateAlertTextToolStripMenuItem";
            this.validateAlertTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateAlertTextToolStripMenuItem.Text = "ValidateAlertText";
            this.validateAlertTextToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // validateImageToolStripMenuItem
            // 
            this.validateImageToolStripMenuItem.Name = "validateImageToolStripMenuItem";
            this.validateImageToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateImageToolStripMenuItem.Text = "ValidateImage";
            this.validateImageToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // validateContainTextToolStripMenuItem
            // 
            this.validateContainTextToolStripMenuItem.Name = "validateContainTextToolStripMenuItem";
            this.validateContainTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateContainTextToolStripMenuItem.Text = "ValidateContainText";
            this.validateContainTextToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // activeElementCheck
            // 
            this.activeElementCheck.Enabled = true;
            this.activeElementCheck.Interval = 250;
            this.activeElementCheck.Tick += new System.EventHandler(this.activeElementCheck_Tick);
            // 
            // fswFavorities
            // 
            this.fswFavorities.EnableRaisingEvents = true;
            this.fswFavorities.SynchronizingObject = this;
            // 
            // InputFromFile
            // 
            this.InputFromFile.FileName = "openFileDialog1";
            // 
            // getTextToolStripMenuItem
            // 
            this.getTextToolStripMenuItem.Name = "getTextToolStripMenuItem";
            this.getTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.getTextToolStripMenuItem.Text = "GetText";
            this.getTextToolStripMenuItem.Click += new System.EventHandler(this.AddElementTestStep_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(959, 661);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "KDATFFSRecorder";
            this.Load += new System.EventHandler(this.KDATFFSRecorder_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TestGrid)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuElement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fswFavorities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void a(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private csExWB.cEXWB cEXWB1;
        private System.Windows.Forms.ToolStripButton tscBack;
        private System.Windows.Forms.ToolStripButton tscForward;
        private System.Windows.Forms.ToolStripButton tscStop;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscUrl;
        private System.Windows.Forms.ToolStripButton tscGoto;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView TestGrid;
        private System.Windows.Forms.TreeView testTreeView;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripTextBox tstTestName;
        private System.Windows.Forms.ToolStripButton tsbRecorder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbFindElement;
        private System.Windows.Forms.ToolStripButton ClosePage;
        private System.Windows.Forms.ToolStripStatusLabel curTest;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.Timer activeElementCheck;
        private System.Windows.Forms.ToolStripDropDownButton tsdOutput;
        private System.Windows.Forms.ToolStripMenuItem excelOutput;
        private System.Windows.Forms.ToolStripMenuItem CsvOutput;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstbSheetName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem InputEcel;
        private System.Windows.Forms.ToolStripMenuItem InputCsv;
        private System.Windows.Forms.ToolStripButton tsbDeleteStep;
        private System.Windows.Forms.ToolStripButton tsbClearTable;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem tssmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmFavorities;
        private System.Windows.Forms.ToolStripMenuItem HelpHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAToolStripMenuItem;
        private System.IO.FileSystemWatcher fswFavorities;
        private System.Windows.Forms.ToolStripMenuItem tsmFavoritiesAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmFavoritiesOrganize;
        private System.Windows.Forms.SaveFileDialog saveToFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuElement;
        private System.Windows.Forms.ToolStripMenuItem ttsmAddTestStep;
        private System.Windows.Forms.ToolStripMenuItem ttsmAddValitation;
        private System.Windows.Forms.ToolStripButton tsbRecordComment;
        private System.Windows.Forms.ToolStripProgressBar tspLoadProgress;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ValidateItemValue;
        private System.Windows.Forms.ToolStripMenuItem ValidateItemText;
        private System.Windows.Forms.ToolStripMenuItem ValidateBrowserTitle;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem ttsmAddBrowserStep;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToAlertAcceptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToAlertDismissToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waitForPageLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateBrowserUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateAlertTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateImageToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog InputFromFile;
        private System.Windows.Forms.ToolStripMenuItem validateContainTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getTextToolStripMenuItem;
    }
}

