using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core
{
    public class ExecutionRuntime
    {
        public ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Router router = new Router();
            ExecutionResult  executionResult =  router.Route(executionContext).Execute(executionUnit, executionContext);
            return executionResult;
        }
    }
}
