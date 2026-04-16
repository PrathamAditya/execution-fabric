using System;
using System.Collections.Generic;
using System.Text;

namespace ExecutionFabric.Abstractions
{
   
    public class ExecutionContext
    {
        public Guid CorrelationId = Guid.NewGuid();
        public string ExecutionType = "mock";  // Default;
    }
}
