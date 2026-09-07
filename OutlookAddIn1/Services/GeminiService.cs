using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace OutlookAddIn1
{
    public class GeminiService
    {
        private readonly string apiKey;
        private readonly string endpoint;
        private readonly HttpClient httpClient;

        public GeminiService(){
            apiKey = ConfigurationManager.AppSettings["GeminiApiKey"];
            endpoint = ConfigurationManager.AppSettings["GeminiEndpoint"];

            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> PromptProcessor(string prompt)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("Gemini API key is missing.");
            }

            var requestBody = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new
                    {
                        text = prompt
                    }
                }
            }
        }
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string json = serializer.Serialize(requestBody);

            StringContent content =
                new StringContent(json, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Remove("x-goog-api-key");
            httpClient.DefaultRequestHeaders.Add("x-goog-api-key", apiKey);

            try
            {
                HttpResponseMessage response =
                    await httpClient.PostAsync(endpoint, content);

                string responseJson =
                    await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new InvalidOperationException(
                        "The Gemini API key is invalid or does not have permission."
                    );
                }

                if ((int)response.StatusCode == 429)
                {
                    throw new InvalidOperationException(
                        "Gemini API quota or rate limit has been reached."
                    );
                }

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(
                        $"Gemini API request failed with status code {(int)response.StatusCode}."
                    );
                }

                var responseData =
                    serializer.Deserialize<dynamic>(responseJson);

                string generatedText =
                    responseData["candidates"][0]["content"]["parts"][0]["text"];

                if (string.IsNullOrWhiteSpace(generatedText))
                {
                    throw new InvalidOperationException(
                        "Gemini returned an empty response."
                    );
                }

                return generatedText;
            }
            catch (TaskCanceledException)
            {
                throw new InvalidOperationException(
                    "The Gemini API request timed out."
                );
            }
            catch (HttpRequestException)
            {
                throw new InvalidOperationException(
                    "Unable to connect to Gemini. Please check your internet connection."
                );
            }
        }
    }
}
