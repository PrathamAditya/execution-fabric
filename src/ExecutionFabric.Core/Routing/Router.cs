using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

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
                default:
                    Console.WriteLine($"Unknown execution type. Defaulting to local execution with CorrelationId: {executionContext.CorrelationId}");
                    IExecutor defaultExecutor = new MockExecutor();
                    return defaultExecutor;
            }
        }
    }
}
