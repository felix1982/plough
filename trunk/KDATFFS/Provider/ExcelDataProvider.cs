using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Security;
using System.Diagnostics;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KDATFFS.Properties;
using OpenQA.Selenium.IE;

namespace KDATFFS.Provider
{
    public class ExcelDataProvider:IDataProvider
    {
        private bool jetNotRegistered;
        private const string Excel2007ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";
        private const string Excel2003ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\";";

        public ExcelDataProvider()
        {
            InitializeFields();
        }


        /// <summary>
        /// Initialize
        /// </summary>
        private void InitializeFields()
        {
            bool jet4Exists = false;

            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey("Microsoft.Jet.OLEDB.4.0"))
                {
                    jet4Exists = key != null;
                }
            }
            catch (SecurityException secExcepiton)
            {
                jet4Exists = false;
                Debug.WriteLine(secExcepiton.Message);
                throw;
            }
            finally
            {
                this.jetNotRegistered = !jet4Exists;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool JetNotRegistered
        {
            get { return jetNotRegistered; }
        }

        /// <summary>
        /// get connection string by file's extension
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <returns></returns>
        public string GetConnectionString(FileSystemInfo fileInfo)
        {
            if (fileInfo.Extension == ".xlsx" || JetNotRegistered)
            {
                return string.Format(Excel2007ConnectionString, fileInfo.FullName);
            }
            else
            {
                return string.Format(Excel2003ConnectionString, fileInfo.FullName);
            }
        }

        /// <summary>
        /// parse file and transform it to testsheeets
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public Dictionary<string, TestSheet> ParseData(string dataSource)
        {
            Dictionary<string, TestSheet> testsheets = new Dictionary<string, TestSheet>();
           
            string connString = GetConnectionString(new FileInfo(dataSource));      
            OleDbConnection oledbConnection = new OleDbConnection(connString);
            oledbConnection.Open();

            DataSet dataSet = new DataSet();
            DataTable dt = oledbConnection.GetSchema("Tables");
            
            foreach (DataRow dr in dt.Rows)
            {
                string sheetName = dr["TABLE_NAME"].ToString();
                TestSheet testsheet = new TestSheet();
                testsheet.TestSheetName = sheetName;
                string queryString = string.Format("Select * from [{0}]",sheetName);
                Dictionary<string, Test> tests = new Dictionary<string, Test>();
             
                OleDbCommand oleCommand = new OleDbCommand(queryString, oledbConnection);
                OleDbDataAdapter oledbDataAdapter = new OleDbDataAdapter(oleCommand);
                oledbDataAdapter.Fill(dataSet,sheetName);
                testsheet.TestSet = dataSet.Tables[sheetName];
                DataTable datatable = dataSet.Tables[sheetName];

                List<string> testids = new List<string>();
                    for (int i = 0; i < datatable.Rows.Count; i++)
                    {
                        string testid = datatable.Rows[i]["TestId"].ToString();
                        if (!testids.Contains(testid))
                        {
                            Test test = new Test();
                            testids.Add(testid);
                            test.TestId = testid;
                            TestStep ts = new TestStep();
                            ts.TestId = testid;
                            ts.TestStepId = datatable.Rows[i]["TestStep"].ToString();
                            ts.CommandType = DataProviderHelper.ConvertToCommandTypes(datatable.Rows[i]["CommandType"].ToString());
                            switch (ts.CommandType)
                            {
                                case CommandTypes.Browser:
                                    ts.BrowserCommand = DataProviderHelper.ConvertToBrowserCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                                case CommandTypes.Element:
                                    ts.ElementCommand = DataProviderHelper.ConvertToElementCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                                case CommandTypes.Validate:
                                    ts.ValidateCommand = DataProviderHelper.ConvertToValidateCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                            }

                            ts.CommandArgs = datatable.Rows[i]["CommandArgs"].ToString();
                            ts.FindMethodType = DataProviderHelper.ConvertToFindMethodTypes(datatable.Rows[i]["FindMethodType"].ToString());
                            ts.FindArgs = datatable.Rows[i]["FindArgs"].ToString();
                            ts.ExceptedValue = datatable.Rows[i]["ExceptedValue"].ToString();
                            ts.FrameName = datatable.Rows[i]["Frame"].ToString();
                            ts.WindowName = datatable.Rows[i]["window"].ToString();
                            ts.Comment = datatable.Rows[i]["comment"].ToString();
                            ts.WebDriver = test.WebDriver;
                            try
                            {
                                test.TestSteps.Add(ts.TestStepId, ts);
                            }
                            catch
                            {
                                throw new Exception(string.Format(Resources.ParseDuplicateException, testsheet.TestSheetName, ts.TestId, ts.TestStepId));
                            }
                            tests.Add(test.TestId, test);


                        }
                        else
                        {
                            tests[testid].TestId = testid;
                            TestStep ts = new TestStep();
                            ts.TestId = testid;
                            ts.TestStepId = datatable.Rows[i]["TestStep"].ToString();
                            ts.CommandType = DataProviderHelper.ConvertToCommandTypes(datatable.Rows[i]["CommandType"].ToString());
                            switch (ts.CommandType)
                            {
                                case CommandTypes.Browser:
                                    ts.BrowserCommand = DataProviderHelper.ConvertToBrowserCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                                case CommandTypes.Element:
                                    ts.ElementCommand = DataProviderHelper.ConvertToElementCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                                case CommandTypes.Validate:
                                    ts.ValidateCommand = DataProviderHelper.ConvertToValidateCommandTypes(datatable.Rows[i]["Command"].ToString());
                                    break;
                            }

                            ts.CommandArgs = datatable.Rows[i]["CommandArgs"].ToString();
                            ts.FindMethodType = DataProviderHelper.ConvertToFindMethodTypes(datatable.Rows[i]["FindMethodType"].ToString());
                            ts.FindArgs = datatable.Rows[i]["FindArgs"].ToString();
                            ts.ExceptedValue = datatable.Rows[i]["ExceptedValue"].ToString();
                            ts.FrameName = datatable.Rows[i]["Frame"].ToString();
                            ts.WindowName = datatable.Rows[i]["window"].ToString();
                            ts.Comment = datatable.Rows[i]["comment"].ToString();
                            ts.WebDriver = tests[testid].WebDriver;
                            try
                            {
                                tests[testid].TestSteps.Add(ts.TestStepId, ts);
                            }
                            catch
                            {
                                throw new Exception(string.Format(Resources.ParseDuplicateException, testsheet.TestSheetName, ts.TestId, ts.TestStepId));
                            }
                        }

                        testsheet.Tests = tests;

                    }
                    if (datatable.Rows.Count != 0)
                    {
                        testsheets.Add(sheetName, testsheet);
                    }
                
            }
            DataProviderHelper.SetTestTable(testsheets);
            oledbConnection.Close();
            return testsheets;
        }


        /// <summary>
        /// transform excel into dataset
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public DataSet ExcelToDataSet(string filepath)
        {
            string connString = GetConnectionString(new FileInfo(filepath));
            OleDbConnection oledbConnection = new OleDbConnection(connString);
            oledbConnection.Open();

            DataSet dataSet = new DataSet();
            dataSet.DataSetName = Path.GetFileNameWithoutExtension(filepath);
            DataTable dt = oledbConnection.GetSchema("Tables");
            foreach (DataRow dr in dt.Rows)
            {
                string name = dr["TABLE_NAME"].ToString();
                string queryString = string.Format("Select * from [{0}]", dr["TABLE_NAME"].ToString());
                name = name.Replace('$', ' ');
                name = name.Replace('\'', ' ').Trim();
                OleDbCommand oleCommand = new OleDbCommand(queryString, oledbConnection);
                OleDbDataAdapter oledbDataAdapter = new OleDbDataAdapter(oleCommand);
                oledbDataAdapter.Fill(dataSet, name);

            }
            oledbConnection.Close();
            return dataSet;

        }

  
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tmpDataTable"></param>
    /// <param name="strFileName"></param>

        public void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName, string sheetName)
        {

            if (tmpDataTable == null)
            {
                return;
            }

            int rowNum = tmpDataTable.Rows.Count;
            int columnNum = tmpDataTable.Columns.Count;
            int rowIndex = 1;
            int columnIndex = 0;

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            xlApp.DefaultFilePath = "";
            xlApp.DisplayAlerts = true;
            xlApp.SheetsInNewWorkbook = 1;
            Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
            var ws = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.ActiveSheet;
            ws.Name = sheetName;


            //
            foreach (DataColumn dc in tmpDataTable.Columns)
            {
                columnIndex++;

                xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;

            }

            for (int i = 0; i < rowNum; i++)
            {
                rowIndex++;
                columnIndex = 0;
                for (int j = 0; j < columnNum; j++)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = tmpDataTable.Rows[i][j].ToString();
                }

            }
            xlBook.SaveCopyAs(strFileName);
        }

    }
}
