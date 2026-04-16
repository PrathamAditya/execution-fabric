using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core;

public class PrintMessageUnit: IExecutionUnit
{
    public ExecutionResult Execute(Abstractions.ExecutionContext executionContext)
    {
        string responseMessage = "Printed message successfully";
        Console.WriteLine($"[{executionContext.CorrelationId}]: Printing Method");
        return new ExecutionResult()
        {
            success = true,
            responseMessage = responseMessage
        };
    }
}
