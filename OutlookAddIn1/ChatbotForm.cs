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
    public partial class ChatbotForm : Form
    {
        private ChatSession chatSession;
        public ChatbotForm()
        {
            InitializeComponent();
            chatSession = new ChatSession();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrWhiteSpace(messageInputBox.Text))
            {
                System.Windows.Forms.MessageBox.Show("Message Can Not be Empty");
                return;
            }

            ChatMessage message = new ChatMessage()
            {
                Role = "user",
                Content = messageInputBox.Text,
            };

            chatSession.ChatMessageHistory.Add(message);
            chatHistoryBox.AppendText($"You: {message.Content}\n");
            messageInputBox.Clear();

            ChatbotService service = new ChatbotService();

            chatHistoryBox.AppendText("AI: Thinking...");

            try
            {
                string aiResponse = await service.GenerateReplyAsync(chatSession.ChatMessageHistory);

                ChatMessage aiMessage = new ChatMessage()
                {
                    Role = "assistant",
                    Content = aiResponse,
                };

                chatHistoryBox.Text = chatHistoryBox.Text.Replace("AI: Thinking...", "");
                chatSession.ChatMessageHistory.Add(aiMessage);
                chatHistoryBox.AppendText($"AI: {aiMessage.Content}\n\n");
            }
            catch (Exception ex) {
                chatHistoryBox.Text =
                chatHistoryBox.Text.Replace("AI: Thinking...", "");

                MessageBox.Show(ex.Message);
            }
        }

        private void newChatBtn_Click(object sender, EventArgs e)
        {
            chatHistoryBox.Clear();
            chatSession.ChatMessageHistory.Clear();
        }
    }
}
