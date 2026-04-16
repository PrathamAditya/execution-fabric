using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core
{
    public class HttpExecutor : IExecutor
    {
        public ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Console.WriteLine($"[{executionContext.CorrelationId}]: START");

            try
            {
                Console.WriteLine($"[{executionContext.CorrelationId}]: Executing");
                Console.WriteLine($"[{executionContext.CorrelationId}]: Printing message from the HTTP execution.");
                Console.WriteLine($"[{executionContext.CorrelationId}]: END");

                return new ExecutionResult(); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{executionContext.CorrelationId}] ERROR: {ex.Message}");

                return new ExecutionResult
                {
                    success = false,
                    responseMessage = ex.Message
                };
            }
        }
    }
}
