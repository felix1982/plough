using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{
    public class TestError
    {
        private Test test;
        private BrowserCommandException browsercommandexception;
        private ElementCommandException elementcommandexception;
        private ValidateCommandException validatecommandexception;
        private FindMethodException findmethodexception;

        public Test Test
        {
            get { return test; }
        }

        public TestError(BrowserCommandException expception, Test test)
        {
            this.browsercommandexception = expception;
            this.test = test;
        }

        public TestError(ElementCommandException expception, Test test)
        {
            this.elementcommandexception = expception;
            this.test = test;
        }


        public TestError(ValidateCommandException expception, Test test)
        {
            this.validatecommandexception = expception;
            this.test = test;
        }


        public TestError(FindMethodException expception, Test test)
        {
            this.findmethodexception = expception;
            this.test = test;
        }


        public BrowserCommandException BrowserCommandException
        {
            get { return browsercommandexception;}
            set{this.browsercommandexception=value;}
        }

        public ElementCommandException ElementCommandException
        {
            get { return elementcommandexception; }
            set{this.elementcommandexception=value;}
        }

        public ValidateCommandException ValidateCommandException
        {
            get { return validatecommandexception; }
             set{this.validatecommandexception=value;}
        }

        public FindMethodException FindMethodException
        {
            get { return this.findmethodexception; }
            set { this.findmethodexception = value; }
        }
    }
}
