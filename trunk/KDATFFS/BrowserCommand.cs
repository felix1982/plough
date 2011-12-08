using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.Threading;
using System.Globalization;
using KDATFFS.Properties;
using KDATFFS.Provider;

namespace KDATFFS
{
    /// <summary>
    /// Browser's Command Class,Use to execute WebDriver's method ,Such as goto,back,forward...etc.
    /// </summary>
    public class BrowserCommand:ICommand
    {
        private TestStep teststep = null;
        private BrowserTypes browsertype ;
        private int stepSpacingTime;
        private int execTimes = 1;

        public BrowserCommand(int stepSpacingTime)
        {
            this.stepSpacingTime = stepSpacingTime;
        }

        public bool Execute(TestStep teststep, BrowserTypes browsertype)
        {
           
            this.teststep = teststep;
            this.browsertype = browsertype;
           try
           {
                switch (teststep.BrowserCommand)
                {
                    case BrowserCommandTypes.Close:
                        ExecuteClose();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.ExecuteScript:
                        ExecuteJs();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.GetScreenshot:
                        ExecuteGetScreenshot();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.Goto:
                        ExecuteGoto();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.SwitchToAlertAccept:
                        ExecuteSwitchToAlertAccept();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.SwitchToAlertDismiss:
                        ExecuteSwitchToAlertDismiss();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.Back:
                        ExecuteBack();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.Forward:
                        ExecuteForward();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.Refresh:
                        ExecuteRefresh();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.WaitForPageLoad:
                        ExecuteWaitForPageLoad();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case BrowserCommandTypes.GetPageSource:
                        ExecuteGetPageSource();
                        Thread.Sleep(stepSpacingTime);
                        break;
                    default:
                        throw new BrowserCommandException(string.Format("Can't Recognize {0} Browser Command!",teststep.BrowserCommand.ToString()));
                }
                return true;
           }
            catch(Exception unexecutecommand)
           {
               if (execTimes > 0)
               {
                   execTimes--;
                   Thread.Sleep(2000);
                   Execute(this.teststep, this.browsertype);
               }
               else
               {
                   throw new BrowserCommandException(string.Format(Resources.CommandExecutionExceptionMessage, this.teststep.TestId, this.teststep.TestStepId, teststep.BrowserCommand.ToString()), unexecutecommand, this);
               }
               return false;
            }
            
 
        }

        /// <summary>
        /// Execute WebDriver's "GetPageSource" method.
        /// </summary>
        /// <param name="testStep"></param>
        public void ExecuteGetPageSource()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                string source = ((FirefoxDriver)teststep.WebDriver).PageSource;
                DataProviderHelper.SaveTextToFile(teststep.CommandArgs, source);
            }
            else
            {
                string source = ((InternetExplorerDriver)teststep.WebDriver).PageSource;
                DataProviderHelper.SaveTextToFile(teststep.CommandArgs, source);
            }
        }

        /// <summary>
        /// Execute WebDriver's "Close" method.
        /// </summary>
        /// <param name="testStep"></param>
        public void ExecuteClose()
        {
            if(browsertype ==BrowserTypes.Firefox)
            {
             ((FirefoxDriver)teststep.WebDriver).Close();
            }
            else
            {
              ((InternetExplorerDriver)teststep.WebDriver).Close();
            }
        }

        /// <summary>
        /// Execute WebDriver's "ExecuteScript" method.
        /// </summary>
        public void ExecuteJs()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).ExecuteScript(teststep.CommandArgs);
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).ExecuteScript(teststep.CommandArgs);
            }
        }
        

        public void ExecuteGetScreenshot()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).GetScreenshot().SaveAsFile(teststep.CommandArgs,ImageFormat.Jpeg);
            }

        }

        /// <summary>
        /// Execute WebDriver's "ExecuteScript" method.
        /// </summary>
        public void ExecuteGoto()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).Navigate().GoToUrl(teststep.CommandArgs);
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).Navigate().GoToUrl(teststep.CommandArgs);
            }
        }
        /// <summary>
        /// Execute WebDriver's "Back" method.
        /// </summary>
        public void ExecuteBack()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).Navigate().Back();
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).Navigate().Back();
            }
        }
        /// <summary>
        /// Execute WebDriver's "Forward" method.
        /// </summary>
        public void ExecuteForward()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).Navigate().Forward();
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).Navigate().Forward();
            }
        }
        /// <summary>
        /// Execute WebDriver's "Refresh" method.
        /// </summary>
        public void ExecuteRefresh()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).Navigate().Refresh();
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).Navigate().Refresh();
            }
        }


        /// <summary>
        /// Execute Alert Dialog "Accept" handle
        /// </summary>
        public void ExecuteSwitchToAlertAccept()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).SwitchTo().Alert().Accept();
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).SwitchTo().Alert().Accept();
            }
        }

        /// <summary>
        ///  Execute Alert Dialog "Dismiss" handle
        /// </summary>
        public void ExecuteSwitchToAlertDismiss()
        {
            if (browsertype == BrowserTypes.Firefox)
            {
                ((FirefoxDriver)teststep.WebDriver).SwitchTo().Alert().Dismiss();
            }
            else
            {
                ((InternetExplorerDriver)teststep.WebDriver).SwitchTo().Alert().Dismiss();
            }
        }

        /// <summary>
        /// Wait for some times to load page
        /// </summary>
        public void ExecuteWaitForPageLoad()
        {
            try
            {
                int time = Convert.ToInt32(teststep.CommandArgs);
                Thread.Sleep(time);
            }
            catch
            {
                
            }
        }
        
    }
}
