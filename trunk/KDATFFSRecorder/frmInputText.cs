using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDATFFSRecorder
{
    public partial class frmInputText : Form
    {
        public string actionName;
        public event EventHandler addTestStep;
        public string inputArgs;

        public frmInputText(frmMain MainForm, string actionName)
        {
            InitializeComponent();
            this.actionName = actionName;
            switch (actionName)
            {
                case "ValidateBrowserTitle":
                    this.tbArgs.Text = MainForm.curWB.DocumentTitle;
                    break;
                case "ValidateBrowserUrl":
                    this.tbArgs.Text = MainForm.curWB.LocationUrl;
                    break;
                case "ValidateItemValue":
                    if(MainForm.ActiveElement.getAttribute("Value",0)!=null)
                    {
                        this.tbArgs.Text = MainForm.ActiveElement.getAttribute("Value", 0).ToString();
                    }
                    break;
                case "ValidateItemText":
                    if (MainForm.ActiveElement.innerText!= null)
                    {
                        this.tbArgs.Text = MainForm.ActiveElement.innerText;
                    }
                    break;
                case "ValidateContainText":
                    if (MainForm.ActiveElement.innerText != null)
                    {
                        this.tbArgs.Text = MainForm.ActiveElement.innerText;
                    }
                    break;
                   
            }
            
        }

        public frmInputText(frmPopup PopForm, string actionName)
        {
            InitializeComponent();
            this.actionName = actionName;
            switch (actionName)
            {
                case "ValidateBrowserTitle":
                    this.tbArgs.Text = PopForm.curWB.DocumentTitle;
                    break;
                case "ValidateBrowserUrl":
                    this.tbArgs.Text = PopForm.curWB.LocationUrl;
                    break;
                case "ValidateItemValue":
                    if (PopForm.ActiveElement.getAttribute("Value", 0) != null)
                    {
                        this.tbArgs.Text = PopForm.ActiveElement.getAttribute("Value", 0).ToString();
                    }
                    break;
                case "ValidateItemText":
                    if (PopForm.ActiveElement.innerText != null)
                    {
                        this.tbArgs.Text = PopForm.ActiveElement.innerText;
                    }
                    break;
                case "ValidateContainText":
                    if (PopForm.ActiveElement.innerText != null)
                    {
                        this.tbArgs.Text = PopForm.ActiveElement.innerText;
                    }
                    break;
            }

        }

        

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (tbArgs.Text == "")
                return;
            inputArgs = tbArgs.Text;
            this.addTestStep(this, EventArgs.Empty);
            this.Close();

        }
    }
}
