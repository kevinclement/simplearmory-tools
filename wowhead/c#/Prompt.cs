using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WowheadParser
{
    public partial class Prompt : Form
    {
        public string Value { get { return this.valueBox.Text; } }

        public Prompt(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
