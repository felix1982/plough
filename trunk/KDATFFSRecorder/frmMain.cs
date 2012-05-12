using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using  IfacesEnumsStructsClasses;
using System.Timers;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;
using KDATFFS.Provider;

namespace KDATFFSRecorder
{
    public partial class frmMain : Form
    {

        public bool isRecording = false;
        private bool isSearching = false;
        private bool isRecordComment = false;
        private Dictionary<string, Test> tests = new Dictionary<string, Test>();
        public Test selectTest;
        private string sendKeysValue;
        TestRecorder testRecorder = new TestRecorder();
        private IHTMLElement activeElement;
        private DateTime lastKeyTime = DateTime.MinValue;
        private readonly Microsoft.Win32.MouseHook hook = new Microsoft.Win32.MouseHook();
        int times;
        private frmPopup m_frmPopup = new frmPopup();
        public csExWB.cEXWB curWB;
        private string currentUrl;
        private string currentWindowText;
        private string currentPopWindowText;
        private string currentFrameName="";
        private string elementXpath;
        public bool highLightElement;
        private string OriginalColor = "white";
        private IHTMLElement lastelement;
        public Color DOMHighlightColor = Color.Blue;
        public int xMouse;
        public int yMouse;
        private double keyInterval = 1000;
        private ExcelDataProvider edp = new ExcelDataProvider();
        private CsvDataProvider cdp = new CsvDataProvider();

        public frmMain()
        {
            InitializeComponent();
        }

        public IHTMLElement ActiveElement
        {
            get { return activeElement; }
        }


        /// <summary>
        /// frmMain load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KDATFFSRecorder_Load(object sender, EventArgs e)
        {
            hook.Install();
            hook.MouseUp += new MouseHookEventHandler(hook_MouseUp);

            cEXWB1.RegisterAsBrowser = true;

            curWB = this.cEXWB1;

            //get the path of  favority folder
            fswFavorities.Path = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

            LoadFavoritiesMenuItems();

        }





        #region Control Handle

        /// <summary>
        /// whether begin to record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRecorder_Click(object sender, EventArgs e)
        {
            if (isRecording == false)
            {
                isRecording = true;
                tsbRecorder.Image = Resources.record;
                tsbRecorder.CheckState = CheckState.Checked;
            }
            else
            {
                isRecording = false;
                tsbRecorder.Image = Resources.norecord;
                tsbRecorder.CheckState = CheckState.Unchecked;
            }

        }


        /// <summary>
        /// Is finding element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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



        /// <summary>
        /// add test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (tstTestName.Text != "" && !tests.ContainsKey(tstTestName.Text))
            {
                TreeNode newNode = new TreeNode(tstTestName.Text);
                testTreeView.Nodes.Add(newNode);
                Test newTest = new Test();
                newTest.TestId = tstTestName.Text;
                newTest.TestTable = testRecorder.createTable(tstTestName.Text);
                tests.Add(tstTestName.Text, newTest);
            }
        }


