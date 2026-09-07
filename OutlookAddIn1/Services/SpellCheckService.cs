using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OutlookAddIn1
{
    public class SpellCheckService
    {
        private readonly GeminiService geminiService;

        public SpellCheckService()
        {
            geminiService = new GeminiService();
        }
        public async Task<SpellCheckResponse> SpellCheck(string emailBody, string subject)
        {
            string prompt = $"Correct the spelling, grammar, and punctuation in the following email subject and body. Preserve the original meaning, tone, wording style, and structure as much as possible. Do not add new information. Return only valid JSON in this exact format: {{\"Subject\":\"corrected subject\",\"Body\":\"corrected body\"}}. Do not use Markdown, code blocks, backticks, explanations, or any text before or after the JSON. Email: {emailBody}. Subject: {subject}";

            string generatedText = await geminiService.PromptProcessor(prompt);

            JavaScriptSerializer serializer = new JavaScriptSerializer();


            SpellCheckResponse response = serializer.Deserialize<SpellCheckResponse>(generatedText);

            return response;
        }

    }
}
