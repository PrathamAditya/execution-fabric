using ExecutionFabric.Abstractions;
using ExecutionFabric.Core;

namespace ConsoleTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Iteration1Test()
            {
                var _ = new DefaultExecutor();
                ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();
                executionContext.ExecutionType = "local";
                PrintMessageUnit printMessageUnit = new PrintMessageUnit();
                var result = _.Execute(printMessageUnit, executionContext);
                Console.WriteLine(result.responseMessage);
                Console.WriteLine(result.success);
            }

            static void Iteration2Test()
            {
                IExecutionUnit printMessageUnit = new PrintMessageUnit();
                ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();

                var router = new Router();
                IExecutor executor = router.Route(printMessageUnit, executionContext);
                var executionResult = executor.Execute(printMessageUnit, executionContext);
                Console.WriteLine(executionResult.success);
                Console.WriteLine(executionResult.responseMessage);
                
            }

            static void Iteration2Test2()
            {
                IExecutionUnit printMessageUnit = new PrintMessageUnit();
                ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();

                var router = new Router();
                IExecutor executor = router.Route(printMessageUnit, executionContext);
                var executionResult = executor.Execute(printMessageUnit, executionContext);
                Console.WriteLine(executionResult.success);
                Console.WriteLine(executionResult.responseMessage);

            }
            //Iteration1Test();
            Iteration2Test();
        }
    }
}
