using ExecutionFabric.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using ExecutionContext = ExecutionFabric.Abstractions.ExecutionContext;

namespace ExecutionFabric.Core
{
    internal class LocalExecutor : IExecutor
    {
        public ExecutionResult Execute(IExecutionUnit executionUnit, ExecutionContext executionContext)
        {
            Console.WriteLine($"[{executionContext.CorrelationId}]: START");

            try
            {
                Console.WriteLine($"[{executionContext.CorrelationId}]: Executing");

                var result = executionUnit.Execute(executionContext);

                Console.WriteLine($"[{executionContext.CorrelationId}]: END");

                return result;
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
