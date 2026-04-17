using ExecutionFabric.Abstractions;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.Google;
using OpenAI.Models;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core.Executors
{
    public class SemanticKernelExecutor: IExecutor
    {
        private async static Task<ChatMessageContent> CallGemini(string prompt)
        {
            string? apiKey = Environment.GetEnvironmentVariable("GEMINI_API_KEY");
            string model = "gemini-3-flash-preview";
            var builder = Kernel.CreateBuilder();
            builder.AddGoogleAIGeminiChatCompletion(model, apiKey);

            var kernel = builder.Build();
            var chat = kernel.GetRequiredService<IChatCompletionService>();

            var result = await chat.GetChatMessageContentAsync(
                prompt
            );
            return result;
        }
        
        public async Task<ExecutionResult> Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Console.WriteLine($"[{executionContext.CorrelationId}]: START");

            try
            {
                Console.WriteLine($"[{executionContext.CorrelationId}]: Executing AI task");

                if (executionUnit is not AITextUnit aiUnit)
                {
                    return new ExecutionResult
                    {
                        success = false,
                        responseMessage = "Invalid unit for AI execution"
                    };
                }

                var responseFromGemini = await CallGemini(aiUnit.Prompt);
                var response = responseFromGemini.ToString();

                Console.WriteLine($"[{executionContext.CorrelationId}]: END");

                return new ExecutionResult
                {
                    success = true,
                    responseMessage = response
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{executionContext.CorrelationId}] ERROR: {ex.Message}");

                return new ExecutionResult
                {
                    success = false,
                    responseMessage = ex.Message
                };
            }
        }
    }
}