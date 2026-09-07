using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddIn1
{

    public partial class ReplyAssistForm : Form
    {
        public string MailContent { get; private set; }
        public string Instructions { get; private set; }
        public ReplyAssistForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailCtxBox.Text) || string.IsNullOrWhiteSpace(replyCtxBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Email context or reply instructions can not be empty.");
                return;
            }

            MailContent = emailCtxBox.Text;
            Instructions = replyCtxBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
