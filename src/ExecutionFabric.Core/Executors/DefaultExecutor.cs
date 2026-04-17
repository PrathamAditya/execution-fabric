using System;
using System.Collections.Generic;
using System.Text;
using ExecutionFabric.Abstractions;

namespace ExecutionFabric.Core.Executors
{
    public class DefaultExecutor: IExecutor
    {
        public async Task<ExecutionResult> Execute(IExecutionUnit executionUnit, Abstractions.ExecutionContext executionContext)
        {
            //ExecutionResult result = new ExecutionResult();
            //switch (executionContext.ExecutionType)
            //{
            //    case "local":
            //        Console.WriteLine($"[{executionContext.CorrelationId}]: START");
            //        //Console.WriteLine($"Executing locally with CorrelationId: {executionContext.CorrelationId}");
            //        result = executionUnit.Execute(executionContext);
            //        break;
            //    default:
            //        //Console.WriteLine($"Unknown execution type. Defaulting to local execution with CorrelationId: {executionContext.CorrelationId}");
            //        result = executionUnit.Execute(executionContext);
            //        break;
            //}
            //Console.WriteLine($"[{executionContext.CorrelationId}]: END");
            //return result;


            return new ExecutionResult();
            
        }
    }
}
