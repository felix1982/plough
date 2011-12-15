using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;


namespace KDATFFS
{
    [Serializable]
    public class TestStep
    {
        private string testid;
        private string teststepid;
        private ElementCommandTypes elementcommand;
        private BrowserCommandTypes browercommand;
        private ValidateCommandTypes validatecommandtype;
        private CommandTypes commandtype;
        private string commandargs;
        private FindMethodTypes findmethodtype;
        private string findargs;
        private IWebDriver webdriver;
        private IWebElement webelement;
        private bool ispass;
        private string framename;
        private string windowname;
        private string comment;
        private string expectedvalue;
        private string commandargscolumnname;
        private string Expectedcolumnname;



        /// <summary>
        /// Expected value
        /// </summary>
        public string ExpectedValue
        {
            get { return this.expectedvalue; }
            set { this.expectedvalue = value; }
        }

        /// <summary>
        /// teststep's comment
        /// </summary>
        public string Comment
        {
            get { return this.comment; }
            set { this.comment = value; }
        }


        public string CommandArgsColumnName
        {
            get { return this.commandargscolumnname; }
            set { this.commandargscolumnname = value; }
        }


        public string ExpectedColumnName
        {
            get { return this.Expectedcolumnname; }
            set { this.Expectedcolumnname = value; }
        }

       /// <summary>
       /// werther is frame
       /// </summary>
        public bool IsFrame
        {
            get
            {
                if (this.framename != "" )
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// werther is pop window
        /// </summary>
        public bool IsWindow
        {
            get
            {
                if (this.windowname != "" )
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// teststep's framename
        /// </summary>
        public string FrameName
        {
            get { return this.framename; }
            set { this.framename = value; }

        }

        /// <summary>
        //teststep's windowname
        /// </summary>
        public string WindowName
        {
            get { return this.windowname; }
            set { this.windowname = value; }

        }

        /// <summary>
        /// teststep's testid
        /// </summary>
        public string TestId
        {
            get { return this.testid; }
            set { this.testid = value; }

        }

        /// <summary>
        /// teststep's teststepid
        /// </summary>
        public string TestStepId
        {
            get { return this.teststepid; }
            set { this.teststepid = value; }

        }


        /// <summary>
        /// teststep's elementcommand
        /// </summary>
        public ElementCommandTypes ElementCommand
        {
            get { return this.elementcommand; }
            set { this.elementcommand = value; }

        }


        /// <summary>
        /// 
        /// </summary>
        public BrowserCommandTypes BrowserCommand
        {
            get { return this.browercommand; }
            set { this.browercommand = value; }

        }

        /// <summary>
        /// 
        /// </summary>
        public ValidateCommandTypes ValidateCommand
        {
            get { return this.validatecommandtype; }
            set { this.validatecommandtype = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public CommandTypes CommandType
        {
            get { return this.commandtype; }
            set { this.commandtype = value; }
        }


        public string CommandArgs
        {
            get { return this.commandargs; }
            set { this.commandargs = value; }

        }

        public FindMethodTypes FindMethodType
        {
            get { return this.findmethodtype; }
            set { this.findmethodtype = value; }

        }

        public string FindArgs
        {
            get { return this.findargs; }
            set { this.findargs = value; }

        }

        public IWebDriver WebDriver
        {
            get { return this.webdriver; }
            set { this.webdriver = value; }
        }

        public IWebElement WebElement
        {
            get { return this.webelement; }
            set { this.webelement = value; }
        }

        public bool IsPass
        {
            get { return this.ispass; }
            set { this.ispass = value; }
        }
    }
}