        /// <summary>
        /// delete test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (testTreeView.SelectedNode != null)
            {
                tests.Remove(testTreeView.SelectedNode.Text);
                testTreeView.SelectedNode.Remove();

            }
        }

        private void testTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectTest = tests[e.Node.Text];
            TestGrid.DataSource = selectTest.TestTable;
            curTest.Text = selectTest.TestId;
        }



        /// <summary>
        /// export excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void excelOutput_Click(object sender, EventArgs e)
        {
            saveToFile.Filter = "Excel2003|*.xls|Excel2007|*.xlsx";
            if (tstbSheetName.Text == "")
            {
                MessageBox.Show("please input Sheet Name");
            }
            else
            {
                if (saveToFile.ShowDialog() == DialogResult.OK)
                {

                    edp.DataTabletoExcel(GetSelectedTable(), saveToFile.FileName, tstbSheetName.Text);

                }
            }
        }

        /// <summary>
        /// clear test step
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbClearTable_Click(object sender, EventArgs e)
        {
            if (selectTest != null)
            {
                selectTest.TestTable.Clear();
                selectTest.TestSteps.Clear();
                TestGrid.Refresh();
            }
        }

        /// <summary>
        /// export csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CsvOutput_Click(object sender, EventArgs e)
        {
            saveToFile.Filter = "Csv File|*.Csv";
            if (saveToFile.ShowDialog() == DialogResult.OK)
            {


                cdp.DatatableToCsv(GetSelectedTable(), saveToFile.FileName, true);
            }
        }


        private DataTable GetSelectedTable()
        {
            Collection<Test> selectTests = new Collection<Test>();

            foreach (TreeNode node in testTreeView.Nodes)
            {
                selectTests.Add(tests[node.Text]);
            }
            DataTable executeTable = new DataTable();
            if (tests.Count != 0)
            {
                executeTable = selectTests[0].TestTable.Clone();
                object[] objarray = new object[executeTable.Columns.Count];
                for (int i = 0; i < selectTests.Count; i++)
                {
                    for (int j = 0; j < selectTests[i].TestTable.Rows.Count; j++)
                    {
                        selectTests[i].TestTable.Rows[j].ItemArray.CopyTo(objarray, 0);
                        executeTable.Rows.Add(objarray);
                    }
                }
            }
            return executeTable;
        }



        private void tsbDeleteStep_Click(object sender, EventArgs e)
        {
            if (selectTest != null)
            {
                List<string> stepName = new List<string>();
                foreach (DataGridViewRow row in TestGrid.SelectedRows)
                {
                    stepName.Add(row.Cells[1].Value.ToString());

                }
                foreach (string name in stepName)
                {
                    if (name != "")
                    {
                        if ((selectTest.TestTable.Select("TestStep = '" + name + "'")).Length != 0)
                        {
                            (selectTest.TestTable.Select("TestStep = '" + name + "'"))[0].Delete();
                            selectTest.TestSteps.Remove(name);
                        }
                    }
                }

                TestGrid.Refresh();

            }

        }

        /// <summary>
        /// Is  record comment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRecordComment_Click(object sender, EventArgs e)
        {
            if (isRecordComment == false)
            {
                isRecordComment = true;
                tsbRecordComment.CheckState = CheckState.Checked;
            }
            else
            {
                isRecordComment = false;
                tsbRecordComment.CheckState = CheckState.Unchecked;
            }

        }


        /// <summary>
        /// import excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputEcel_Click(object sender, EventArgs e)
        {

            if (tstbSheetName.Text == "")
            {
                MessageBox.Show("please input Sheet Name");
            }
            else
            {
                InputFromFile.Filter = "Excel2003|*.xls|Excel2007|*.xlsx";
                if (InputFromFile.ShowDialog() == DialogResult.OK)
                {

                    string path = InputFromFile.FileName;
                    Dictionary<string, TestSheet> testsheets = edp.ParseData(path);
                    TestSheet testSheet = new TestSheet();
                    string testSheetName1 = tstbSheetName.Text + "$";
                    string testSheetName2 = "'" + tstbSheetName.Text + "$'";
                    if (testsheets.Keys.Contains(testSheetName1))
                    {
                        testSheet = testsheets[testSheetName1];
                        InitTreeView(testSheet);
                    }
                    else if (testsheets.Keys.Contains(testSheetName2))
                    {
                        testSheet = testsheets[testSheetName2];
                        InitTreeView(testSheet);
                    }
                }


            }
        }

        /// <summary>
        /// import csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputCsv_Click(object sender, EventArgs e)
        {
            if (tstbSheetName.Text == "")
            {
                MessageBox.Show("please input Sheet Name");
            }
            else
            {
                InputFromFile.Filter = "CSV File|*.csv";
                if (InputFromFile.ShowDialog() == DialogResult.OK)
                {

                    string path = InputFromFile.FileName;
                    Dictionary<string, TestSheet> testsheets = cdp.ParseData(path);
                    TestSheet testSheet = new TestSheet();
                    string testSheetName = tstbSheetName.Text;
                    if (testsheets.Keys.Contains(testSheetName))
                    {
                        testSheet = testsheets[testSheetName];
                        InitTreeView(testSheet);
                    }

                }


            }
        }

        /// <summary>
        /// initialize test's treeview
        /// </summary>
        /// <param name="ts"></param>
        private void InitTreeView(TestSheet ts)
        {
            foreach (string key in ts.Tests.Keys)
            {
                TreeNode node = new TreeNode();
                node.Text = key;
                testTreeView.Nodes.Add(node);
                testTreeView.Refresh();
                tests.Add(key, ts.Tests[key]);
            }
        }

        private void tssmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion


        #region  Add Commands


        /// <summary>
        /// get max number of the test's teststepid
        /// </summary>
        /// <returns></returns>
        public int GetTestStepIdMax()
        {

            int minAccountLevel = int.MaxValue;
            int maxAccountLevel = 0;
            foreach (DataRow dr in selectTest.TestTable.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {

                    int accountLevel = Convert.ToInt32(dr[1].ToString());
                    minAccountLevel = Math.Min(minAccountLevel, accountLevel);
                    maxAccountLevel = Math.Max(maxAccountLevel, accountLevel);
                }
            }
            return maxAccountLevel;
        }

        /// <summary>
        /// get the  xpath of element
        /// </summary>
        /// <param name="element">element</param>
        /// <returns>xpath</returns>
        public string GetXpathOfElement(IHTMLElement element)
        {
            if (element.parentElement != null && element.tagName != "HTML")
            {
                IHTMLElement pElement = element.parentElement;
                int i = 1;
                foreach (IHTMLElement cElement in (IHTMLElementCollection)pElement.children)
                {
                    if (cElement.tagName == element.tagName)
                    {
                        if (cElement.Equals(element))
                        {
                            elementXpath = string.Format("/{0}[{1}]", cElement.tagName, i.ToString()) + elementXpath;
                        }
                        i++;
                    }
                }
                GetXpathOfElement(pElement);
            }
            return "HTML" + elementXpath;

        }

        /// <summary>
        /// add a step of browser type
        /// </summary>
        /// <param name="browserCommand"></param>
        /// <param name="commandArgs"></param>
        /// <param name="currentpopwindowwext"></param>
        public void AddBrowserTestStep(BrowserCommandTypes browserCommand, string commandArgs, string currentpopwindowwext)
        {
            TestStep testStep = new TestStep();
            testStep.TestId = selectTest.TestId;
            testStep.TestStepId = (GetTestStepIdMax() + 1).ToString();
            testStep.CommandType = CommandTypes.Browser;
            testStep.BrowserCommand = browserCommand;
            testStep.CommandArgs = commandArgs;
            testStep.FrameName = currentFrameName;
            testStep.WindowName = currentpopwindowwext;
            if (isRecordComment == true)
            {
                switch (browserCommand)
                {
                    case BrowserCommandTypes.Goto:
                        testStep.Comment = string.Format(Resources.GotoComment, "");
                        break;
                    case BrowserCommandTypes.Close:
                        testStep.Comment = string.Format(Resources.CloseComment, currentPopWindowText);
                        break;
                    case BrowserCommandTypes.Back:
                        testStep.Comment = string.Format(Resources.BackComment, currentWindowText);
                        break;
                    case BrowserCommandTypes.Forward:
                        testStep.Comment = string.Format(Resources.ForwardComment, currentWindowText);
                        break;
                    case BrowserCommandTypes.Refresh:
                        testStep.Comment = string.Format(Resources.RefreshComment, currentWindowText);
                        break;
                }
            }
            currentFrameName = "";
            testRecorder.updateTable(selectTest, testStep);
            TestGrid.Refresh();
        }

        /// <summary>
        /// add a step of element type
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementComandType"></param>
        /// <param name="commandArgs"></param>
        /// <param name="windowName"></param>
        public void AddElementTestStep(IHTMLElement element, ElementCommandTypes elementComandType, string commandArgs, string windowName)
        {
            try
            {
                element.getAttribute("id", 0);
            }
            catch
            {
                element = null;
            }


            TestStep testStep = new TestStep();
            testStep.TestId = selectTest.TestId;
            testStep.TestStepId = (GetTestStepIdMax() + 1).ToString();
            testStep.CommandType = CommandTypes.Element;
            testStep.ElementCommand = elementComandType;
            testStep.CommandArgs = commandArgs;
            testStep.FrameName = currentFrameName;
            testStep.WindowName = windowName;
            if (element.getAttribute("id", 0) != null && element.getAttribute("id", 0).ToString() != "")
            {
                testStep.FindMethodType = FindMethodTypes.Id;
                testStep.FindArgs = element.id;
            }
            else if (element.getAttribute("name", 0) != null && element.getAttribute("name", 0).ToString() != "")
            {
                testStep.FindMethodType = FindMethodTypes.Name;
                testStep.FindArgs = element.getAttribute("name", 0).ToString();
            }
            else if (element.tagName == "A")
            {
                testStep.FindMethodType = FindMethodTypes.LinkText;
                testStep.FindArgs = element.innerText;
            }
            else
            {
                testStep.FindMethodType = FindMethodTypes.Xpath;
                testStep.FindArgs = GetXpathOfElement(element);
            }
            string pageTitle;
            if (windowName == null || windowName == "")
            {
                pageTitle = currentWindowText;
            }
            else
            {
                pageTitle = currentPopWindowText;

            }
            if (isRecordComment == true)
            {
                switch (elementComandType)
                {
                    case ElementCommandTypes.Clear:
                        testStep.Comment = string.Format(Resources.ClearComment, pageTitle, testStep.FindArgs);
                        break;
                    case ElementCommandTypes.Click:
                        testStep.Comment = string.Format(Resources.ClickComment, pageTitle, testStep.FindArgs);
                        break;
                    case ElementCommandTypes.Select:
                        testStep.Comment = string.Format(Resources.SelectComment, pageTitle, testStep.FindArgs, testStep.CommandArgs);
                        break;
                    case ElementCommandTypes.SendKeys:
                        testStep.Comment = string.Format(Resources.SendKeysComment, pageTitle, testStep.FindArgs, testStep.CommandArgs);
                        break;
                }
            }
            currentFrameName = "";
            elementXpath = "";
            testRecorder.updateTable(selectTest, testStep);
            TestGrid.Refresh();
        }


        /// <summary>
        /// add a step of validate type
        /// </summary>
        /// <param name="element"></param>
        /// <param name="validateCommandType"></param>
        /// <param name="expectedValue"></param>
        public void AddValidateTestStep(IHTMLElement element, ValidateCommandTypes validateCommandType, string expectedValue)
        {

            try
            {
                element.getAttribute("id", 0);
            }
            catch
            {
                element = null;
            }


            TestStep testStep = new TestStep();
            testStep.TestId = selectTest.TestId;
            testStep.TestStepId = (GetTestStepIdMax() + 1).ToString();
            testStep.CommandType = CommandTypes.Validate;
            testStep.ValidateCommand = validateCommandType;
            testStep.CommandArgs = "";
            testStep.FrameName = currentFrameName;
            testStep.WindowName = currentPopWindowText;
            testStep.ExpectedValue = expectedValue;
            if (validateCommandType == ValidateCommandTypes.ValidateItemText || validateCommandType == ValidateCommandTypes.ValidateItemValue)
            {
                if (element.getAttribute("id", 0) != null && element.getAttribute("id", 0).ToString() != "")
                {
                    testStep.FindMethodType = FindMethodTypes.Id;
                    testStep.FindArgs = element.id;
                }
                else if (element.getAttribute("name", 0) != null && element.getAttribute("name", 0).ToString() != "")
                {
                    testStep.FindMethodType = FindMethodTypes.Name;
                    testStep.FindArgs = element.getAttribute("name", 0).ToString();
                }
                else if (element.tagName == "A")
                {
                    testStep.FindMethodType = FindMethodTypes.LinkText;
                    testStep.FindArgs = element.innerText;
                }
                else
                {
                    testStep.FindMethodType = FindMethodTypes.Xpath;
                    testStep.FindArgs = GetXpathOfElement(element);
                }
            }

            if (isRecordComment == true)
            {
                switch (validateCommandType)
                {
                    case ValidateCommandTypes.ValidateAlertText:
                        testStep.Comment = string.Format(Resources.ValidateAlertText);
                        break;
                    case ValidateCommandTypes.ValidateBrowserTitle:
                        testStep.Comment = string.Format(Resources.ValidateBrowserTitle);
                        break;
                    case ValidateCommandTypes.ValidateBrowserUrl:
                        testStep.Comment = string.Format(Resources.ValidateBrowserUrl);
                        break;
                    case ValidateCommandTypes.ValidateImage:
                        testStep.Comment = string.Format(Resources.ValidateImage);
                        break;
                    case ValidateCommandTypes.ValidateItemText:
                        testStep.Comment = string.Format(Resources.ValidateItemText);
                        break;
                    case ValidateCommandTypes.ValidateItemValue:
                        testStep.Comment = string.Format(Resources.ValidateItemValue);
                        break;
                }
            }

            currentFrameName = "";
            testRecorder.updateTable(selectTest, testStep);
            TestGrid.Refresh();

        }



        /// <summary>
        /// monitor mouse's action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void hook_MouseUp(object sender, MouseHookEventArgs e)
        {
            if (selectTest != null && isRecording == true && this.isSearching == false && m_frmPopup.isSearching == false)
            {
                if (cEXWB1.GetActiveDocument() == null)
                {
                    return;
                }


                if (e.Control != null && e.Control.Name == "cEXWB1" && e.Button != MouseButtons.Right)
                {
                    IHTMLElement curActiveElement = null;
                    curActiveElement = cEXWB1.GetActiveElement();



                    if (curActiveElement != activeElement)
                    {
                        activeElement = curActiveElement;
                    }



                    if (activeElement.tagName.ToLower(CultureInfo.InvariantCulture) == "body")
                    {
                        Point clientPoint = cEXWB1.PointToClient(new Point(e.X, e.Y));
                        activeElement = cEXWB1.ElementFromPoint(true, clientPoint.X, clientPoint.Y);

                    }
                    else
                    {
                        Point clientPoint = cEXWB1.PointToClient(new Point(e.X, e.Y));
                        IHTMLElement eItem = cEXWB1.ElementFromPoint(true, clientPoint.X, clientPoint.Y);
                        if (eItem != activeElement && eItem.GetType() != typeof(mshtml.HTMLFrameElementClass) && eItem.GetType() != typeof(mshtml.HTMLIFrameClass))
                        {

                            activeElement = eItem;
                        }
                        else if (eItem.GetType() == typeof(mshtml.HTMLFrameElementClass) || eItem.GetType() == typeof(mshtml.HTMLIFrameClass))
                        {

                            if (eItem.getAttribute("name", 0) != null)
                            {
                                currentFrameName = eItem.getAttribute("name", 0).ToString();
                            }
                        }
                        // when mouse move to popup windows ,mouse up will get active element.
                        if (e.Control.Parent.Name == "frmPopup")
                        {
                            currentPopWindowText = e.Control.Parent.Text;
                            activeElement = m_frmPopup.GetActiveElement();
                        }
                        else
                        {
                            currentWindowText = this.curWB.DocumentTitle;
                            currentPopWindowText = "";

                        }

                        // handle select element
                        if (activeElement.GetType().ToString() == "mshtml.HTMLSelectElementClass")
                        {

                            ((mshtml.HTMLSelectElementClass)activeElement).HTMLSelectElementEvents2_Event_onchange += new mshtml.HTMLSelectElementEvents2_onchangeEventHandler(KDATFFSRecorder_HTMLSelectElementEvents2_Event_onchange);

                        }
                        else
                        {

                            AddElementTestStep(activeElement, ElementCommandTypes.Click, "", currentPopWindowText);

                        }
                    }
                }

            }
        }




        /// <summary>
        /// handle method when  HtmlSelectElement changed
        /// </summary>
        /// <param name="pEvtObj"></param>

        void KDATFFSRecorder_HTMLSelectElementEvents2_Event_onchange(mshtml.IHTMLEventObj pEvtObj)
        {
            string selectText = "";
            activeElement = pEvtObj.srcElement as IHTMLElement;
            var selectedElement = activeElement as IHTMLSelectElement;
            if (selectedElement == null) return;
            var optionElements = selectedElement.options as mshtml.HTMLSelectElementClass;
            if (optionElements == null) return;
            foreach (IHTMLOptionElement option in optionElements)
            {
                if (option.selected)
                {
                    selectText = option.text;
                    option.selected = false;
                    break;
                }
            }

            AddElementTestStep(activeElement, ElementCommandTypes.Select, selectText, currentPopWindowText);
            ((mshtml.HTMLSelectElementClass)activeElement).HTMLSelectElementEvents2_Event_onchange -= new mshtml.HTMLSelectElementEvents2_onchangeEventHandler(KDATFFSRecorder_HTMLSelectElementEvents2_Event_onchange);
        }

        /// <summary>
        /// add sendKeys action when keyup in a period of time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void activeElementCheck_Tick(object sender, EventArgs e)
        {
            try
            {
                if (lastKeyTime < DateTime.Now.AddMilliseconds(-1 * keyInterval) && times > 0)
                {
                    if (activeElement != null)
                    {
                        AddElementTestStep(activeElement, ElementCommandTypes.Clear, "", currentPopWindowText);
                        AddElementTestStep(activeElement, ElementCommandTypes.SendKeys, sendKeysValue, currentPopWindowText);
                        times = 0;
                    }
                }
            }
            catch
            {
                activeElement = null;
                times = 0;

            }
        }


        #endregion


        #region Browser's operation




        /// <summary>
        /// Browser's Goto operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscGoto_Click(object sender, EventArgs e)
        {
            if (tscUrl.Text != "")
            {
                this.Goto(tscUrl.Text);
            }

        }

        public void Goto(string url)
        {

            if (curWB != null)
            {
                currentUrl = url;
                curWB.Navigate(url);
                if (selectTest != null && isRecording == true)
                {
                    AddBrowserTestStep(BrowserCommandTypes.Goto, currentUrl, currentPopWindowText);

                }
            }
        }




        /// <summary>
        /// Browser's Close operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClosePage_Click(object sender, EventArgs e)
        {
            if (isRecording == true)
            {
                AddBrowserTestStep(BrowserCommandTypes.Close, "", currentPopWindowText);
            }
            curWB.Clear();
            currentPopWindowText = "";
            currentWindowText = "";

        }




        /// <summary>
        /// Browser's Back operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscBack_Click(object sender, EventArgs e)
        {
            if (curWB.CanGoBack)
            {
                if (isRecording == true)
                {
                    AddBrowserTestStep(BrowserCommandTypes.Back, "", currentPopWindowText);
                }
                curWB.GoBack();
            }
        }


        /// <summary>
        /// Browser's Forward operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscForward_Click(object sender, EventArgs e)
        {
            if (curWB.CanGoForward)
            {
                if (isRecording == true)
                {
                    AddBrowserTestStep(BrowserCommandTypes.Forward, "", currentPopWindowText);
                }
                curWB.GoForward();
            }

        }

        /// <summary>
        /// Browser's Stop operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscStop_Click(object sender, EventArgs e)
        {
            curWB.Stop();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            if (isRecording == true)
            {
                AddBrowserTestStep(BrowserCommandTypes.Refresh, "", currentPopWindowText);
            }
            curWB.Refresh();
        }
        #endregion


        # region csEXWB Handle


        /// <summary>
        /// open new popup window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cEXWB1_WBEvaluteNewWindow(object sender, csExWB.EvaluateNewWindowEventArgs e)
        {
            if ((e.flags & NWMF.HTMLDIALOG) == NWMF.HTMLDIALOG)
            {
                if (MessageBox.Show(Properties.Resources.showDialogBug, Properties.Resources.KnownBug, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                m_frmPopup.Show();
                m_frmPopup.SetUrl(this, e.url);
            }
        }

        private void cEXWB1_NewWindow2(object sender, csExWB.NewWindow2EventArgs e)
        {
            if (!m_frmPopup.Visible)
            {
                m_frmPopup.Show(this);
            }

            //var pWB = (csExWB.cEXWB)sender;
            //if ((pWB != null) && (!pWB.RegisterAsBrowser))
            //{
            //    pWB.RegisterAsBrowser = true;
            //}

            m_frmPopup.AssignBrowserObject(ref e.browser);
        }

        private void cEXWB1_NewWindow3(object sender, csExWB.NewWindow3EventArgs e)
        {
            if (!m_frmPopup.Visible)
            {
                m_frmPopup.Show(this);
            }

            m_frmPopup.AssignBrowserObject(ref e.browser);
        }



        /// <summary>
        /// keyup handle method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cEXWB1_WBKeyUp(object sender, csExWB.WBKeyUpEventArgs e)
        {

            if (selectTest != null && isRecording == true)
            {
                if (activeElement is mshtml.HTMLInputElementClass)
                {
                    sendKeysValue = ((mshtml.HTMLInputElementClass)activeElement).value;
                    lastKeyTime = DateTime.Now;
                    times++;
                }
            }


        }


        /// <summary>
        /// handle method when document completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cEXWB1_DocumentComplete(object sender, csExWB.DocumentCompleteEventArgs e)
        {
            if (e.istoplevel)
            {
                var pWB = (csExWB.cEXWB)sender;
                if (sender == curWB)
                {
                    pWB.SetFocus();
                    this.tscUrl.Text = pWB.LocationUrl;
                }

            }
        }


        private void tscUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                Goto(tscUrl.Text);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.Handled = true;
                tscUrl.Text = Clipboard.GetText();
                cEXWB1.Focus();
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                Clipboard.SetText(tscUrl.Text);
            }
        }


        private void cEXWB1_WindowClosing(object sender, csExWB.WindowClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void cEXWB1_WBDocHostShowUIShowMessage(object sender, csExWB.DocHostShowUIShowMessageEventArgs e)
        {
            e.handled = true;

            if (e.type == 48)
            {
                e.result = (int)MessageBox.Show(e.text, e.caption);
                AddBrowserTestStep(BrowserCommandTypes.SwitchToAlertAccept, "", currentPopWindowText);
            }

            if (e.type == 33)
            {
                DialogResult result = MessageBox.Show(e.text, e.caption, MessageBoxButtons.OKCancel);
                e.result = Convert.ToInt32(result);
                if (result == DialogResult.OK)
                {

                    AddBrowserTestStep(BrowserCommandTypes.SwitchToAlertAccept, "", currentPopWindowText);
                }
                else
                {
                    AddBrowserTestStep(BrowserCommandTypes.SwitchToAlertDismiss, "", currentPopWindowText);
                }
            }

        }

        private void cEXWB1_ProgressChange(object sender, csExWB.ProgressChangeEventArgs e)
        {
            if (sender != curWB)
            { return; }

            if ((e.progress == -1) || (e.progressmax == e.progress))
            {
                tspLoadProgress.Value = 0;
                tspLoadProgress.Maximum = 0;
                return;
            }
            if ((e.progressmax > 0) && (e.progress > 0) && (e.progress < e.progressmax))
            {
                tspLoadProgress.Maximum = e.progressmax;
                tspLoadProgress.Value = e.progress;
            }

        }

        private void cEXWB1_DownloadBegin(object sender)
        {
            if (sender != curWB)
            { return; }
            tspLoadProgress.Visible = true;
        }

        private void cEXWB1_DownloadComplete(object sender)
        {
            if (sender != curWB)
            { return; }
            tspLoadProgress.Value = 0;
            tspLoadProgress.Maximum = 0;
            tspLoadProgress.Visible = false;

        }

        private void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            if (sender != curWB)
            { return; }
            this.Text = e.title;
        }

        private void cEXWB1_ScriptError(object sender, csExWB.ScriptErrorEventArgs e)
        {
            e.continueScripts = true;
        }

        private void cEXWB1_StatusTextChange(object sender, csExWB.StatusTextChangeEventArgs e)
        {
            if (sender != curWB)
            { return; }
            tsStatus.Text = e.text;
        }

        #endregion


        #region Favorities Handle
        /// <summary>
        /// load favorite
        /// </summary>
        public void LoadFavoritiesMenuItems()
        {
            LoadFavoritiesMenuItems(new DirectoryInfo(fswFavorities.Path), tsmFavorities);
        }


        public void LoadFavoritiesMenuItems(DirectoryInfo dir, ToolStripDropDownItem menuItem)
        {
            string urlName;
            string urlPath;

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs)
            {
                ToolStripMenuItem subItem = new ToolStripMenuItem(subDir.Name);
                menuItem.DropDownItems.Add(subItem);
                LoadFavoritiesMenuItems(subDir, subItem);
            }

            FileInfo[] files = dir.GetFiles("*.url");

            foreach (FileInfo file in files)
            {
                urlName = Path.GetFileNameWithoutExtension(file.Name);
                urlPath = curWB.ResolveInternetShortCut(file.FullName);

                ToolStripMenuItem item = new ToolStripMenuItem(urlName);
                item.Tag = urlPath;
                item.Click += this.FavoritiesOpeartionHandler;
                menuItem.DropDownItems.Add(item);

            }


        }

        /// <summary>
        /// operation of favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FavoritiesOpeartionHandler(object sender, EventArgs e)
        {
            if (sender == tsmFavoritiesAdd)
            {
                curWB.AddToFavorites();
            }

            if (sender == tsmFavoritiesOrganize)
            {
                curWB.OrganizeFavorites();

            }

            var item = (ToolStripItem)sender;
            if (item.Tag != null)
            {

                this.Goto(item.Tag.ToString());
                tscUrl.Text = item.Tag.ToString();
            }



        }

        #endregion


        #region  AddElement Manual Handle


        private void tsbFindElement_CheckedChanged(object sender, EventArgs e)
        {
            highLightElement = tsbFindElement.Checked;

        }

        private void HighlightElement(IHTMLElement element)
        {
            try
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
            catch
            {
                lastelement = null;
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

        private void cEXWB1_WBLButtonUp(object sender, csExWB.HTMLMouseEventArgs e)
        {
            if (tsbFindElement.Checked)
            {

                contextMenuElement.Show(cEXWB1.PointToScreen(e.ClientPoint));
                cEXWB1.Cursor = Cursors.Cross;
                e.Handled = true;
            }
            else
            {
                xMouse = e.ClientX;
                yMouse = e.ClientY;
            }
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


        private void AddElementTestStep_Click(object sender, EventArgs e)
        {

            AddTestStepByName("frmMain", ((ToolStripItem)sender).Text);
        }

        public void AddTestStepFormFrmpop(object sender, EventArgs e)
        {
            AddTestStepByName("frmPopup", ((ToolStripItem)sender).Text);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddFrmPopClose(object sender, FormClosedEventArgs e)
        {
            currentPopWindowText = m_frmPopup.curWB.DocumentTitle;
            AddBrowserTestStep(BrowserCommandTypes.Close, "", currentPopWindowText);
            currentPopWindowText = "";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementTestStepUseArg(object sender, EventArgs e)
        {
            string name = ((frmInputText)sender).actionName;
            string inputArgs = ((frmInputText)sender).inputArgs;
            switch (name)
            {
                case "ExecuteScript":
                    AddBrowserTestStep(BrowserCommandTypes.ExecuteScript, inputArgs, currentPopWindowText);
                    break;
                case "Goto":
                    AddBrowserTestStep(BrowserCommandTypes.Goto, inputArgs, currentPopWindowText);
                    break;
                case "WaitForPageLoad":
                    AddBrowserTestStep(BrowserCommandTypes.WaitForPageLoad, inputArgs, currentPopWindowText);
                    break;
                case "Select":
                    AddElementTestStep(activeElement, ElementCommandTypes.Select, inputArgs, currentPopWindowText);
                    break;
                case "SendKeys":
                    AddElementTestStep(activeElement, ElementCommandTypes.SendKeys, inputArgs, currentPopWindowText);
                    break;
                case "GetText":
                    AddElementTestStep(activeElement, ElementCommandTypes.GetText, inputArgs, currentPopWindowText);
                    break;
                case "ValidateAlertText":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateAlertText, inputArgs);
                    break;
                case "ValidateBrowserTitle":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateBrowserTitle, inputArgs);
                    break;
                case "ValidateBrowserUrl":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateBrowserUrl, inputArgs);
                    break;
                case "ValidateImage":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateImage, inputArgs);
                    break;
                case "ValidateItemText":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateItemText, inputArgs);
                    break;
                case "ValidateItemValue":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateItemValue, inputArgs);
                    break;
                case "ValidateContainText":
                    AddValidateTestStep(activeElement, ValidateCommandTypes.ValidateContainText, inputArgs);
                    break;
            }
            currentPopWindowText = "";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="actionName"></param>
        private void AddTestStepByName(string form, string actionName)
        {
            if (selectTest == null)
                return;
            frmInputText fit = null;
            if (form == "frmMain")
            {
                fit = new frmInputText(this, actionName);
                fit.addTestStep += new EventHandler(AddElementTestStepUseArg);
            }
            else if (form == "frmPopup")
            {
                fit = new frmInputText(m_frmPopup, actionName);
                fit.addTestStep += new EventHandler(AddElementTestStepUseArg);
                activeElement = m_frmPopup.ActiveElement;
                currentPopWindowText = m_frmPopup.curWB.DocumentTitle;
            }
            switch (actionName)
            {
                case "Back":
                    AddBrowserTestStep(BrowserCommandTypes.Back, "", currentPopWindowText);
                    break;
                case "Close":
                    AddBrowserTestStep(BrowserCommandTypes.Close, "", currentPopWindowText);
                    break;
                case "ExecuteScript":
                    fit.Show();
                    break;
                case "Forward":
                    AddBrowserTestStep(BrowserCommandTypes.Forward, "", currentPopWindowText);
                    break;
                case "Goto":
                    fit.Show();
                    break;
                case "Refresh":
                    AddBrowserTestStep(BrowserCommandTypes.Refresh, "", currentPopWindowText);
                    break;
                case "SwitchToAlertAccept":
                    AddBrowserTestStep(BrowserCommandTypes.SwitchToAlertAccept, "", currentPopWindowText);
                    break;
                case "SwitchToAlertDismiss":
                    AddBrowserTestStep(BrowserCommandTypes.SwitchToAlertDismiss, "", currentPopWindowText);
                    break;
                case "WaitForPageLoad":
                    fit.Show();
                    break;
                case "Click":
                    AddElementTestStep(activeElement, ElementCommandTypes.Click, "", currentPopWindowText);
                    break;
                case "Clear":
                    AddElementTestStep(activeElement, ElementCommandTypes.Clear, "", currentPopWindowText);
                    break;
                case "Select":
                    fit.Show();
                    break;
                case "SendKeys":
                    fit.Show();
                    break;
                case "GetText":
                    fit.Show();
                    break;
                case "ValidateAlertText":
                    fit.Show();
                    break;
                case "ValidateBrowserTitle":
                    fit.Show();
                    break;
                case "ValidateBrowserUrl":
                    fit.Show();
                    break;
                case "ValidateImage":
                    fit.Show();
                    break;
                case "ValidateItemText":
                    fit.Show();
                    break;
                case "ValidateItemValue":
                    fit.Show();
                    break;
                case "ValidateContainText":
                    fit.Show();
                    break;

            }

        }

        #endregion



      


    }
}
