using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Output_Manager
{
    public interface IWriter
    {
        void Write(List<string> resultlList);
    }
}
