using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Interface
{
    public interface ITool
    {
        string Name { get; }
        string Description   { get; }
        string Execute(string input);
    }
}
