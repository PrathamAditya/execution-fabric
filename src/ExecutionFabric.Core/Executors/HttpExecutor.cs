using ExecutionFabric.Abstractions;
using ExecutionFabric.Core.Unit;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core.Executors
{
    public class HttpExecutor : IExecutor
    {
        public ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Console.WriteLine($"[{executionContext.CorrelationId}]: START");

            try
            {
                Console.WriteLine($"[{executionContext.CorrelationId}]: Executing HTTP request");

                if (executionUnit is ExecutionUnit messageUnit)
                {
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Sending HTTP request with payload: {messageUnit.Message}");
                }
                else
                {
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Unknown unit type for HTTP execution");
                }

                Console.WriteLine($"[{executionContext.CorrelationId}]: END");

                return new ExecutionResult
                {
                    success = true,
                    responseMessage = "HTTP request simulated successfully"
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