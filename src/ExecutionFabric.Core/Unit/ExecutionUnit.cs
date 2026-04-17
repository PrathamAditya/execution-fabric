using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core.Unit;

public class ExecutionUnit : IExecutionUnit
{
    public string Message { get; }

    public ExecutionUnit(string message)
    {
        Message = message;
    }

    public ExecutionResult Execute(Abstractions.ExecutionContext executionContext)
    {
        Console.WriteLine($"[{executionContext.CorrelationId}]: {Message}");

        return new ExecutionResult
        {
            success = true,
            responseMessage = $"Printed: {Message}"
        };
    }
}
