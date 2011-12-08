using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDATFFSRecorder.Properties;
using KDATFFS;
using KDATFFSRecorder.Core;
using System.Threading;
using Microsoft.Win32;
using IfacesEnumsStructsClasses;
using System.Timers;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using KDATFFS.Provider;


namespace KDATFFSRecorder
{
    public partial class frmPopup : Form
    {

        private frmMain MainForm;
        private frmPopup newForm;
        private bool IsSecondaryPopup;
        private IHTMLElement activeElement;
        private string sendKeysValue;
        private DateTime lastKeyTime;
        private int times;
        private int keyInterval = 1000;
        public csExWB.cEXWB curWB;
        private bool highLightElement;
        private string OriginalColor = "white";
        private IHTMLElement lastelement;
        public Color DOMHighlightColor = Color.Blue;
        public int xMouse;
        public int yMouse;
        public bool isSearching=false;

        public frmPopup()
        {
            InitializeComponent();
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            curWB = this.cEXWB1;

        }

        public IHTMLElement ActiveElement
        {
            get { return activeElement; }
        }

        public void AssignBrowserObject(ref object obj)
        {
            obj = cEXWB1.WebbrowserObject;
        }

        public void SetUrl(frmMain frm, string url)
        {
            MainForm = frm;
            cEXWB1.Navigate(url);
            this.validateBrowserTitleToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateBrowserUrlToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateItemTextToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateItemValueToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateImageToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateAlertTextToolStripMenuItem.Click += new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateContainTextToolStripMenuItem.Click += new EventHandler(MainForm.AddTestStepFormFrmpop);
 
        }


        public IHTMLElement GetActiveElement()
        {
            IHTMLElement element = null;
            element = cEXWB1.GetActiveElement();
            return element;
        }

        public void SetupAsSandBox()
        {
            cEXWB1.WBDOCDOWNLOADCTLFLAG = (int)(
                DOCDOWNLOADCTLFLAG.NO_SCRIPTS |
                DOCDOWNLOADCTLFLAG.NO_JAVA |
                DOCDOWNLOADCTLFLAG.NOFRAMES |
                DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS |
                DOCDOWNLOADCTLFLAG.NO_RUNACTIVEXCTLS |
                DOCDOWNLOADCTLFLAG.PRAGMA_NO_CACHE |
                DOCDOWNLOADCTLFLAG.SILENT |
                DOCDOWNLOADCTLFLAG.NO_BEHAVIORS |
                DOCDOWNLOADCTLFLAG.NO_CLIENTPULL);
        }

        /// <summary>
        /// status display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cEXWB1_StatusTextChange(object sender, csExWB.StatusTextChangeEventArgs e)
        {
            tsslStatus.Text = e.text;
        }

        private void cEXWB1_BeforeNavigate2(object sender, csExWB.BeforeNavigate2EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cEXWB1_NavigateError(object sender, csExWB.NavigateErrorEventArgs e)
        {
            e.Cancel = true;
        }



        private void cEXWB1_NewWindow2(object sender, csExWB.NewWindow2EventArgs e)
        {
            var pWB = (csExWB.cEXWB)sender;
            if ((pWB != null) && (!pWB.RegisterAsBrowser))
            {
                pWB.RegisterAsBrowser = true;
            }
            newForm.AssignBrowserObject(ref e.browser);
        }



        private void cEXWB1_NewWindow3(object sender, csExWB.NewWindow3EventArgs e)
        {
            var pWB = (csExWB.cEXWB)sender;
            if ((pWB != null) && (!pWB.RegisterAsBrowser))
            {
                pWB.RegisterAsBrowser = true;
            }
            newForm.AssignBrowserObject(ref e.browser);

        }

        private void cEXWB1_WBEvaluteNewWindow(object sender, csExWB.EvaluateNewWindowEventArgs e)
        {
            newForm = new frmPopup { IsSecondaryPopup = true };
            newForm.Show();
            newForm.SetUrl(MainForm, e.url);
            newForm.BringToFront();
        }

        private void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            Text = e.title;
        }

