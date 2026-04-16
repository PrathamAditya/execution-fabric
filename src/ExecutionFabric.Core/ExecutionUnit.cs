using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core;

public class ExecutionUnit : IExecutionUnit
{
    public ExecutionResult Execute(Abstractions.ExecutionContext executionContext)
    {
        string responseMessage = string.Empty;
        switch (executionContext.ExecutionType)
        {
            case "local":
                responseMessage = "Local routine run successfully";
                Console.WriteLine($"[{executionContext.CorrelationId}]: Printing message from the local execution.");
                break;

            case "http":
                responseMessage = "HTTP routine run successfully";
                Console.WriteLine($"[{executionContext.CorrelationId}]: Http request has been sent.");
                break;
            default:
                responseMessage = "Mock routine run successfully";
                Console.WriteLine($"[{executionContext.CorrelationId}]: Mock Mock request has been sent.");
                break;
        }

        Console.WriteLine($"[{executionContext.CorrelationId}]: DONE");
        return new ExecutionResult()
        {
            success = true,
            responseMessage = responseMessage
        };
    }
}
