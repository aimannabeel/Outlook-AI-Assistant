using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OutlookAddIn1
{
    public class LanguageConversionService
    {
        private readonly GeminiService geminiService;

        public LanguageConversionService()
        {
            geminiService = new GeminiService();
        }

        public async Task<LanguageConversionResponse> LanguageConversion(LanguageConversionRequest request)
        {
            string prompt = $"Translate the following email into {request.Language}. Preserve the original meaning, tone, wording style, and structure as much as possible. Do not add or remove information. Translate both the subject and body. If either field is empty, keep it empty. Return ONLY raw valid JSON with no Markdown, code blocks, backticks, explanations, or additional text, using exactly this format: {{\"Subject\":\"translated subject\",\"Body\":\"translated body\"}}. Subject: {request.Subject}. Body: {request.Body}";

            string generatedText = await geminiService.PromptProcessor(prompt);

            JavaScriptSerializer serializer = new JavaScriptSerializer();


            LanguageConversionResponse response = serializer.Deserialize<LanguageConversionResponse>(generatedText);

            return response;
        }

    }
}
