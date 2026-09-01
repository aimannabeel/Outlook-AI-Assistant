using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlookAddIn1
{
    public class ChatbotService
    {
        private readonly GeminiService service;

        public ChatbotService()
        {
            service = new GeminiService();
        }

        public async Task<string> GenerateReplyAsync(List<ChatMessage> chatHistory)
        {
            string conversation = "";

            foreach (ChatMessage message in chatHistory) {
                conversation += $"{message.Role}: {message.Content}\n";
            }

            string prompt = $"You are a helpful AI chatbot. Continue the following conversation and respond to the latest user message. Use the previous messages as context. Return only your response to the user, with no role labels or additional formatting.\n\n Conversation:\n{conversation}";

            string generatedText = await service.PromptProcessor(prompt);

            return generatedText;
        }
    }

}
