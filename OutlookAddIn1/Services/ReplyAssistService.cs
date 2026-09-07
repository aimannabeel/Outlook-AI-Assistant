using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OutlookAddIn1
{
    
    public class ReplyAssistService
    {
        private readonly GeminiService geminiService;

        public ReplyAssistService()
        {
            geminiService = new GeminiService();
        }

        public async Task<ReplyAssistResponse> GenerateReplyAsync(ReplyAssistRequest request)
        {
            string prompt = $"Generate an appropriate email reply based on the original email and the user's instructions. Preserve the intent of the user's instructions and write a clear, natural, professional email reply. Do not add information that was not provided. Return ONLY raw valid JSON with no Markdown, code blocks, backticks, explanations, or additional text, using exactly this format: {{\"Reply\":\"generated reply\"}}. Original email: {request.MailContent}. Reply instructions: {request.Instructions}";

            string response = await geminiService.PromptProcessor(prompt);

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            ReplyAssistResponse reply = serializer.Deserialize<ReplyAssistResponse>(response);

            return reply;


        }
    }
}
