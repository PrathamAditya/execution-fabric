

using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core.Workflow
{
    public class WorkflowUnit
    {
        private readonly List<IExecutionUnit> _steps;
        public IReadOnlyList<IExecutionUnit> Steps => _steps;

        public WorkflowUnit()
        {
            _steps = new List<IExecutionUnit>();
        }

        public void AddStep(IExecutionUnit step)
        {
            _steps.Add(step);
        }
    }
}
