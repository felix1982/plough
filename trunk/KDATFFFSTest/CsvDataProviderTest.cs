using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KDATFFS.Provider;
using KDATFFS;
using MbUnit.Core;
using MbUnit.Framework;
using Gallio.Framework;

namespace KDATFFFSTest
{
    [TestFixture]
    public class CsvDataProviderTest
    {
        CsvDataProvider cdp = null;
        

        [SetUp]
        public void  SetUp()
        {
            cdp = new CsvDataProvider();
        }


        [Test]
        public void SetDataTableTest()
        {
            string expectedTableName = "MyTable";
            int expectedTableColumnNum = 11;
            string expectedTableColumnName = "Frame";
            DataTable actualTable = DataProviderHelper.SetDataTable(expectedTableName);

            Assert.AreEqual(expectedTableName, actualTable.TableName);
            Assert.AreEqual(expectedTableColumnNum, actualTable.Columns.Count);
            Assert.AreEqual(expectedTableColumnName, actualTable.Columns[8].ColumnName);
 
        }

        [Test]
        public void DatatableToCsvTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TestId",Type.GetType("System.String"));
            dt.Columns.Add("TestStepId", Type.GetType("System.String"));
            for(int i=0;i<10;i++)
            {
                DataRow dr = dt.NewRow();
                dr["TestId"] = "Test" + i;
                dr["TestStepId"] = "TestStepId" + i;
                dt.Rows.Add(dr);
            }
            cdp.DatatableToCsv(dt, "D:\\Test.csv", true);
            cdp.DatatableToCsv(dt, "D:\\Test2.csv", false);
            Gallio.Framework.TestLog.WriteHighlighted(string.Format("请检查路径{0}上的文件", "D:\\Test.csv"));
            
        }

    }
}