        private void frmPopup_FormClosing(object sender, FormClosingEventArgs e)
        { 
            MainForm.AddBrowserTestStep(BrowserCommandTypes.Close, "", this.Text);
            this.validateBrowserTitleToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateBrowserUrlToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateItemTextToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateItemValueToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateImageToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateAlertTextToolStripMenuItem.Click -= new System.EventHandler(MainForm.AddTestStepFormFrmpop);
            this.validateContainTextToolStripMenuItem.Click -= new EventHandler(MainForm.AddTestStepFormFrmpop);
            this.tsbFindElement.Checked = false;
            this.isSearching = false;
            if ((e.CloseReason == CloseReason.UserClosing) && (!IsSecondaryPopup))
            {
                e.Cancel = true;
                this.Hide();

            }
           
        }

        private void cEXWB1_WBKeyUp(object sender, csExWB.WBKeyUpEventArgs e)
        {
            activeElement = cEXWB1.GetActiveElement();
          
            if (MainForm.selectTest != null && MainForm.isRecording == true)
            {
                if (activeElement is mshtml.HTMLInputElementClass)
                {
                    sendKeysValue = ((mshtml.HTMLInputElementClass)activeElement).value;
                    lastKeyTime = DateTime.Now;
                    times++;
                }
            }
        }

        private void timerActiveElement_Tick(object sender, EventArgs e)
        {

                if (lastKeyTime < DateTime.Now.AddMilliseconds(-1 * keyInterval) && times > 0)
                {
                    if (activeElement != null)
                    {
                        MainForm.AddElementTestStep(activeElement, ElementCommandTypes.Clear, "", this.Text);
                        MainForm.AddElementTestStep(activeElement, ElementCommandTypes.SendKeys, sendKeysValue, this.Text);
                        times = 0;
                    }
                }
          

        }

        private void frmPopup_VisibleChanged(object sender, EventArgs e)
        {
            timerActiveElement.Enabled = true;
        }

        private void toolStripButton1_CheckedChanged(object sender, EventArgs e)
        {
            highLightElement = tsbFindElement.Checked;

        }


        private void HighlightElement(IHTMLElement element)
        {
            if (lastelement != null)
            {

                    lastelement.style.setAttribute("backgroundColor", OriginalColor, 0);
            }

            if (element == null)
            {
                return;
            }

            lastelement = element;
            Object objColor = lastelement.style.getAttribute("backgroundColor", 0);
            OriginalColor = objColor != null ? objColor.ToString() : "";
            lastelement.style.setAttribute("backgroundColor", DOMHighlightColor.ToKnownColor(), 0);

        }

        private void cEXWB1_WBLButtonDown(object sender, csExWB.HTMLMouseEventArgs e)
        {
            if (tsbFindElement.Checked)
            {
                cEXWB1.Cursor = Cursors.Cross;
                e.Handled = true;
                activeElement = e.SrcElement;
            }
        }

        private void cEXWB1_WBLButtonUp(object sender, csExWB.HTMLMouseEventArgs e)
        {

            if (tsbFindElement.Checked)
            {

                frmPopContextMenu.Show(cEXWB1.PointToScreen(e.ClientPoint));
                cEXWB1.Cursor = Cursors.Cross;
                e.Handled = true;
            }
            else
            {
                xMouse = e.ClientX;
                yMouse = e.ClientY;
            }
        }

        private void cEXWB1_WBMouseMove(object sender, csExWB.HTMLMouseEventArgs e)
        {
            if (tsbFindElement.Checked)
            {
                cEXWB1.Cursor = Cursors.Cross;
                if (e.SrcElement != null)
                {
                    HighlightElement(e.SrcElement);
                }
            }
        }

        private void tsbFindElement_Click(object sender, EventArgs e)
        {
            if (isSearching == false)
            {
                tsbFindElement.CheckState = CheckState.Checked;
                isSearching = true;

            }
            else
            {
                tsbFindElement.CheckState = CheckState.Unchecked;
                isSearching = false;
            }
        }



    }
}
