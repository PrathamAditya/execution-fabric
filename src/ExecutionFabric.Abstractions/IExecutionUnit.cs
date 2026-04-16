namespace ExecutionFabric.Abstractions;

public interface IExecutionUnit
{
    ExecutionResult Execute(ExecutionContext executionContext);
}
