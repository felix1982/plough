using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using KDATFFS.Properties;
using System.Threading;

namespace KDATFFS
{
    /// <summary>
    ///Element Command
    /// </summary>
    public class ElementCommand:ICommand
    {

       private int stepSpacingTime;

       public ElementCommand(int stepSpacingTime)
        {
            this.stepSpacingTime = stepSpacingTime;
        }

        /// <summary>
        /// execute element command 
        /// <param name="teststep">test step</param>
        public bool Execute(TestStep teststep)
        {
            //execute FindMethod.Execute Method ,to find element by teststep's attribute
            FindMethod findmethod = new FindMethod();
            findmethod.Execute(teststep);
            try
            {
                switch (teststep.ElementCommand)
                {
                    case ElementCommandTypes.Clear:
                        ExecuteClear(teststep);
                        teststep.IsPass = true;
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ElementCommandTypes.Click:
                        ExecuteClick(teststep);
                        teststep.IsPass = true;
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ElementCommandTypes.SendKeys:
                        ExecuteSendKeys(teststep);
                        teststep.IsPass = true;
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ElementCommandTypes.Submit:
                        ExecuteSubmit(teststep);
                        teststep.IsPass = true;
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ElementCommandTypes.Select:
                        ExecuteSelect(teststep);
                        teststep.IsPass = true;
                        Thread.Sleep(stepSpacingTime);
                        break;
                }
                return true;
            }
            catch (Exception unexecutecommand)
            {
               throw new ElementCommandException(string.Format(Resources.CommandExecutionExceptionMessage, teststep.TestId, teststep.TestStepId, teststep.ElementCommand.ToString()), unexecutecommand, this);
            }
        }


        /// <summary>
        /// execute IWebElement's Clear method
        /// </summary>
        /// <param name="teststep"></param>
        public void ExecuteClear(TestStep teststep)
        {
            teststep.WebElement.Clear();
        }

        /// <summary>
        /// execute IWebElement's Click method
        /// </summary>
        /// <param name="teststep"></param>
        public void ExecuteClick(TestStep teststep)
        {
            teststep.WebElement.Click();
        }

        /// <summary>
        /// execute IWebElement's SendKeys method
        /// </summary>
        /// <param name="teststep"></param>
        public void ExecuteSendKeys(TestStep teststep)
        {
            teststep.WebElement.SendKeys(UtilityClass.GetTestDate(teststep.CommandArgs));
        }

        /// <summary>
        /// execute IWebElement's Submit method
        /// </summary>
        /// <param name="teststep"></param>
        public void ExecuteSubmit(TestStep teststep)
        {
            teststep.WebElement.Submit();
        }

        /// <summary>
        /// execute select method 
        /// </summary>
        /// <param name="teststep"></param>
        public void ExecuteSelect(TestStep teststep)
        {
            SelectElement select = new SelectElement(teststep.WebElement);
            select.SelectByText(teststep.CommandArgs);
        }
     
    }
}
