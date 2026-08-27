using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;

namespace OutlookAddIn1
{
    public partial class Ribbon1
    {

        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private string GetGeminiApiKey()
        {
            return ConfigurationManager.AppSettings["GeminiApiKey"];
        }

        private void genEmailBtn_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private async void emailSplchkBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();

            if (inspector == null)
            {
                System.Windows.Forms.MessageBox.Show("Please open an email before using Spell Check.");
                return;
            }

            Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;

            if (mailItem == null)
            {
                System.Windows.Forms.MessageBox.Show("The currently open Outlook item is not an email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(mailItem.Body))
            {
                System.Windows.Forms.MessageBox.Show("The email body is empty.");
                return;
            }

            try
            {
                SpellCheckService service = new SpellCheckService();

                string correctedBody = await service.SpellCheck(mailItem.Body);

                mailItem.Body = correctedBody;
            }

            catch (InvalidOperationException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void langConBtn_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void repAssistBtn_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void chatbotBtn_Click(object sender, RibbonControlEventArgs e)
        {
        }

        private void proEmailBtn_Click(object sender, RibbonControlEventArgs e)
        {
            GenerateEmailForm form = new GenerateEmailForm("Professional");
            form.ShowDialog();
        }

        private void casEmailBtn_Click(object sender, RibbonControlEventArgs e)
        {
            GenerateEmailForm form = new GenerateEmailForm("Casual");
            form.ShowDialog();
        }
    }
}
