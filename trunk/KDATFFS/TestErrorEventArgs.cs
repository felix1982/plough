using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{
    /// <summary>
    /// 
    /// </summary>
    public class TestErrorEventArgs:EventArgs
    {
        private TestError error;
        private  int numberOfFailedSteps;
        private TestStep teststep;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        public TestErrorEventArgs(TestError error, TestStep teststep, int numberOfFailedSteps)
        {
            this.error = error;
            this.numberOfFailedSteps=numberOfFailedSteps;
            this.teststep = teststep;
        }

        public TestError Error
        {
            get { return this.error; }
            set { this.error = value; }
        }

        public int NumberOfFailedSteps
        {
            get { return numberOfFailedSteps; }
             set { this.numberOfFailedSteps=value; }
        }

        public TestStep TestStep
        {
            get { return this.teststep; }
            set { this.teststep = value; }
        }

       
    }
}
