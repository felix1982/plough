using System;
using System.Collections.Generic;
using System.Text;

namespace KDATFFS
{
    /// <summary>
    /// when command completed,will trigger CommandCompleted event,this is event's EventArgs
    /// </summary>
    public class CommandCompletedEventArgs:EventArgs
    {

        private int numberOfCompleteSteps;
        private int numberOfFailedSteps;
        private TestStep teststep;
        private bool success;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numberOfCompletedCommands"></param>
        /// <param name="numberOfFailedCommands"></param>
        /// <param name="success"></param>
        public CommandCompletedEventArgs(int numberOfCompletedCommands, int numberOfFailedCommands ,TestStep teststep, bool success)
        {
            this.numberOfCompleteSteps = numberOfCompletedCommands;
            this.numberOfFailedSteps = numberOfFailedCommands;
            this.success = success;
            this.teststep = teststep; 
        }

        /// <summary>
        /// the result of command execution ,if success return true,else return false.
        /// </summary>
        public bool Success
        {
            get { return success; }
        }

        /// <summary>
        /// return number of completed command
        /// </summary>
        public int NumberOfCompletedSteps
        {
            get { return numberOfCompleteSteps; }
        }

        /// <summary>
        ///return number of fail command
        /// </summary>
        public int NumberOfFailedSteps
        {
            get { return numberOfFailedSteps; }
        }

        /// <summary>
        /// return teststep
        /// </summary>
        public TestStep TestStep
        {
            get { return teststep; }
        }
    }
}
