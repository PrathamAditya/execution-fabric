using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionFabric.Abstractions
{
    public interface IExecutor
    {
        ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext);
    }
}
