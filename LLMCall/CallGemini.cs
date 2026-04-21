using System.Net.Http;
using System.Text;
using System.Text.Json;
using Google.GenAI;
using Tools;


namespace LLMCall
{
    public class CallGemini
    {
        public static async Task Main()
        {
            var apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            var httpClient = new HttpClient();
            var requestBody = new
            {
                contents = new[]
                {
                    new
                        {
                            role = "user",
                            parts = new[] { new { text = "What time is it?" } }
                        }
                        
                },
                tools = new[]
                {
                    new
                    {function_declarations = new[]
                    {
                        new
                        {
                            name = "get_time",
                            description = "Returns the current system time",
                            // If your function has NO parameters, you can omit the properties 
                            // or pass an empty object.
                            parameters = new
                            {
                                type = "OBJECT",
                                properties = new { },
                                required = new string[] { }
                            }
                        }
                    }
        }
    },
                // Optional: Force the model to use the tool
                //toolConfig = new
                //{
                //    functionCallingConfig = new { mode = "AUTO" }
                //}
            };
         

            var json = JsonSerializer.Serialize(requestBody, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var response = await httpClient.PostAsync(
                $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent?key={apiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            // Function name extraction

            var doc = JsonDocument.Parse(response.Content.ReadAsStringAsync().Result);

            var root = doc.RootElement;

            var functionCall = root
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("functionCall");

            var functionName = functionCall.GetProperty("name").GetString();

            // args is an object → convert to string
            var argsJson = functionCall.GetProperty("args").GetRawText();

            var tool = new GetDateTool();

            var resultFromTool = tool.Execute(argsJson);

            var followUpRequest = new
            {
                contents = new object[]
    {
        new
        {
            role = "user",
            parts = new[] { new { text = "What time is it?" } }
        },
        new
        {
            role = "model",
            parts = new object[]
            {
                new
                {
                    functionCall = new
                    {
                        name = "get_time",
                        args = new { }
                    }
                }
            }
        },
        new
        {
            role = "function",
            parts = new object[]
            {
                new
                {
                    functionResponse = new
                    {
                        name = "get_time",
                        response = new
                        {
                            result = resultFromTool
                        }
                    }
                }
            }
        }
    }
            };

            json = JsonSerializer.Serialize(followUpRequest, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var response2 = await httpClient.PostAsync(
                $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash-lite:generateContent?key={apiKey}",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            var result = await response2.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
