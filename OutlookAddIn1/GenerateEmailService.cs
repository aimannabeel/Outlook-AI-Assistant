using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace OutlookAddIn1
{
    public class GenerateEmailService
    {

        private readonly GeminiService geminiService;

        public GenerateEmailService()
        {
            geminiService = new GeminiService();
        }

        public async Task<EmailGenerationResponse> GenerateEmail(EmailGenerationRequest request)
        {

            string prompt = $"Generate a {request.Tone}, {request.Length} email. Instructions: {request.Instructions}. Return only valid JSON in this exact format:{{\"Subject\":\"email subject\",\"Body\":\"email body\"}}";

            string generatedText = await geminiService.PromptProcessor(prompt);

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            EmailGenerationResponse emailResponse = serializer.Deserialize<EmailGenerationResponse>(generatedText);

            return emailResponse;


        }
    }
}
