using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Algorithm_Manager
{
    public interface IDijkstraProvider
    {
        int FindDistance(string route, List<Node> graph);
        int FindNumberOfRoutesLessThanInteger(string start, string end, List<Node> graph, int targetCount);
        int FindNumberOfRoutesExactlyIntegerStops(string start, string end, List<Node> graph, int targetStop);
        int FindNumberOfRoutesLessThanIntegerStops(string start, string end, List<Node> graph, int targetStop);
        int FindShortestPath(string start, string end, List<Node> graph);
    }
}
