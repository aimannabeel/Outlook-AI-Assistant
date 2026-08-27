using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutlookAddIn1
{
    public class SpellCheckService
    {
        private readonly GeminiService geminiService;

        public SpellCheckService()
        {
            geminiService = new GeminiService();
        }
        public async Task<string> SpellCheck(string emailBody)
        {
            string prompt = $"Correct the spelling, grammar, and punctuation in the following email. Preserve the original meaning, tone, wording style, and structure as much as possible. Do not add new information. Return only the corrected email body with no explanation. Email: {emailBody}";

            return await geminiService.PromptProcessor(prompt);
        }

    }
}
