using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Data;
using System.Data.OleDb;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;


namespace KDATFFS
{
    [Serializable]
    public class Test
    {
       
        private Dictionary<string,TestStep> teststeps = new Dictionary<string,TestStep>();
        private IWebDriver webdriver;
        private string url;
        private BrowserTypes browserType;
        private string testid;
        private int numofteststep;
        private int numofteststepcompleted;
        private int numofteststepfail;
        private bool ispass;
        private Collection<TestError> errors;
        private bool throwerror;
        private DataTable testtable;
        private int stepSpacingTime;
        private DataTable testdata;


        /// <summary>
        /// initialize
        /// </summary>
        /// <param name="browsertype"></param>
        public Test()
        {


        }

        /// <summary>
        /// Test's DataTable
        /// </summary>
        public DataTable TestTable
        {
            get { return this.testtable; }
            set { this.testtable = value; }
        }

        /// <summary>
        /// whether throw error
        /// </summary>
        public bool ThrowError
        {
            get {return this.throwerror;}
            set{this.throwerror =value;}
        }


        public DataTable TestData
        {
            get { return this.testdata; }
            set { this.testdata = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Collection<TestError> Errors
        {
            get { return this.errors; }
            set { this.errors = value; }
        }

        /// <summary>
        /// trigger error's event
        /// </summary>
        public event EventHandler<TestErrorEventArgs> ErrorOccurredEvent;
        /// <summary>
        /// trigger commandcompleted's event
        /// </summary>
        public event EventHandler<CommandCompletedEventArgs> CommandCompletedEvent;


        public event EventHandler CrashOccurredEvent;


        /// <summary>
        /// the number of teststep
        /// </summary>
        public int NumOfTeststep
        {
            set { this.numofteststep = value; }
            get { return numofteststep; }
        }

        /// <summary>
        /// the number of completed teststep
        /// </summary>
        public int NumOfTeststepCompleted
        {
            set { this.numofteststepcompleted = value; }
            get { return numofteststepcompleted; }
        }

        /// <summary>
        /// the number of fail teststep
        /// </summary>
        public int NumOfTeststepFail
        {
            set { this.numofteststepfail = value; }
            get { return numofteststepfail; }
        }

        /// <summary>
        /// werther is the teststep pass
        /// </summary>
        public bool IsPass
        {
            set { this.ispass = value; }
            get { return ispass; }
        }




        /// <summary>
        /// execute test's browser type
        /// </summary>
        /// <param name="browser"></param>
        public Test(BrowserTypes browserType)
        {
            this.browserType = browserType;
        }

        /// <summary>
        /// get or set browser type
        /// </summary>
        public BrowserTypes BrowerType
        {
            set { this.browserType = value; }
            get { return browserType; }
        }

        /// <summary>
        /// get or set url
        /// </summary>
        public string Url
        {
            get { return this.url; }
            set { this.url = value; }
        }

        /// <summary>
        /// get or set test's TestStep collection
        /// </summary>
        public Dictionary<string,TestStep> TestSteps
        {
            get { return  teststeps; }
            set { teststeps = value; }
        }

        /// <summary>
        /// get or set IWebDriver
        /// </summary>
        public IWebDriver WebDriver
        {
            get
            {
                return webdriver;
            }

            set
            {
                webdriver = value;
            }

        }

        /// <summary>
        /// get or set Test's TestId
        /// </summary>
        public string TestId
        {
            get { return this.testid; }
            set { this.testid = value; }
        }


        /// <summary>
        /// execute test
        /// </summary>
        /// <param name="webdriver">IWebDriver</param>
        /// <param name="browsetype">browser type</param>
        /// <param name="shouldThrowErrors">werther throw error</param>
        /// <param name="stepSpacingTime">time interval when in execute test</param>
        public void Execute(IWebDriver webdriver, BrowserTypes browsetype, bool shouldThrowErrors,int stepSpacingTime)
        {
            this.ThrowError = shouldThrowErrors;
            this.numofteststepfail = 0;
            this.numofteststepcompleted = 0;
            this.WebDriver = webdriver;
            this.browserType = browsetype;
            this.stepSpacingTime = stepSpacingTime;

           foreach(string key in teststeps.Keys)
            {
                BrowserCommand bc = new BrowserCommand(stepSpacingTime);
                ElementCommand ec = new ElementCommand(stepSpacingTime);
                ValidateCommand vc = new ValidateCommand(stepSpacingTime);
               bool success = false;
               try
               {
                   teststeps[key].WebDriver = this.WebDriver;

                   switch (teststeps[key].CommandType)
                   {

                       case CommandTypes.Browser:

                           if (teststeps[key].IsFrame == true)
                           {
                               try
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Frame(teststeps[key].FrameName);
                               }
                               catch
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver;
                               }
                               bc.Execute(teststeps[key], browserType);
                           }
                           //when in popup window ,must be swichto popup window
                           else if (teststeps[key].IsWindow == true)
                           {
                               var handlers = teststeps[key].WebDriver.WindowHandles;
                               var currethandler = teststeps[key].WebDriver.CurrentWindowHandle;
                               bool hasPopupWindow = false;
                               foreach (var h in handlers)
                               {
                                   if (h != currethandler && teststeps[key].WebDriver.SwitchTo().Window(h).Title == teststeps[key].WindowName)
                                   {
                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(h);
                                       hasPopupWindow = true;
                                   }//if excepted windows appear, close them
                                   else if(h!= currethandler&&teststeps[key].WebDriver.SwitchTo().Window(h).Title != teststeps[key].WindowName)
                                   {
                                       teststeps[key].WebDriver.SwitchTo().Window(h).Close();
                                   }
                               }
                             // when occur error ,this must be execute 
                               if (hasPopupWindow == true)
                               {
                                   try
                                   {
                                       bc.Execute(teststeps[key],browserType);
                                   }
                                   catch (Exception ex) // must throw a exception
                                   {
                                       throw ex;
                                   }
                                   finally
                                   {
                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   }
                               }
                               else
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   throw new BrowserCommandException(string.Format("can't find the popup window \"{0}\"", teststeps[key].WindowName));
                               }
 
                           }
                           else
                           {

                               bc.Execute(teststeps[key], browserType);
                           }
                           break;
                       case CommandTypes.Element:
                           if (teststeps[key].IsFrame == true)
                           {
                               //if can't find iframe ,return current document.
                               try
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Frame(teststeps[key].FrameName);
                               }
                               catch
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver;
                               }
                               ec.Execute(teststeps[key]);
                           }
                           else if (teststeps[key].IsWindow == true)
                           {

                               var handlers = teststeps[key].WebDriver.WindowHandles;
                               var currethandler = teststeps[key].WebDriver.CurrentWindowHandle;
                               bool hasPopupWindow = false;
                               foreach (var h in handlers)
                               {
                                   if (h != currethandler && teststeps[key].WebDriver.SwitchTo().Window(h).Title == teststeps[key].WindowName)
                                   {

                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(h);
                                       hasPopupWindow = true;
                                   }
                                   else if (h != currethandler && teststeps[key].WebDriver.SwitchTo().Window(h).Title != teststeps[key].WindowName)
                                   {
                                       teststeps[key].WebDriver.SwitchTo().Window(h).Close();
                                   }
                               }
                               if (hasPopupWindow == true)
                               {
                                   try
                                   {
                                       ec.Execute(teststeps[key]);
                                   }
                                   catch (Exception ex)
                                   {
                                       throw ex;
                                   }
                                   finally
                                   {
                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   }

                               }
                               else
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   throw new ElementCommandException(string.Format("can't find the popup window \"{0}\"", teststeps[key].WindowName));
                               }
                               

                           }
                           else
                           {

                               ec.Execute(teststeps[key]);
                           }
                           break;
                       case CommandTypes.Validate:
                           if (teststeps[key].IsFrame == true)
                           {
                               try
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Frame(teststeps[key].FrameName);
                               }
                               catch
                               {
                                   teststeps[key].WebDriver = teststeps[key].WebDriver;
                               }
                               vc.Execute(teststeps[key]);
                           }
                           else if (teststeps[key].IsWindow == true)
                           {
                               var handlers = teststeps[key].WebDriver.WindowHandles;
                               var currethandler = teststeps[key].WebDriver.CurrentWindowHandle;
                               bool hasPopupWindow = false;

                               foreach (var h in handlers)
                               {
                                   if (h != currethandler && teststeps[key].WebDriver.SwitchTo().Window(h).Title == teststeps[key].WindowName)
                                   {
                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(h);
                                       hasPopupWindow = true;

                                   }
                                   else if (h != currethandler && teststeps[key].WebDriver.SwitchTo().Window(h).Title != teststeps[key].WindowName)
                                   {

                                       teststeps[key].WebDriver.SwitchTo().Window(h).Close();
                                   }
                               }
                               if (hasPopupWindow == true)
                               {
                                   try
                                   {
                                       vc.Execute(teststeps[key]);
                                   }
                                   catch (Exception ex)
                                   {
                                       throw ex;
                                   }
                                   finally
                                   {

                                       teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   }
                               }
                               else
                               {
            
                                   teststeps[key].WebDriver = teststeps[key].WebDriver.SwitchTo().Window(currethandler);
                                   throw new ValidateCommandException(string.Format("can't find the popup window \"{0}\"" , teststeps[key].WindowName));
                               }
                               
                           }
                           else
                           {
                               vc.Execute(teststeps[key]);
                           }
                           break;
                   }
                   success = true;
                   this.numofteststepcompleted = this.numofteststepcompleted + 1;

                   if (this.CommandCompletedEvent != null)
                   {
                       this.CommandCompletedEvent(teststeps[key], new CommandCompletedEventArgs(this.numofteststepcompleted, numofteststepfail, teststeps[key], success));
                   }

               }
               catch (FindMethodException findException)
               {
                   OnErrorOccured(new FindMethodException(findException.Message, findException), teststeps[key]);

               }
               catch (BrowserCommandException browserException)
               {
                   OnErrorOccured(new BrowserCommandException(browserException.Message, browserException, bc), teststeps[key]);
               }
               catch (ElementCommandException elementException)
               {
                   OnErrorOccured(new ElementCommandException(elementException.Message, elementException, ec), teststeps[key]);

               }
               catch (ValidateCommandException validateException)
               {
                   OnErrorOccured(new ValidateCommandException(validateException.Message, validateException, vc), teststeps[key]);

               }
               catch (WebDriverException webexception)
               {
                  // OnErrorOccured(webexception, teststeps[key]);
               }



               
            }
        }

        /// <summary>
        /// trigger the error of findmethod command
        /// </summary>
        /// <param name="fme">FindMethodException</param>
        /// <returns></returns>
        private bool OnErrorOccured(FindMethodException fme,TestStep teststep)
        {
            this.numofteststepfail = this.numofteststepfail + 1;
            if (!this.ThrowError)
            {
                TestError testerror = new TestError(fme, this);
                if (this.ErrorOccurredEvent != null)
                {
                    this.ErrorOccurredEvent(this, new TestErrorEventArgs(testerror, teststep,this.numofteststepfail));
                }
            }
            return true;
        }

        /// <summary>
        /// trigger the error of browser command
        /// </summary>
        /// <param name="fme">BrowserCommandException</param>
        /// <returns></returns>
        private bool OnErrorOccured(BrowserCommandException bce, TestStep teststep)
        {
            this.numofteststepfail = this.numofteststepfail + 1;
            if (!this.ThrowError)
            {
                TestError testerror = new TestError(bce, this);
                if (this.ErrorOccurredEvent != null)
                {
                    this.ErrorOccurredEvent(this, new TestErrorEventArgs(testerror, teststep, this.numofteststepfail));
                }
            }
            return true;
        }

        /// <summary>
        /// trigger the error of element command
        /// </summary>
        /// <param name="fme">ElementCommandException</param>
        /// <returns></returns>
        private bool OnErrorOccured(ElementCommandException ece, TestStep teststep)
        {
            this.numofteststepfail = this.numofteststepfail + 1;
            if (!this.ThrowError)
            {
                TestError testerror = new TestError(ece, this);
                if (this.ErrorOccurredEvent != null)
                {
                    this.ErrorOccurredEvent(this, new TestErrorEventArgs(testerror, teststep, this.numofteststepfail));
                }
            }
            return true;
        }

        /// <summary>
        /// trigger the error of validate command
        /// </summary>
        /// <param name="fme">ValidateCommandException</param>
        /// <returns></returns>
        private bool OnErrorOccured(ValidateCommandException vce, TestStep teststep)
        {
            this.numofteststepfail = this.numofteststepfail + 1;
            if (!this.ThrowError)
            {
                TestError testerror = new TestError(vce, this);
                if (this.ErrorOccurredEvent != null)
                {
                    this.ErrorOccurredEvent(this, new TestErrorEventArgs(testerror, teststep, this.numofteststepfail));
                }
            }
            return true;
        }

        private bool OnErrorOccured(WebDriverException wde, TestStep teststep)
        {
            if (this.CrashOccurredEvent != null)
            {

                this.CrashOccurredEvent(wde.Message, new EventArgs());
            }
            return true;
 
        }
    }
}
