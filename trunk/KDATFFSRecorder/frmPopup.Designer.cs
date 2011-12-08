namespace KDATFFSRecorder
{
    partial class frmPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPopup));
            this.cEXWB1 = new csExWB.cEXWB();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerActiveElement = new System.Windows.Forms.Timer(this.components);
            this.frmPopContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tssmAddValidate = new System.Windows.Forms.ToolStripMenuItem();
            this.validateItemValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateBrowserTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateBrowserUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateItemTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateAlertTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateContainTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFindElement = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.frmPopContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.cEXWB1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cEXWB1.Location = new System.Drawing.Point(0, 28);
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
            this.cEXWB1.Size = new System.Drawing.Size(733, 525);
            this.cEXWB1.TabIndex = 0;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.UseInternalDownloadManager = true;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB1.WBKeyUp += new csExWB.WBKeyUpEventHandler(this.cEXWB1_WBKeyUp);
            this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(this.cEXWB1_TitleChange);
            this.cEXWB1.NewWindow2 += new csExWB.NewWindow2EventHandler(this.cEXWB1_NewWindow2);
            this.cEXWB1.WBMouseMove += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBMouseMove);
            this.cEXWB1.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
            this.cEXWB1.WBLButtonUp += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBLButtonUp);
            this.cEXWB1.WBEvaluteNewWindow += new csExWB.EvaluateNewWindowEventHandler(this.cEXWB1_WBEvaluteNewWindow);
            this.cEXWB1.NewWindow3 += new csExWB.NewWindow3EventHandler(this.cEXWB1_NewWindow3);
            this.cEXWB1.NavigateError += new csExWB.NavigateErrorEventHandler(this.cEXWB1_NavigateError);
            this.cEXWB1.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(this.cEXWB1_BeforeNavigate2);
            this.cEXWB1.WBLButtonDown += new csExWB.HTMLMouseEventHandler(this.cEXWB1_WBLButtonDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(29, 17);
            this.tsslStatus.Text = "....";
            // 
            // timerActiveElement
            // 
            this.timerActiveElement.Tick += new System.EventHandler(this.timerActiveElement_Tick);
            // 
            // frmPopContextMenu
            // 
            this.frmPopContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssmAddValidate});
            this.frmPopContextMenu.Name = "frmPopContextMenu";
            this.frmPopContextMenu.Size = new System.Drawing.Size(137, 26);
            // 
            // tssmAddValidate
            // 
            this.tssmAddValidate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateItemValueToolStripMenuItem,
            this.validateImageToolStripMenuItem,
            this.validateBrowserTitleToolStripMenuItem,
            this.validateBrowserUrlToolStripMenuItem,
            this.validateItemTextToolStripMenuItem,
            this.validateAlertTextToolStripMenuItem,
            this.validateContainTextToolStripMenuItem});
            this.tssmAddValidate.Name = "tssmAddValidate";
            this.tssmAddValidate.Size = new System.Drawing.Size(136, 22);
            this.tssmAddValidate.Text = "AddValidate";
            // 
            // validateItemValueToolStripMenuItem
            // 
            this.validateItemValueToolStripMenuItem.Name = "validateItemValueToolStripMenuItem";
            this.validateItemValueToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateItemValueToolStripMenuItem.Text = "ValidateItemValue";
            // 
            // validateImageToolStripMenuItem
            // 
            this.validateImageToolStripMenuItem.Name = "validateImageToolStripMenuItem";
            this.validateImageToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateImageToolStripMenuItem.Text = "ValidateImage";
            // 
            // validateBrowserTitleToolStripMenuItem
            // 
            this.validateBrowserTitleToolStripMenuItem.Name = "validateBrowserTitleToolStripMenuItem";
            this.validateBrowserTitleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateBrowserTitleToolStripMenuItem.Text = "ValidateBrowserTitle";
            // 
            // validateBrowserUrlToolStripMenuItem
            // 
            this.validateBrowserUrlToolStripMenuItem.Name = "validateBrowserUrlToolStripMenuItem";
            this.validateBrowserUrlToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateBrowserUrlToolStripMenuItem.Text = "ValidateBrowserUrl";
            // 
            // validateItemTextToolStripMenuItem
            // 
            this.validateItemTextToolStripMenuItem.Name = "validateItemTextToolStripMenuItem";
            this.validateItemTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateItemTextToolStripMenuItem.Text = "ValidateItemText";
            // 
            // validateAlertTextToolStripMenuItem
            // 
            this.validateAlertTextToolStripMenuItem.Name = "validateAlertTextToolStripMenuItem";
            this.validateAlertTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateAlertTextToolStripMenuItem.Text = "ValidateAlertText";
            // 
            // validateContainTextToolStripMenuItem
            // 
            this.validateContainTextToolStripMenuItem.Name = "validateContainTextToolStripMenuItem";
            this.validateContainTextToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.validateContainTextToolStripMenuItem.Text = "ValidateContainText";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFindElement});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(735, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbFindElement
            // 
            this.tsbFindElement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFindElement.Image = ((System.Drawing.Image)(resources.GetObject("tsbFindElement.Image")));
            this.tsbFindElement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindElement.Name = "tsbFindElement";
            this.tsbFindElement.Size = new System.Drawing.Size(23, 22);
            this.tsbFindElement.Text = "toolStripButton1";
            this.tsbFindElement.CheckedChanged += new System.EventHandler(this.toolStripButton1_CheckedChanged);
            this.tsbFindElement.Click += new System.EventHandler(this.tsbFindElement_Click);
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 576);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cEXWB1);
            this.Name = "frmPopup";
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.VisibleChanged += new System.EventHandler(this.frmPopup_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPopup_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.frmPopContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private csExWB.cEXWB cEXWB1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.Timer timerActiveElement;
        private System.Windows.Forms.ContextMenuStrip frmPopContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tssmAddValidate;
        private System.Windows.Forms.ToolStripMenuItem validateItemValueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateBrowserTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateBrowserUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateItemTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validateAlertTextToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFindElement;
        private System.Windows.Forms.ToolStripMenuItem validateContainTextToolStripMenuItem;
    }
}