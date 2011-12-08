using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDATFFS;
using System.Data;
using IfacesEnumsStructsClasses;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KDATFFSRecorder.Core
{
    public class TestRecorder
    {

     
        /// <summary>
        /// 创建DataTable
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable createTable(string tableName)
        {
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add("TestId", Type.GetType("System.String"));
            dt.Columns.Add("TestStep", Type.GetType("System.String"));
            dt.Columns.Add("CommandType", Type.GetType("System.String"));
            dt.Columns.Add("Command", Type.GetType("System.String"));
            dt.Columns.Add("CommandArgs", Type.GetType("System.String"));
            dt.Columns.Add("FindMethodType", Type.GetType("System.String"));
            dt.Columns.Add("FindArgs", Type.GetType("System.String"));
            dt.Columns.Add("ExceptedValue", Type.GetType("System.String"));
            dt.Columns.Add("Frame", Type.GetType("System.String"));
            dt.Columns.Add("Window", Type.GetType("System.String"));
            dt.Columns.Add("Comment", Type.GetType("System.String"));

            return dt;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ts"></param>
        public void updateTable(Test test, TestStep ts)
        {
            DataRow newRow = test.TestTable.NewRow();
            newRow["TestId"] = ts.TestId;
            newRow["TestStep"] = ts.TestStepId;
            newRow["CommandType"] = ts.CommandType;
            switch(ts.CommandType)
            {
                case CommandTypes.Browser:
                    newRow["Command"] = ts.BrowserCommand;
                    break;
                case CommandTypes.Element:
                     newRow["Command"] = ts.ElementCommand;
                    break;
                case CommandTypes.Validate:
                     newRow["Command"] = ts.ValidateCommand;
                    break;
            }
            newRow["CommandArgs"] = ts.CommandArgs ;
            if (ts.FindMethodType != FindMethodTypes.None)
            {
                newRow["FindMethodType"] = ts.FindMethodType;
            }
            else
            {
                newRow["FindMethodType"] = "";
            }
            newRow["FindArgs"] = ts.FindArgs;
            newRow["ExceptedValue"] = ts.ExceptedValue;
            newRow["Frame"] = ts.FrameName;
            newRow["Window"] = ts.WindowName;
            newRow["Comment"] = ts.Comment;

            test.TestTable.Rows.Add(newRow);
            test.TestSteps.Add(ts.TestStepId, ts);

        }

    }
}
