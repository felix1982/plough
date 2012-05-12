using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace KDATFFS
{
    /// <summary>
    /// utility class
    /// </summary>
    public class UtilityClass
    {

       private static Dictionary<string, string> returnData = new Dictionary<string, string>();

        static UtilityClass()
       {
 
       }

        public static string GetReturnData(string name)
        {
            foreach (string item in returnData.Keys)
            {
                if (name == item)
                {
                    return returnData[item];
                }
            }

            return "";
 
        }

        public static void InsertData(string name,string value)
        {
            if (returnData.ContainsKey(name))
            {
                returnData.Remove(name);
            }
            returnData.Add(name, value);

 
        }


        public static string GetTestDate(string commandArgs)
        {
            Regex regex = new Regex(@"(.*)Rule\[(.*)\]");
            Regex returnRegex = new Regex(@"(.*)=");
            Regex fixeRegex = new Regex(@"(F\()(.*)(\))");
            Regex randomRegex = new Regex(@"(R\()(\d*)(\))");
            Regex expectedRegex = new Regex(@"(E\()(.*)(\))");
            if (regex.IsMatch(commandArgs))
            {
                var items = regex.Match(commandArgs).Groups;
                string[] regItems = (items[2].ToString()).Split('|');
                StringBuilder sb = new StringBuilder();
                for(int i=0;i<regItems.Length;i++)
                {
                   
                    //fixed value
                    if (fixeRegex.IsMatch(regItems[i].ToString()))
                    {
                        var result = fixeRegex.Match(regItems[i].ToString()).Groups;
                        sb.Append(result[2].Value);
                    }

                    //random number
                    if (randomRegex.IsMatch(regItems[i].ToString()))
                    {
                        var result = randomRegex.Match(regItems[i].ToString()).Groups;
                        int number = Convert.ToInt32(result[2].Value);
                        sb.Append(GetRandomNumber(number));
                    }

                    //expected value
                    if (expectedRegex.IsMatch(regItems[i].ToString()))
                    {
                        var result = expectedRegex.Match(regItems[i].ToString()).Groups;
                        sb.Append(GetReturnData(result[2].Value));
                    }
                }

                if(returnRegex.IsMatch(items[1].ToString()))
                {
                    string name = returnRegex.Match(items[1].ToString()).Groups[1].Value;
                    if(returnData.ContainsKey(name))
                    {
                        returnData.Remove(name);
                    }
                    returnData.Add(name, sb.ToString());
                }

                return sb.ToString();
            }
            else
            {
                return commandArgs;
            }
           
        }

        /// <summary>
        /// generate random number
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomNumber(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(random.Next(10).ToString());
 
            }
            return sb.ToString();
        }

    }
}
