using ExecutionFabric.Abstractions;
using ExecutionFabric.Core;
using ExecutionFabric.Core.Runtime;
using LLMCall;

namespace ConsoleTestApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //static void Iteration1Test()
            //{
            //    var _ = new DefaultExecutor();
            //    ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();
            //    executionContext.ExecutionType = "local";
            //    //ExecutionUnit printMessageUnit = new ExecutionUnit();
            //    var result = _.Execute(printMessageUnit, executionContext);
            //    Console.WriteLine(result.responseMessage);
            //    Console.WriteLine(result.success);
            //}

            //static void Iteration2Test()
            //{
            //    IExecutionUnit printMessageUnit = new ExecutionUnit();
            //    ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();

            //    var router = new Router();
            //    IExecutor executor = router.Route(executionContext);
            //    var executionResult = executor.Execute(printMessageUnit, executionContext);
            //    Console.WriteLine(executionResult.success);
            //    Console.WriteLine(executionResult.responseMessage);
                
            //}

            //static void Iteration2Test2()
            //{
            //    IExecutionUnit printMessageUnit = new ExecutionUnit();
            //    ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();

            //    var router = new Router();
            //    IExecutor executor = router.Route(executionContext);
            //    var executionResult = executor.Execute(printMessageUnit, executionContext);
            //    Console.WriteLine(executionResult.success);
            //    Console.WriteLine(executionResult.responseMessage);

            //}
            // Iteration1Test();

            static void Iteration3Test1()
            {
                //IExecutionUnit executionUnit = new ExecutionUnit("Hello");
                //ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();

                //var executionResult = ExecutionRuntime.Execute(executionUnit, executionContext);
                //Console.WriteLine(executionResult.success);
                //Console.WriteLine(executionResult.responseMessage);

                //executionContext.ExecutionType = "local";
                //var executionResult2 = ExecutionRuntime.Execute(executionUnit, executionContext);
                //Console.WriteLine(executionResult2.success);
                //Console.WriteLine(executionResult2.responseMessage);

                //executionContext.ExecutionType = "http";
                //var executionResult3 = ExecutionRuntime.Execute(executionUnit, executionContext);
                //Console.WriteLine(executionResult3.success);
                //Console.WriteLine(executionResult3.responseMessage);

                //IExecutionUnit printMessageUnit = new PrintMessageUnit();
                //ExecutionFabric.Abstractions.ExecutionContext executionPrintContext = new ExecutionFabric.Abstractions.ExecutionContext();
                //executionPrintContext.ExecutionType = "local";

                //IExecutionUnit executionUnit = new MockUnit();
                //ExecutionFabric.Abstractions.ExecutionContext executionDefaultContext = new ExecutionFabric.Abstractions.ExecutionContext();

                //IExecutionUnit httpExecutionUnit = new HttpRequestUnit();
                //ExecutionFabric.Abstractions.ExecutionContext executionHttpContext = new ExecutionFabric.Abstractions.ExecutionContext();
                //executionHttpContext.ExecutionType = "http";




                // var executionResult2 = runtime.Execute(executionUnit, executionDefaultContext);
                // Console.WriteLine(executionResult2.success);
                // Console.WriteLine(executionResult2.responseMessage);

                // var executionResult3 = runtime.Execute(httpExecutionUnit, executionHttpContext);
                // Console.WriteLine(executionResult3.success);
                // Console.WriteLine(executionResult3.responseMessage);
            }

            static async Task TestSemanticKernelExecution()
            {
                IExecutionUnit aiUnit = new AITextUnit("What is the meaning of life?");
                ExecutionFabric.Abstractions.ExecutionContext aiExecutionContext = new ExecutionFabric.Abstractions.ExecutionContext();
                aiExecutionContext.ExecutionType = "ai";
                var executionResult = await ExecutionRuntime.Execute(aiUnit, aiExecutionContext);
                Console.WriteLine(executionResult.success);
                Console.WriteLine(executionResult.responseMessage);
            }

            void TestToolCalling()
            {
                CallGemini.Main().Wait();
            }

            TestToolCalling();
        }
    }
}
