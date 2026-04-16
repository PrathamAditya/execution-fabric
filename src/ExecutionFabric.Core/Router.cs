using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionFabric.Core
{
    public class Router
    {
        public IExecutor Route(IExecutionUnit executionUnit, Abstractions.ExecutionContext executionContext)
        {
            switch (executionContext.ExecutionType)
            {
                case "local":
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Routing to local");
                    return new LocalExecutor();
                default:
                    Console.WriteLine($"Unknown execution type. Defaulting to local execution with CorrelationId: {executionContext.CorrelationId}");
                    IExecutor defaultExecutor = new DefaultExecutor();
                    return defaultExecutor;
            }
        }
    }
}
