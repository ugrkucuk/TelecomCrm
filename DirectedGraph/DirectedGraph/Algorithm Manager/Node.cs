using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Algorithm_Manager
{
    public class Node
    {
        public string Name;

        public List<Edge> Edges = new List<Edge>();

        public int Index;

        public bool Equals(Node a)
        {
            return Name == a.Name;
        }
    }
}
