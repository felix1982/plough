using System;
using System.Collections.Generic;
using System.Text;
using KDATFFS.Provider;
using System.Windows.Forms;
using System.Data;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;

namespace KDATFFS
{
    /// <summary>
    /// manage test's execution
    /// </summary>
    public class TestManager:IDisposable
    {

        private BrowserTypes browsertype;
        private Collection<Test> tests;
        private string[] profileargument;
        private bool throwErrors;
        private int totalNumberOfTestSteps;
        private int numberOfCompletedTestSteps;
        private int numberOfFailedTestSteps;
        private IWebDriver webdriver;
        private bool hasprofile;
        private bool isDisposed;
        private int stepSpacingTime;

        public event EventHandler TestStarted;
        public event EventHandler TestCompleted;
        public event EventHandler<TestErrorEventArgs> TestErrorOccurred;
        public event EventHandler<TestProgressEventArgs> Progress;
        public event EventHandler<CommandCompletedEventArgs> CommandCompleted;
        public event EventHandler TestCrashOccurredEvent;

        /// <summary>
        /// initialize TestManager
        /// </summary>
        /// <param name="tests">the collection of test</param>
        /// <param name="browsertype">browser type</param>
        /// <param name="hasprofile">werther has profile</param>
        /// <param name="profileargument">profile's argument</param>
        /// <param name="stepspacingtime">time interval</param>
        public TestManager(Collection<Test> tests, BrowserTypes browsertype, bool hasprofile, string[] profileargument, int stepspacingtime)
        {
            this.tests = tests;
            this.browsertype = browsertype;
            this.hasprofile = hasprofile;
            this.throwErrors = false;
            this.totalNumberOfTestSteps = 0;
            this.numberOfCompletedTestSteps = 0;
            this.numberOfFailedTestSteps = 0;
            this.stepSpacingTime = stepspacingtime;
            this.profileargument = profileargument;

            foreach (Test test in this.Tests)
            {
                this.totalNumberOfTestSteps = this.totalNumberOfTestSteps + test.TestSteps.Count;
                test.ErrorOccurredEvent += new EventHandler<TestErrorEventArgs>(OnErrorOccurredEvent);
                test.CommandCompletedEvent += new EventHandler<CommandCompletedEventArgs>(OnCommandCompletedEvent);
                test.CrashOccurredEvent += new EventHandler(test_CrashOccurredEvent);
            }

        }

        public void test_CrashOccurredEvent(object sender, EventArgs e)
        {
            if (this.TestCrashOccurredEvent != null)
            {
                this.TestCrashOccurredEvent(sender, e);
            }
        }

        public int StepSpacingTime
        {
            get { return this.stepSpacingTime; }
            set { this.stepSpacingTime = value; }
        }

        /// <summary>
        /// browser type
        /// </summary>
        public BrowserTypes BrowserType
        {
            get { return this.browsertype; }
            set { this.browsertype = value; }

        }

        /// <summary>
        /// the collection of test
        /// </summary>
        public Collection<Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

        /// <summary>
        /// the total number of teststep
        /// </summary>
        public int TotalNumberOfTestSteps
        {
            get { return this.totalNumberOfTestSteps; }
            set { this.totalNumberOfTestSteps = value; }
        }

        /// <summary>
        /// the number of completed teststep
        /// </summary>
        public int NumberOfCompletedTestSteps
        {
            get { return this.numberOfCompletedTestSteps; }
            set { this.numberOfCompletedTestSteps = value; }
        }

        /// <summary>
        /// get or set the number of fail teststep
        /// </summary>
        public int NumberOfFailedTestSteps
        {
            get { return this.numberOfFailedTestSteps; }
            set { this.numberOfFailedTestSteps = value; }
        }

        /// <summary>
        /// werther throw error
        /// </summary>
        public bool ThrowErrors
        {
            get { return throwErrors; }
            set { throwErrors = value; }
        }

        /// <summary>
        /// werther has profile
        /// </summary>
        public bool HasProfile
        {
            get { return hasprofile; }
            set { hasprofile = value; }
        }


        /// <summary>
        /// the method of handle commandcomplated event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         public void OnCommandCompletedEvent(object sender, CommandCompletedEventArgs e)
        {
            if (e.Success)
            {
                this.numberOfCompletedTestSteps = this.numberOfCompletedTestSteps + 1;
            }
            else
            {
                this.numberOfFailedTestSteps = this.numberOfFailedTestSteps + 1;
            }

            if (this.Progress != null)
            {
                this.Progress(this,new TestProgressEventArgs(this.totalNumberOfTestSteps,this.numberOfCompletedTestSteps));
            }

             if(this.CommandCompleted!=null)
             {
                 this.CommandCompleted(sender,new CommandCompletedEventArgs(this.numberOfCompletedTestSteps,this.numberOfFailedTestSteps,e.TestStep,e.Success));
             }
                
        }



          public void OnErrorOccurredEvent(object sender, TestErrorEventArgs e)
        {
            this.numberOfFailedTestSteps = this.numberOfFailedTestSteps + 1;
            if (this.TestErrorOccurred != null)         
            {
                e.NumberOfFailedSteps = this.numberOfFailedTestSteps;
                this.TestErrorOccurred(sender, e);
            }
        }

        /// <summary>
        /// execute tests
        /// </summary>
        /// <param name="testnumber"></param>
        public void Execute(int testnumber)
        {
       
                if (this.BrowserType == BrowserTypes.Firefox && this.HasProfile == true)
                {
                    FirefoxProfile profile = new FirefoxProfile();
                    profile.SetPreference("network.proxy.type", 1);
                    profile.SetPreference("network.proxy.http", this.profileargument[0]);
                    profile.SetPreference("network.proxy.http_port", Convert.ToInt32(this.profileargument[1]));
                    webdriver = new FirefoxDriver(profile);
                }
                else if (this.BrowserType == BrowserTypes.Firefox && this.HasProfile == false)
                {
                    webdriver = new FirefoxDriver();
                }
                else if (this.BrowserType == BrowserTypes.IE)
                {
                    webdriver = new InternetExplorerDriver();
                }
   
                for (int i = testnumber; i < this.tests.Count; i++)
                {
                    if (this.TestStarted != null)
                    {
                        this.TestStarted(tests[i], EventArgs.Empty);
                    }

                    this.tests[i].Execute(webdriver, this.BrowserType, throwErrors, stepSpacingTime);

                    if (this.TestCompleted != null)
                    {
                        this.TestCompleted(tests[i], EventArgs.Empty);
                    }
                }


        }


        #region

        ~TestManager()
        {
            

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool isDisposing)
        {
            if (this.isDisposed)
            {
                return ;
            }

            if (isDisposing)
            {
                if (this.webdriver != null)
                {
                    this.webdriver.Dispose();
                }

                foreach (Test test in tests)
                {
                    test.ErrorOccurredEvent -= new EventHandler<TestErrorEventArgs>(OnErrorOccurredEvent);
                    test.CommandCompletedEvent -= new EventHandler<CommandCompletedEventArgs>(OnCommandCompletedEvent);
                    test.CrashOccurredEvent -= new EventHandler(test_CrashOccurredEvent);
                }
            }

        }

        #endregion

    }


   
    

}
