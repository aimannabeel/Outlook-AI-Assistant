using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

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
            System.Windows.Forms.MessageBox.Show("Generate Email Clicked");
        }

        private void emailSplchkBtn_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("SpellCheck Clicked");
        }

        private void langConBtn_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Language Conversion Clicked");
        }

        private void repAssistBtn_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Reply Assist Clicked");
        }

        private void chatbotBtn_Click(object sender, RibbonControlEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Talk to Chatbot Clicked");
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
