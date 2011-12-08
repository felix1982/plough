using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Data;
using System.Data.OleDb;

namespace KDATFFS.Provider
{
    public class CsvDataProvider:IDataProvider
    {
     

        /// <summary>
        /// Save datatable to csv file
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="fileName"></param>
        public void DatatableToCsv(DataTable dataTable, string fileName, bool hashead)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs, Encoding.Default);

            if (hashead)
            {
                string columnString =dataTable.Columns[0].ColumnName;
                for(int i=1;i<dataTable.Columns.Count;i++)
                {
                    columnString = columnString + "," + dataTable.Columns[i].ColumnName;
 
                }
                writer.WriteLine(columnString);
            }

            int rowNumber = dataTable.Rows.Count;
            for (int i = 0; i < rowNumber; i++)
            {
                DataRow row = dataTable.Rows[i];
                string dataString = row.ItemArray[0].ToString();
                for (int j = 1; j < row.ItemArray.Length; j++)
                {
                    dataString = dataString + "," + row.ItemArray[j].ToString();  

                }
                writer.WriteLine(dataString);
            }

            writer.Close();
            fs.Close();
        }



        /// <summary>
        /// Parse file and transform it into TestSheets
        /// </summary>
        /// <param name="dataSource"></param>
        /// <param name="browsertype"></param>
        /// <returns></returns>
        public Dictionary<string, TestSheet> ParseData(string dataSource)
        {
            FileStream fs = new FileStream(dataSource, FileMode.Open);
            StreamReader reader = new StreamReader(fs, Encoding.Default);
            FileSystemInfo fsi = new FileInfo(dataSource);
            TestSheet testsheet = new TestSheet();
            Dictionary<string, TestSheet> testSheets = new Dictionary<string, TestSheet>();
            Dictionary<string, Test> tests = new Dictionary<string, Test>();
            List<string> testids = new List<string>();
            DataTable dt = DataProviderHelper.SetDataTable(fsi.Name);
            reader.ReadLine();
            string line;
            //traverse data rows and transform into TestStep
            while ((line = reader.ReadLine())!= null)
            {
                 string[] strs =  line.Split(',');
                 dt.Rows.Add(strs);
                 string str = strs[0];
                if (!testids.Contains(str))
                {
                    Test test = new Test();
                    testids.Add(str);
                    test.TestId = str;
                    TestStep ts = new TestStep();
                    ts.TestId = strs[0];
                    ts.TestStepId = strs[1];
                    ts.CommandType = DataProviderHelper.ConvertToCommandTypes(strs[2]);
                    switch(ts.CommandType)
                    {
                        case CommandTypes.Browser:
                            ts.BrowserCommand = DataProviderHelper.ConvertToBrowserCommandTypes(strs[3]);
                            break;
                         case CommandTypes.Element:
                            ts.ElementCommand = DataProviderHelper.ConvertToElementCommandTypes(strs[3]);
                            break;
                         case CommandTypes.Validate:
                            ts.ValidateCommand = DataProviderHelper.ConvertToValidateCommandTypes(strs[3]);
                            break;  
                    }

                    ts.CommandArgs=strs[4];
                    ts.FindMethodType = DataProviderHelper.ConvertToFindMethodTypes(strs[5]);
                    ts.FindArgs = strs[6];
                    ts.ExceptedValue = strs[7];
                    ts.FrameName = strs[8];
                    ts.WindowName = strs[9];
                    ts.Comment = strs[10];
                    ts.WebDriver = test.WebDriver;
                    test.TestSteps.Add(ts.TestStepId , ts);
                    tests.Add(test.TestId, test); 
                }
                else
                {
                    tests[str].TestId = str;
                    TestStep ts = new TestStep();
                    ts.TestId = strs[0];
                    ts.TestStepId = strs[1];
                    ts.CommandType = DataProviderHelper.ConvertToCommandTypes(strs[2]);
                    switch (ts.CommandType)
                    {
                        case CommandTypes.Browser:
                            ts.BrowserCommand = DataProviderHelper.ConvertToBrowserCommandTypes(strs[3]);
                            break;
                        case CommandTypes.Element:
                            ts.ElementCommand = DataProviderHelper.ConvertToElementCommandTypes(strs[3]);
                            break;
                        case CommandTypes.Validate:
                            ts.ValidateCommand = DataProviderHelper.ConvertToValidateCommandTypes(strs[3]);
                            break;
                    }

                    ts.CommandArgs = strs[4];
                    ts.FindMethodType = DataProviderHelper.ConvertToFindMethodTypes(strs[5]);
                    ts.FindArgs = strs[6];
                    ts.ExceptedValue = strs[7];
                    ts.FrameName = strs[8];
                    ts.WindowName = strs[9];
                    ts.Comment = strs[10];
                    ts.WebDriver = tests[str].WebDriver;
                    tests[str].TestSteps.Add(ts.TestStepId, ts);

                }
               
            }
            reader.Close();
            fs.Close();
            testsheet.TestSheetName = Path.GetFileNameWithoutExtension(fsi.Name);
            testsheet.Tests = tests;
            testsheet.TestSet = dt;
            testSheets.Add(testsheet.TestSheetName, testsheet);
            DataProviderHelper.SetTestTable(testSheets);
            return testSheets;
        }

        }

    }

