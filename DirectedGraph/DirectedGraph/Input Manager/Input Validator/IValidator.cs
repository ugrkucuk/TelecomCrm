using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Input_Manager
{
    public interface IValidator
    {
        bool Validate(string item);
    }
}
