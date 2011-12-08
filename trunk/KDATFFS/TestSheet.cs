using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDATFFS
{
    /// <summary>
    /// TestSheet, mapping Excel's sheet,so contains the collection of test
    /// </summary>
    public class TestSheet
    {
        /// <summary>
        /// the name of sheet
        /// </summary>
        private string testSheetName;
        /// <summary>
        /// the collection of test
        /// </summary>
        private Dictionary<string, Test> tests;
        /// <summary>
        /// test's DataTable
        /// </summary>
        private DataTable testset;

        public string TestSheetName
        {
            get { return this.testSheetName; }
            set { this.testSheetName = value; }

        }

        public Dictionary<string, Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

        public DataTable TestSet
        {
            get { return this.testset; }
            set { this.testset = value; }
        }

    }
}
