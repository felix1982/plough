using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDATFFSRunner.Properties;
using KDATFFS.Provider;
using KDATFFS;
using System.Collections.ObjectModel;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KDATFFSRunner
{
    public partial class wKdatffsRunner : Form
    {
        private Dictionary<string, TestSheet> testSheets;
        private Collection<Test> tests;
        private DataTable executeTable;
        private BrowserTypes browsertype;
        private bool hasprofile =false;
        Thread thread;
        private string filename;
        private int stepspacingtime=500;
        private string dataProviderName;
        private string[] profileargument;
        DataProviderFactory dataProviderFactory = new DataProviderFactory();
        private DataSet testDataSet;
        private string testdatafilepath;
        ExcelDataProvider edp = new ExcelDataProvider();


        public wKdatffsRunner()
        {
            InitializeComponent();
            PreInitialize();
           
        }

        /// <summary>
        /// initialization
        /// </summary>
        public void PreInitialize()
        {
            string[] names = Enum.GetNames(typeof(BrowserTypes));
            chooseBrowserType.Items.Clear();
            foreach (string name in names)
            {
                chooseBrowserType.Items.Add(name);
 
            }
            chooseBrowserType.SelectedItem = names[1];

            setProfile.Visible = true;
            hasProfile.Visible = true;
            cTestStart.Enabled = false;
            cTestStop.Enabled = false;
            cTestRefresh.Enabled = false;

            this.SelectLog.SelectedItem = "Only Error";
            this.TestLog.Text = "";
            StepSpacingTime.SelectedItem = "100";
            StepSpacingTime.Text = "100";
            hasProfile.SelectedItem = "no";
            tscbDataDriver.SelectedItem = "no";
 
        }


        public BrowserTypes BrowserType
        {
            get { return this.browsertype; }
            set { this.browsertype = value; }
        }

        public bool HasProfile
        {
            get { return this.hasprofile; }
            set { this.hasprofile = value; }
        }



        private void testTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (e.Node.Tag.ToString())
            {
                case "Sheet":
                    TestTable.DataSource = ((TestSheetTreeNode)e.Node).Table;
                    break;
                case "Test":
                    TestTable.DataSource = ((TestTreeNode)e.Node).Table;
                    break;
            }
        }

        private void testTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                ParentNodeCheck(e.Node,e.Node.Checked);
                ChildNodeCheck(e.Node,e.Node.Checked);
            }
        }

        private void ParentNodeCheck(TreeNode treenode,bool ischecked)
        {
            if (treenode.Parent!=null)
            {
                treenode.Parent.Checked = ischecked;
                ParentNodeCheck(treenode.Parent, ischecked);
            }

        }

        private void ChildNodeCheck(TreeNode treenode,bool ischecked)
        {
            if (treenode.Nodes.Count != 0)
            {
                foreach (TreeNode tn in treenode.Nodes)
                {
                    tn.Checked = ischecked;
                    ChildNodeCheck(tn,ischecked);
                }

            }
        }

        /// <summary>
        /// start test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTestStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.numOfCompletedStep.Text = "";
                this.numOfFailStep.Text = "";
                TestLog.Text = "";

                this.TestStart();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }


        /// <summary>
        /// 
        /// </summary>
        public void TestStart()
        {
            //
            tests = SelectedTests();
            //
            if (tests.Count != 0)
            {
                executeTable = tests[0].TestTable.Clone();
                object[] objarray = new object[executeTable.Columns.Count];
                for (int i = 0; i < tests.Count; i++)
                {
                    for (int j = 0; j < tests[i].TestTable.Rows.Count; j++)
                    {
                        tests[i].TestTable.Rows[j].ItemArray.CopyTo(objarray, 0);
                        executeTable.Rows.Add(objarray);
                    }
                }

                this.TestTable.DataSource = executeTable;
                this.numOfTest.Text = tests.Count.ToString();
                this.numOfTestStep.Text = executeTable.Rows.Count.ToString();

                if (this.hasprofile == true)
                {
                    if (ServerName.Text == "")
                    {
                        MessageBox.Show("Proxy Address Can't be empty!");
                    }
                    else if (ServerPort.Text == "")
                    {
                        MessageBox.Show("Proxy Port Can't be empty!");
                    }
                    else
                    {
                        this.profileargument = new string[] { this.ServerName.Text, this.ServerPort.Text };
                        thread = new Thread(new ThreadStart(this.TestRunnerBeginStart));
                        thread.SetApartmentState(ApartmentState.STA);
                        thread.Start();
                    }
                }
                else
                {
                    thread = new Thread(new ThreadStart(this.TestRunnerBeginStart));
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                }
            }
            else
            {
                MessageBox.Show("you didn't choose any file!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void TestRunnerBeginStart()
        {
           
            using (TestManager testmanager = new TestManager(this.tests, this.browsertype, this.hasprofile,this.profileargument, this.stepspacingtime))
            {
                testmanager.TestStarted += new EventHandler(testmanager_TestStarted);
                testmanager.CommandCompleted += new EventHandler<CommandCompletedEventArgs>(testManager_CommandCompleted);
                testmanager.TestErrorOccurred += new EventHandler<TestErrorEventArgs>(testManager_TestErrorOccurred);
                testmanager.TestCompleted += new EventHandler(testmanager_TestCompleted);
                testmanager.TestCrashOccurredEvent += new EventHandler(testmanager_TestCrashOccurredEvent);
                testmanager.Execute(0);
            }
        }

        /// <summary>
        /// handle test execution's crash
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testmanager_TestCrashOccurredEvent(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(testmanager_TestCrashOccurredEvent), new object[] { sender, e });
                return;
            }

            if (thread.IsAlive)
            {
                thread.Abort();
                thread.Join(10);
            }

            cTestStart.Enabled = true;
            cTestStop.Enabled = false;
            cTestRefresh.Enabled = true;
            this.testTreeView.Enabled = true;
            this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestCrashString, sender.ToString());
        }

        /// <summary>
        /// handler test completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void testmanager_TestCompleted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(testmanager_TestCompleted), new object[] { sender, e });
                return;
            }
            cTestStart.Enabled = true;
            cTestStop.Enabled = false;
            cTestRefresh.Enabled = true;
            this.testTreeView.Enabled = true;
            ExecuteStatus.Text = "Done";
        }

        public void testmanager_TestStarted(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(testmanager_TestStarted), new object[] { sender, e });
                return;
            }
            cTestStart.Enabled = false;
            cTestStop.Enabled = true;
            cTestRefresh.Enabled = false;
            this.testTreeView.Enabled = false;
            ExecuteStatus.Text = "Running...";
        }



       private void testManager_TestErrorOccurred(object sender, TestErrorEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<TestErrorEventArgs>(testManager_TestErrorOccurred), new object[] { sender, e });
                return;
            }
            this.numOfFailStep.Text = e.NumberOfFailedSteps.ToString() ;

            for (int i = 0; i < TestTable.Rows.Count - 1; i++)
            {
                if (TestTable.Rows[i].Cells[1].Value.ToString() == e.TestStep.TestId && TestTable.Rows[i].Cells[2].Value.ToString() == e.TestStep.TestStepId)
                {
                    TestTable.Rows[i].Cells[0].Value = Resources.fail2;
                }
            }
           
           if(e.Error.BrowserCommandException!=null)
           {
               this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestFailLogString, e.TestStep.TestId, e.TestStep.TestStepId,e.TestStep.Comment, e.Error.BrowserCommandException.Message);
           }
           else if (e.Error.ElementCommandException != null)
           {
               this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestFailLogString, e.TestStep.TestId, e.TestStep.TestStepId, e.TestStep.Comment, e.Error.ElementCommandException.Message);
           }
           else if (e.Error.ValidateCommandException != null)
           {
               this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestFailLogString, e.TestStep.TestId, e.TestStep.TestStepId, e.TestStep.Comment, e.Error.ValidateCommandException.Message);
           }
           else if (e.Error.FindMethodException != null)
           {
               this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestFailLogString, e.TestStep.TestId, e.TestStep.TestStepId, e.TestStep.Comment, e.Error.FindMethodException.Message);
           }


           

        }

        /// <summary>
        /// handle method when teststep completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void testManager_CommandCompleted(object sender, CommandCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler<CommandCompletedEventArgs>(testManager_CommandCompleted), new object[] { sender, e });
                return;
            }

            this.numOfCompletedStep.Text = e.NumberOfCompletedSteps.ToString();

            for (int i = 0; i < TestTable.Rows.Count-1; i++)
            {
                if (TestTable.Rows[i].Cells[1].Value.ToString() == e.TestStep.TestId && TestTable.Rows[i].Cells[2].Value.ToString() == e.TestStep.TestStepId)
                {
                    TestTable.Rows[i].Cells[0].Value = Resources.Pass2;
                }
            }

            if(SelectLog.SelectedItem.ToString() =="All")
             {
                 this.TestLog.Text = this.TestLog.Text + string.Format(Resources.TestPassLogString, e.TestStep.TestId, e.TestStep.TestStepId,e.TestStep.Comment);
             }


        }

        /// <summary>
        /// handle method when choose browser type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseBrowserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chooseBrowserType.SelectedItem.ToString() == BrowserTypes.Firefox.ToString())
            {
                setProfile.Visible = true;
                hasProfile.Visible = true;
                this.browsertype = BrowserTypes.Firefox;
            }
            else
            {
                setProfile.Visible = false;
                hasProfile.Visible = false;
                ProfileLable.Visible = false;
                this.browsertype = BrowserTypes.IE;
            }
        }


        /// <summary>
        /// initialize treeview
        /// </summary>
        /// <param name="treeview"></param>
        /// <param name="testSheets"></param>
        public void InitializeTreeView(TreeView treeview, Dictionary<string, TestSheet> testSheets)
        {
            treeview.CheckBoxes = true;
            treeview.Nodes.Clear();

            TreeNode rootNode = new TreeNode();
            rootNode.Text = "Test Set";
            rootNode.Tag = "Root";
            treeview.Nodes.Add(rootNode);

            foreach (string key in testSheets.Keys)
            {
                TestSheetTreeNode testSheetTreeNode = new TestSheetTreeNode();
                testSheetTreeNode.Name = testSheets[key].TestSheetName;
                testSheetTreeNode.Text = testSheets[key].TestSheetName;
                testSheetTreeNode.Table = testSheets[key].TestSet;
                testSheetTreeNode.Tests = testSheets[key].Tests;
                testSheetTreeNode.Tag = "Sheet";
                rootNode.Nodes.Add(testSheetTreeNode);
                foreach (string k in testSheets[key].Tests.Keys)
                {
                    TestTreeNode testTreeNode = new TestTreeNode();
                    testTreeNode.Name = testSheets[key].Tests[k].TestId;
                    testTreeNode.Text = testSheets[key].Tests[k].TestId;
                    testTreeNode.Table = testSheets[key].Tests[k].TestTable;
                    testTreeNode.Test = testSheets[key].Tests[k];
                    testTreeNode.Tag = "Test";
                    testSheetTreeNode.Nodes.Add(testTreeNode);
                }

            }
            treeview.ExpandAll();
        }


        /// <summary>
        /// return the collection of selected test
        /// </summary>
        /// <returns></returns>
        public Collection<Test> SelectedTests()
        {
            Collection<Test> selectedtests = new Collection<Test>();
            foreach (TreeNode tn in testTreeView.Nodes[0].Nodes)
            {
                foreach (TreeNode ctn in tn.Nodes)
                {
                    if (ctn.Checked == true)
                    {
                        selectedtests.Add(((TestTreeNode)ctn).Test);
                    }
                }
            }
            // if it is a data driver test, execute follow code.
            if (tscbDataDriver.SelectedItem.ToString() == "yes")
            {
                Collection<Test> executetests = new Collection<Test>();
                foreach (Test test in selectedtests)
                {
                    test.WebDriver = null; // must assige null,otherwise can't be serialized
                    foreach (string key in test.TestSteps.Keys)
                    {
                        test.TestSteps[key].WebDriver = null; // must assige null,otherwise can't be serialized
                        test.TestSteps[key].WebElement = null;// must assige null,otherwise can't be serialized
                        if (GetDataFromDriver(test.TestSteps[key].CommandArgs) != null && GetDataFromDriver(test.TestSteps[key].CommandArgs) != "")
                        {
                            string tablename = (GetDataFromDriver(test.TestSteps[key].CommandArgs).Split(':'))[0];
                            string columnname = (GetDataFromDriver(test.TestSteps[key].CommandArgs).Split(':'))[1];
                            if (testDataSet.Tables.Contains(tablename))
                            {
                                test.TestData = testDataSet.Tables[tablename];
                            }
                            test.TestSteps[key].CommandArgsColumnName = columnname;
                        }

                        if (GetDataFromDriver(test.TestSteps[key].ExpectedValue) != null && GetDataFromDriver(test.TestSteps[key].ExpectedValue) != "")
                        {
                            string ecolumnname = (GetDataFromDriver(test.TestSteps[key].ExpectedValue).Split(':'))[1];
                            test.TestSteps[key].ExpectedColumnName = ecolumnname;
                        }


                    }

                }

                foreach (Test test in selectedtests)
                {
                    if (test.TestData != null)
                    {
                        int stepid = 1;
                        foreach (DataRow dr in test.TestData.Rows)
                        {
                           
                            Test newtest = (Test)Clone(test);
                            int i = 0;
                            foreach (string key in newtest.TestSteps.Keys)
                            {

                                if (newtest.TestSteps[key].CommandArgsColumnName != null)
                                {
                                    newtest.TestSteps[key].CommandArgs = dr[newtest.TestSteps[key].CommandArgsColumnName].ToString();
                                    newtest.TestTable.Rows[i]["CommandArgs"] = newtest.TestSteps[key].CommandArgs;
                                }

                                if (newtest.TestSteps[key].ExpectedColumnName != null)
                                {
                                    newtest.TestSteps[key].ExpectedValue = dr[newtest.TestSteps[key].ExpectedColumnName].ToString();
                                    newtest.TestTable.Rows[i]["ExpectedValue"] = newtest.TestSteps[key].ExpectedValue;
                                }
                                newtest.TestSteps[key].TestStepId = stepid.ToString();
                                newtest.TestTable.Rows[i]["TestStep"] = stepid.ToString();
                                i++;
                                stepid++;

                            }
                            executetests.Add(newtest);

                        }
                    }
                    else
                    {
                        executetests.Add(test);
                    }
                }

                return executetests;

            } 
           
            return selectedtests;
        }

        /// <summary>
        /// clone some object ,because in data driver ,must do depth clone
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object Clone(object obj)
        {
            if (!obj.GetType().IsSerializable)
            {
                throw new ArgumentException("object can't be serialized");
            }

            IFormatter format = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                format.Serialize(stream, obj);
                stream.Seek(0, SeekOrigin.Begin);

                return format.Deserialize(stream);
            }

        }


        public void IntializeDataTreeView()
        {
            testDataTreeView.Nodes.Clear();
            testDataTreeView.Nodes.Add(testDataSet.DataSetName);
            foreach (DataTable dt in testDataSet.Tables)
            {
                TestTreeNode ttn = new TestTreeNode();
                ttn.Text = dt.TableName;
                ttn.Table = dt;
                testDataTreeView.Nodes[0].Nodes.Add(ttn);

            }
            testDataTreeView.Refresh();
            testDataTreeView.ExpandAll();
        }


        public string GetDataFromDriver(string args)
        {
            Regex regex = new Regex(@"Data\[(.*)\]");
            if (regex.IsMatch(args))
            {
                return regex.Match(args).Groups[1].ToString();
            }
            return "";
        }


        /// <summary>
        /// stop execute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTestStop_Click(object sender, EventArgs e)
        {
            if (thread.IsAlive)
            {
                thread.Abort();
                thread.Join(10);
            }

            cTestStart.Enabled = true;
            cTestStop.Enabled = false;
            cTestRefresh.Enabled = true;
            this.testTreeView.Enabled = true;
        }

        /// <summary>
        /// clear log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearLog_Click(object sender, EventArgs e)
        {
            TestLog.Text = "";
        }

        /// <summary>
        /// refresh tests
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cTestRefresh_Click(object sender, EventArgs e)
        {
            if (this.filename != null)
            {
                try
                {
                    this.testTreeView.Enabled = true;
                    testSheets = dataProviderFactory.MakeDataProvider(dataProviderName).ParseData(this.filename);
                    InitializeTreeView(testTreeView, testSheets);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
 
                }
            }

        }

        /// <summary>
        /// choose time interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StepSpacingTime_TextChanged(object sender, EventArgs e)
        {
            this.stepspacingtime = Convert.ToInt32(StepSpacingTime.Text);
        }

        /// <summary>
        /// choose werther has proxy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hasProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hasProfile.SelectedItem.ToString() == "yes")
            {
                this.hasprofile = true;
                this.setProfile.Visible = true;
            }
            else
            {
                this.hasprofile = false;
                this.setProfile.Visible = false;
            }

        }

        /// <summary>
        /// open excel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenExcelFile_Click(object sender, EventArgs e)
        {
            try
            {
                openTestFile.FileName = "please choose file";
                openTestFile.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
                if (openTestFile.ShowDialog() == DialogResult.OK)
                {
                    this.filename = openTestFile.FileName;
                    dataProviderName = " KDATFFS.Provider.ExcelDataProvider";
                    testSheets = dataProviderFactory.MakeDataProvider(dataProviderName).ParseData(this.filename);
                    InitializeTreeView(testTreeView, testSheets);
                    cTestStart.Enabled = true;
                    cTestRefresh.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// open csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCsvFile_Click(object sender, EventArgs e)
        {
            try
            {
                openTestFile.FileName = "please choose file";
                openTestFile.Filter = "CSV file|*.csv|text file|*.txt";
                if (openTestFile.ShowDialog() == DialogResult.OK)
                {
                    this.filename = openTestFile.FileName;
                    dataProviderName = " KDATFFS.Provider.CsvDataProvider";
                    
                    testSheets = dataProviderFactory.MakeDataProvider(dataProviderName).ParseData(this.filename);
                    InitializeTreeView(testTreeView, testSheets);
                    cTestStart.Enabled = true;
                    cTestRefresh.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// save as 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "text file|*.txt";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(TestLog.Text);
                sw.Close();
                fs.Close();
       
            }
        }

        /// <summary>
        /// select treeview's node,DataGridView display test data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testDataTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is TestTreeNode)
            {
                testDataGridView.DataSource = ((TestTreeNode)e.Node).Table;
                testDataGridView.Refresh();
            }
        }

        /// <summary>
        /// import test data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbImportData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openTestData = new OpenFileDialog();
            openTestData.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx";
            openTestData.RestoreDirectory = true;
            if (openTestData.ShowDialog() == DialogResult.OK)
            {

                testdatafilepath = openTestData.FileName;
                testDataSet = edp.ExcelToDataSet(testdatafilepath);
                IntializeDataTreeView();
            }

        }

        /// <summary>
        /// refresh test data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRefreshData_Click(object sender, EventArgs e)
        {
            testDataSet = edp.ExcelToDataSet(testdatafilepath);
            IntializeDataTreeView();
            testDataTreeView.Refresh();
        }


    }
}
