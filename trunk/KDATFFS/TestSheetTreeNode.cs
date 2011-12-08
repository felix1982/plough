using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace KDATFFS
{

    /// <summary>
    /// TestSheetTreeNode
    /// </summary>
    public class TestSheetTreeNode : TreeNode
    {
        private string sheetname;
        private DataTable table;
        private bool status;
        private string nodetype;
        private Dictionary<string, Test> tests;

        public string SheetName
        {
            get { return this.sheetname; }
            set { this.sheetname = value; }

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

        public Dictionary<string, Test> Tests
        {
            get { return this.tests; }
            set { this.tests = value; }
        }

    }
}
