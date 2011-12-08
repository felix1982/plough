using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using KDATFFS.Properties;
using System.Threading;

namespace KDATFFS
{
    /// <summary>
    /// find element,encapsulate webdriver's FindElement and By method.
    /// </summary>
    public class FindMethod
    {
        //
        private int findNumbers = 1;
        private TestStep testStep;

        /// <summary>
        /// execute teststep
        /// </summary>
        /// <param name="teststep">test step</param>
        /// <returns></returns>

        public TestStep Execute(TestStep teststep)
        {
            this.testStep = teststep;
            try
            {
                IWebElement returnValue;
                switch (teststep.FindMethodType)
                {
                    case FindMethodTypes.Id:
                        returnValue = this.FindById(teststep);
                        break;
                    case FindMethodTypes.Name:
                        returnValue = this.FindByName(teststep);
                        break;
                    case FindMethodTypes.ClassName:
                        returnValue = this.FindByClassName(teststep);
                        break;
                    case FindMethodTypes.CssSelector:
                        returnValue = this.FindByCssSelector(teststep);
                        break;
                    case FindMethodTypes.LinkText:
                        returnValue = this.FindByLinkText(teststep);
                        break;
                    case FindMethodTypes.PartiaLinkText:
                        returnValue = this.FindByPartialLinkText(teststep);
                        break;
                    case FindMethodTypes.TagName:
                        returnValue = this.FindByTagName(teststep);
                        break;
                    case FindMethodTypes.Xpath:
                        returnValue = this.FindByXPath(teststep);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("context", string.Format(CultureInfo.InvariantCulture, "Do not know how to execute the find method methodType: {0}"));
                }
                teststep.WebElement = returnValue;   
            }
            catch (Exception unexecutefindmethod)
            {
                //if can't find element in first,will wait two second to find again.
                if (findNumbers > 0)
                {
                    findNumbers--;
                    Thread.Sleep(2000);
                    Execute(this.testStep);             
                }
                else
                {
                    throw new FindMethodException(string.Format(Resources.FindMethodExecuteException, teststep.TestId, teststep.TestStepId, teststep.FindMethodType.ToString(), teststep.FindArgs), unexecutefindmethod, this);
                }
            } 
            return teststep;
        }



        public IWebElement FindById(TestStep teststep)
        {
           return teststep.WebDriver.FindElement(By.Id(teststep.FindArgs));
        }

        public IWebElement FindByName(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.Name(teststep.FindArgs));
        }


        public IWebElement FindByClassName(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.ClassName(teststep.FindArgs));
        }

        public IWebElement FindByTagName(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.TagName(teststep.FindArgs));
        }

        public IWebElement FindByCssSelector(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.CssSelector(teststep.FindArgs));
        }

        public IWebElement FindByLinkText(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.LinkText(teststep.FindArgs));
        }

        public IWebElement FindByPartialLinkText(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.PartialLinkText(teststep.FindArgs));
        }

        public IWebElement FindByXPath(TestStep teststep)
        {
            return teststep.WebDriver.FindElement(By.XPath(teststep.FindArgs));
        }
    }
}
