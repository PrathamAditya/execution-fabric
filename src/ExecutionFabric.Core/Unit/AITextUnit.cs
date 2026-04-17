using ExecutionFabric.Abstractions;

public class AITextUnit : IExecutionUnit
{
    public string Prompt { get; }

    public AITextUnit(string prompt)
    {
        Prompt = prompt;
    }

    public ExecutionResult Execute(ExecutionFabric.Abstractions.ExecutionContext executionContext)
    {
        return new ExecutionResult
        {
            success = false,
            responseMessage = "AI execution must be handled by SemanticKernelExecutor"
        };
    }
}