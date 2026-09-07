using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OutlookAddIn1
{
    public partial class GenerateEmailForm : Form
    {
        private readonly string tone;
        public GenerateEmailForm(string selectedTone)
        {
            InitializeComponent();
            tone = selectedTone;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void genBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(promptTextBox.Text))
            {
                MessageBox.Show("Please enter email instructions.");
                return;
            }

            if (lengthComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please choose a valid length for the email.");
                return;
            }

            try{
            EmailGenerationRequest request = new EmailGenerationRequest()
            {
                Instructions = promptTextBox.Text,
                Length = lengthComboBox.SelectedItem.ToString(),
                Tone = tone
            };

            GenerateEmailService service = new GenerateEmailService();

            EmailGenerationResponse response = await service.GenerateEmail(request);

            Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();

            if (inspector == null)
                {
                    MessageBox.Show("Please open a new email before generating.");
                    return;
                }

            Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;

            if (mailItem == null)
            {
                MessageBox.Show("The currently open Outlook item is not an email.");
                return;
            }

                mailItem.Subject = response.Subject;
                mailItem.Body = response.Body;

                this.Close();
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
