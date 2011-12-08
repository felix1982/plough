using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace KDATFFS
{
    /// <summary>
    /// 
    /// </summary>
    public class TestTreeNode : TreeNode
    {
        private string testname;
        private DataTable table;
        private bool status;
        private string nodetype;
        private Test test;
        private Dictionary<string, TestStep> teststeps;

        public string TestName
        {
            get { return this.testname; }
            set { this.testname = value; }

        }

        public Test Test
        {
            get { return this.test; }
            set { this.test = value; }

        }

        public string NodeType
        {
            get { return this.nodetype; }
            set { this.nodetype = value; }

        }

        public DataTable Table
        {
            get { return this.table; }
            set { this.table = value; }
        }

        public bool Status
        {
            get { return this.status; }
            set { this.status = value; }
        }


        public Dictionary<string, TestStep> TestSteps
        {
            get { return this.teststeps; }
            set { this.teststeps = value; }
        }
    }
}
