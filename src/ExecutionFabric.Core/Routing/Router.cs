using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ExecutionFabric.Core.Executors;

namespace ExecutionFabric.Core.Routing
{
    public class Router
    {
        public IExecutor Route(Abstractions.ExecutionContext executionContext)
        {
            switch (executionContext.ExecutionType)
            {
                case "local":
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Routing to local");
                    return new LocalExecutor();
                case "http":
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Routing to http");
                    return new HttpExecutor();
                case "ai":
                    Console.WriteLine($"[{executionContext.CorrelationId}]: Routing to AI");
                    return new SemanticKernelExecutor();
                default:
                    Console.WriteLine($"Unknown execution type. Defaulting to local execution with CorrelationId: {executionContext.CorrelationId}");
                    IExecutor defaultExecutor = new MockExecutor();
                    return defaultExecutor;
            }
        }
    }
}
