using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using KDATFFS.Properties;
using System.Threading;
using OpenQA.Selenium;

namespace KDATFFS
{
    public class ValidateCommand
    {
     
       private int stepSpacingTime;

        public ValidateCommand(int stepSpacingTime)
        {
            this.stepSpacingTime = stepSpacingTime;
        }


        public bool Execute(TestStep ts)
        {
            if (ts.FindMethodType!=FindMethodTypes.None)
            {
                FindMethod findmethod = new FindMethod();
                findmethod.Execute(ts);
            }

            try
            {
                switch (ts.ValidateCommand)
                {
                    case ValidateCommandTypes.ValidateBrowserTitle:
                        ts.IsPass = ValidateStringValue(ts.ExceptedValue, ExecuteValidateBrowserTitle(ts), Resources.ValidationExceptionRegex
                              , Resources.ValidationExceptionStringEquals);
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ValidateCommandTypes.ValidateBrowserUrl:
                        ts.IsPass = ValidateStringValue(ts.ExceptedValue, ExecuteValidateBrowserUrl(ts), Resources.ValidationExceptionRegex
                              , Resources.ValidationExceptionStringEquals);
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ValidateCommandTypes.ValidateItemText:
                        ts.IsPass = ValidateStringValue(ts.ExceptedValue, ExecuteValidateItemText(ts), Resources.ValidationExceptionRegex
                              , Resources.ValidationExceptionStringEquals);
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ValidateCommandTypes.ValidateItemValue:
                        ts.IsPass = ValidateStringValue(ts.ExceptedValue, ExecuteValidateItemValue(ts), Resources.ValidationExceptionRegex
                              , Resources.ValidationExceptionStringEquals);
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ValidateCommandTypes.ValidateAlertText:
                        ts.IsPass = ValidateStringValue(ts.ExceptedValue, ExecuteValidateAlertText(ts), Resources.ValidationExceptionRegex
                              , Resources.ValidationExceptionStringEquals);
                        Thread.Sleep(stepSpacingTime);
                        break;
                    case ValidateCommandTypes.ValidateContainText:
                        ts.IsPass = ExcuteValidateContainText(ts);
                        Thread.Sleep(stepSpacingTime);
                        break;
                }
                return true;
            }
            catch (ValidateCommandException unexecutecommand)
            {
                throw unexecutecommand;
            }
            catch (WebDriverException wde)
            {
                throw new ValidateCommandException(wde.Message);

            }
            catch (Exception ex)
            {
                throw new ValidateCommandException(ex.Message);
            }
 
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool IsRegularExpression(string str)
        {
            if (str.StartsWith("*", StringComparison.OrdinalIgnoreCase) || str.Contains(@"\w"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    
        public bool ValidateStringValue(string expected, string actual, string ValidationExceptionRegex, string ValidationExceptionStringEquals)
        {
            if (IsRegularExpression(expected))
            {
                Regex regex = new Regex(expected);
                if (!regex.Match(actual).Success)
                {
                    throw new ValidateCommandException(string.Format(CultureInfo.InvariantCulture, ValidationExceptionRegex, expected, actual));
                }
                else
                {
                    return true;

                }

            }
            else
            {
                if (actual.Trim().ToUpper() == UtilityClass.GetTestDate(expected).Trim().ToUpper())
                {
                    return true;
                }
                else
                {
                    throw new ValidateCommandException(string.Format(CultureInfo.InvariantCulture, ValidationExceptionStringEquals, UtilityClass.GetTestDate(expected), actual));
                }
            }

        }


        public string ExecuteValidateItemValue(TestStep ts)
        {
           return  ts.WebElement.GetAttribute(ts.CommandArgs);
        }


        public string ExecuteValidateBrowserTitle(TestStep ts)
        {
            return ts.WebDriver.Title;
 
        }


        public string ExecuteValidateBrowserUrl(TestStep ts)
        {
            return ts.WebDriver.Url;
        }


        public string ExecuteValidateItemText(TestStep ts)
        {
            return ts.WebElement.Text;
        }

    
        public string ExecuteValidateAlertText(TestStep ts)
        {
            return ts.WebDriver.SwitchTo().Alert().Text;
        }


        public bool ExcuteValidateContainText(TestStep ts)
        {
            string pageSource = ts.WebDriver.PageSource;
            if (pageSource.Contains(UtilityClass.GetTestDate(ts.ExceptedValue)) == true)
            {
                return true;
            }
            else
            {
                throw new ValidateCommandException(string.Format(CultureInfo.InvariantCulture, Resources.ValidateContainTextException, UtilityClass.GetTestDate(ts.ExceptedValue) ));
            }
        }

    }
}
