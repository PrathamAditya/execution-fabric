using ExecutionFabric.Abstractions;
using ExecutionFabric.Core.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core.Runtime
{
    public class ExecutionRuntime
    {
        public static ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Router router = new Router();
            ExecutionResult  executionResult =  router.Route(executionContext).Execute(executionUnit, executionContext);
            return executionResult;
        }
    }
}
