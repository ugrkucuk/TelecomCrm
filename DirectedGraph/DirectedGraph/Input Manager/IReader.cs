﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DirectedGraph.Algorithm_Manager;

namespace DirectedGraph.Input_Manager
{
    public interface IReader
    {
        List<Node> Read();
    }
}
