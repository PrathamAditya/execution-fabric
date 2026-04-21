
using ExecutionFabric.Core.Runtime;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;
using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core.Workflow
{
    public class WorkflowExecutor
    {
        private readonly ExecutionRuntime executionRuntime;

        public WorkflowExecutor(ExecutionRuntime executionRuntime)
        {
            this.executionRuntime = executionRuntime;
        }
        public async Task<List<ExecutionResult>> Execute(WorkflowUnit workflowUnit, ExecutionContext executionContext)
        {
            List<ExecutionResult> results = new List<ExecutionResult>();
            foreach (var step in workflowUnit.Steps)
            {
                ExecutionResult executionResult = await executionRuntime.Execute(step, executionContext);

                if (executionResult.success == false)
                {
                    break;
                }
                results.Add(executionResult);
            }
            return results;
        }
    }
}
