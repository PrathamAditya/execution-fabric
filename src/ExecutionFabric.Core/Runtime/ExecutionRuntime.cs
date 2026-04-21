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
        public async Task<ExecutionResult> Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Router router = new Router();
            ExecutionResult  executionResult =  await router.Route(executionContext).Execute(executionUnit, executionContext);
            return executionResult;
        }
    }
}
