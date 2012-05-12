using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using KDATFFS.Properties;

namespace KDATFFS.Provider
{
    public class DataProviderHelper
    {
        /// <summary>
        /// transform string into CommandTypes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static CommandTypes ConvertToCommandTypes(string str)
        {

            CommandTypes commandtype = new CommandTypes();
            switch (str)
            {
                case "Browser":
                    commandtype = CommandTypes.Browser;
                    break;
                case "Element":
                    commandtype = CommandTypes.Element;
                    break;
                case "Validate":
                    commandtype = CommandTypes.Validate;
                    break;
                default:
                    throw new ParseException(string.Format(Resources.ParseCommandTypesException, str));
            }
            return commandtype;
        }

        /// <summary>
        /// transform string into BrowserCommandTypes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static BrowserCommandTypes ConvertToBrowserCommandTypes(string str)
        {

            BrowserCommandTypes bct = new BrowserCommandTypes();
            switch (str)
            {
                case "Close":
                    bct = BrowserCommandTypes.Close;
                    break;
                case "ExecuteScript":
                    bct = BrowserCommandTypes.ExecuteScript;
                    break;
                case "GetPageSource":
                    bct = BrowserCommandTypes.GetPageSource;
                    break;
                case "GetScreenshot":
                    bct = BrowserCommandTypes.GetScreenshot;
                    break;
                case "GetTitle":
                    bct = BrowserCommandTypes.GetTitle;
                    break;
                case "GetUrl":
                    bct = BrowserCommandTypes.GetUrl;
                    break;
                case "Goto":
                    bct = BrowserCommandTypes.Goto;
                    break;
                case "None":
                    bct = BrowserCommandTypes.None;
                    break;
                case "SessionId":
                    bct = BrowserCommandTypes.SessionId;
                    break;
                case "SwitchToAlertAccept":
                    bct = BrowserCommandTypes.SwitchToAlertAccept;
                    break;
                case "SwitchToAlertDismiss":
                    bct = BrowserCommandTypes.SwitchToAlertDismiss;
                    break;
                case "WaitForPageLoad":
                    bct = BrowserCommandTypes.WaitForPageLoad;
                    break;
                case "Back":
                    bct = BrowserCommandTypes.Back;
                    break;
                case "Forward":
                    bct = BrowserCommandTypes.Forward;
                    break;
                case "Refresh":
                    bct = BrowserCommandTypes.Refresh;
                    break;
                default:
                    throw new ParseException(string.Format(Resources.ParseBrowserCommandExceptionn, str));
            }
            return bct;
        }


        /// <summary>
        ///  transform string into ElementCommandTypes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ElementCommandTypes ConvertToElementCommandTypes(string str)
        {
            ElementCommandTypes ect = new ElementCommandTypes();
            switch (str)
            {
                case "Clear":
                    ect = ElementCommandTypes.Clear;
                    break;
                case "Click":
                    ect = ElementCommandTypes.Click;
                    break;
                case "SendKeys":
                    ect = ElementCommandTypes.SendKeys;
                    break;
                case "Submit":
                    ect = ElementCommandTypes.Submit;
                    break;
                case "Select":
                    ect = ElementCommandTypes.Select;
                    break;
                case "GetAttribute":
                    ect = ElementCommandTypes.GetAttribute;
                    break;
                case "GetText":
                    ect = ElementCommandTypes.GetText;
                    break;
                default:
                    throw new ParseException(string.Format(Resources.ParseElementCommandException, str));
            }
            return ect;
        }


        /// <summary>
        ///  transform string into ValidateCommandTypes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static ValidateCommandTypes ConvertToValidateCommandTypes(string str)
        {
            ValidateCommandTypes vct = new ValidateCommandTypes();
            switch (str)
            {
                case "ValidateBrowserTitle":
                    vct = ValidateCommandTypes.ValidateBrowserTitle;
                    break;
                case "ValidateBrowserUrl":
                    vct = ValidateCommandTypes.ValidateBrowserUrl;
                    break;
                case "ValidateImage":
                    vct = ValidateCommandTypes.ValidateImage;
                    break;
                case "ValidateItemText":
                    vct = ValidateCommandTypes.ValidateItemText;
                    break;
                case "ValidateItemValue":
                    vct = ValidateCommandTypes.ValidateItemValue;
                    break;
                case "ValidateAlertText":
                    vct = ValidateCommandTypes.ValidateAlertText;
                    break;
                case "ValidateContainText":
                    vct = ValidateCommandTypes.ValidateContainText;
                    break;
                default:
                    throw new ParseException(string.Format(Resources.ParseValidateCommandException, str));
            }
            return vct;
        }

        /// <summary>
        /// transform string into FindMethodTypes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static FindMethodTypes ConvertToFindMethodTypes(string str)
        {
            FindMethodTypes fmt = new FindMethodTypes();
            switch (str)
            {
                case "":
                    fmt = FindMethodTypes.None;
                    break;
                case "None":
                    fmt = FindMethodTypes.None;
                    break;
                case "ClassName":
                    fmt = FindMethodTypes.ClassName;
                    break;
                case "CssSelector":
                    fmt = FindMethodTypes.CssSelector;
                    break;
                case "Id":
                    fmt = FindMethodTypes.Id;
                    break;
                case "LinkText":
                    fmt = FindMethodTypes.LinkText;
                    break;
                case "Name":
                    fmt = FindMethodTypes.Name;
                    break;
                case "PartiaLinkText":
                    fmt = FindMethodTypes.PartiaLinkText;
                    break;
                case "TagName":
                    fmt = FindMethodTypes.TagName;
                    break;
                case "Xpath":
                    fmt = FindMethodTypes.Xpath;
                    break;
                default:
                    throw new ParseException(string.Format(Resources.ParseFindMethodException, str));
            }
            return fmt;

        }

        /// <summary>
        /// create Test datatable
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public static DataTable SetDataTable(string tablename)
        {
            DataTable dt = new DataTable(tablename);
            dt.Columns.Add("TestId", Type.GetType("System.String"));
            dt.Columns.Add("TestStep", Type.GetType("System.String"));
            dt.Columns.Add("CommandType", Type.GetType("System.String"));
            dt.Columns.Add("Command", Type.GetType("System.String"));
            dt.Columns.Add("CommandArgs", Type.GetType("System.String"));
            dt.Columns.Add("FindMethodType", Type.GetType("System.String"));
            dt.Columns.Add("FindArgs", Type.GetType("System.String"));
            dt.Columns.Add("ExpectedValue", Type.GetType("System.String"));
            dt.Columns.Add("Frame", Type.GetType("System.String"));
            dt.Columns.Add("window", Type.GetType("System.String"));
            dt.Columns.Add("comment", Type.GetType("System.String"));
            return dt;
        }


        /// <summary>
        /// Initialize Test's TestTable  attribute
        /// </summary>
        /// <param name="testsheeps"></param>
        public static void SetTestTable(Dictionary<string, TestSheet> testsheeps)
        {
            foreach (string key in testsheeps.Keys)
            {
                TestSheet testsheet = testsheeps[key];
                foreach (string k in testsheet.Tests.Keys)
                {
                    IEnumerable<DataRow> query =
                        from order in testsheet.TestSet.AsEnumerable()
                        where order.Field<string>("TestId") == testsheet.Tests[k].TestId
                        select order;
                    testsheet.Tests[k].TestTable = query.CopyToDataTable<DataRow>();
                }

            }
        }


        /// <summary>
        /// save something to txt file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void SaveTextToFile(string path,string text)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(text);
            sw.Close();
            fs.Close();
        }
 
    }
}
