using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            if (string.IsNullOrWhiteSpace(mailItem.Subject) && string.IsNullOrWhiteSpace(mailItem.Body))
            {
                System.Windows.Forms.MessageBox.Show("The email body is empty.");
                return;
            }

            LoadingForm loadingForm = new LoadingForm("Checking Spelling...");

            try
            {
                SpellCheckService service = new SpellCheckService();

                loadingForm.Show();

                SpellCheckResponse correctedEmail = await service.SpellCheck(mailItem.Body, mailItem.Subject);

                mailItem.Subject = correctedEmail.subject;
                mailItem.Body = correctedEmail.body;
            }

            catch (InvalidOperationException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                loadingForm.Close();
            }
        }

        private async void langConBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();
            if (inspector == null)
            {
                  System.Windows.Forms.MessageBox.Show("Please open a new email before using Language Conversion");
                  return;
            }

            Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;

            if (mailItem == null)
            {
                System.Windows.Forms.MessageBox.Show("The currently open Outlook item is not an email.");
                return;
            }

            if (string.IsNullOrWhiteSpace(mailItem.Subject) && string.IsNullOrWhiteSpace(mailItem.Body))
            {
                System.Windows.Forms.MessageBox.Show("The email's body and subject are empty.");
                return;
            }


            LanguageConversionForm form = new LanguageConversionForm();
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadingForm loadingForm = new LoadingForm("Translating...");
                loadingForm.Show();

                LanguageConversionRequest request = new LanguageConversionRequest()
                {
                    Language = form.SelectedLanguage,
                    Subject = mailItem.Subject,
                    Body = mailItem.Body

                };
                try{
                LanguageConversionService service = new LanguageConversionService();

                LanguageConversionResponse response = await service.LanguageConversion(request);

                mailItem.Body = response.Body;
                    mailItem.Subject = response.Subject;
                }
                catch (InvalidOperationException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {

                    loadingForm.Close();
                }
            }


        }

        private async void repAssistBtn_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.Inspector inspector = Globals.ThisAddIn.Application.ActiveInspector();

            if (inspector == null)
            {
                MessageBox.Show("Please open an email before using Reply Assist.");
                return;
            }

            Outlook.MailItem mailItem = inspector.CurrentItem as Outlook.MailItem;

            if (mailItem == null)
            {
                MessageBox.Show("The currently open Outlook item is not an email.");
                return;
            }


            ReplyAssistForm form = new ReplyAssistForm();
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                repAssistBtn.Enabled = false;
                LoadingForm loadingForm = new LoadingForm("Writing a reply...");
                loadingForm.Show();
                try
                {
                    ReplyAssistRequest request = new ReplyAssistRequest()
                    {
                        MailContent = form.MailContent,
                        Instructions = form.Instructions
                    };

                    ReplyAssistService service = new ReplyAssistService();
                    ReplyAssistResponse response = await service.GenerateReplyAsync(request);

                    Outlook.MailItem replyItem = mailItem.Reply();

                    replyItem.Body = response.Reply;

                    replyItem.Display();
                }

                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    loadingForm.Close();
                    repAssistBtn.Enabled = true;
                }

            }
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
