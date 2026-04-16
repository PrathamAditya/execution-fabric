using ExecutionFabric.Abstractions;
using ExecutionFabric.Core;

namespace ConsoleTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var _ = new DefaultExecutor();

            ExecutionFabric.Abstractions.ExecutionContext executionContext = new ExecutionFabric.Abstractions.ExecutionContext();
            executionContext.ExecutionType = "local";

            PrintMessageUnit printMessageUnit = new PrintMessageUnit();
            var result = _.Execute(printMessageUnit, executionContext);
            Console.WriteLine(result.responseMessage);
            Console.WriteLine(result.success);
        }
    }
}
