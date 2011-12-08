using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDATFFS
{
    public class TestProgressEventArgs:EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly int totalNumberOfSteps;

        /// <summary>
        /// 
        /// </summary>
        private readonly int numberOfCompletedSteps;

      
        public TestProgressEventArgs(int totalNumberOfSteps, int numberOfCompletedSteps)
        {
            this.totalNumberOfSteps = totalNumberOfSteps;
            this.numberOfCompletedSteps = numberOfCompletedSteps;
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumberOfCompletedSteps
        {
            get { return numberOfCompletedSteps; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalNumberOfSteps
        {
            get { return totalNumberOfSteps; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public int PercentComplete
        {
            get
            {
                return (int)((this.numberOfCompletedSteps / (float)this.totalNumberOfSteps) * 100);
            }
        }
    }
}
