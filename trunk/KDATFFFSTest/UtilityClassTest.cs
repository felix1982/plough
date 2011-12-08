using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDATFFS.Provider;
using KDATFFS;
using MbUnit.Core;
using MbUnit.Framework;
using Gallio.Framework;

namespace KDATFFFSTest
{
    [TestFixture]
    public class UtilityClassTest
    {
        [Test]
        public void GetTestDateTest()
        {
            string commandArgs = "Rule[D(34)|F(622245)|R(10)]";
            string actual = UtilityClass.GetTestDate(commandArgs);
            int expected =16;
            Gallio.Framework.TestLog.WriteHighlighted(actual);
            Assert.AreEqual(expected, actual.Length);
        }


        [Test]
        public void GetExpectedDataTest()
        {
            string commandArgs = "Value1=Rule[D(34)|F(622245)|R(10)]";
            string commandArgs2 = "Rule[E(Value1)]";
            string commandArgs3 ="Value1=Rule[D(34)|F(622245)|R(10)]";
            string commandArgs4 = "Rule[E(Value1)]";
            string actual = UtilityClass.GetTestDate(commandArgs);
            string actual2 = UtilityClass.GetTestDate(commandArgs2);
            string actual3 = UtilityClass.GetTestDate(commandArgs3);
            string actual4 = UtilityClass.GetTestDate(commandArgs4);
            Gallio.Framework.TestLog.WriteLine(actual);
            Gallio.Framework.TestLog.WriteLine(actual2);
            Gallio.Framework.TestLog.WriteLine(actual3);
            Gallio.Framework.TestLog.WriteLine(actual4);
        }
    }
}
