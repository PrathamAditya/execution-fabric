using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionFabric.Abstractions
{
    public interface IExecutor
    {
        Task<ExecutionResult> Execute(IExecutionUnit executionUnit, ExecutionContext executionContext);
    }
}
