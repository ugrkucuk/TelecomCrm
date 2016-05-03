using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectedGraph.Input_Manager;
using DirectedGraph.Output_Manager;

namespace DirectedGraph.Algorithm_Manager
{
    public class DijkstraManager
    {
        private IDijkstraProvider dijkstraProvider;
        private List<Node> graph;
        private IReader reader;
        private IWriter writer;
        private List<string> resultList = new List<string>();

        public DijkstraManager(IDijkstraProvider dijkstraProvider, IReader reader, IWriter writer)
        {
            this.dijkstraProvider = dijkstraProvider;
            this.reader = reader;
            this.writer = writer;
            this.Execute();
        }

        public void Execute()
        {
            graph = reader.Read();

            var result1 = dijkstraProvider.FindDistance("A-B-C", graph);
            resultList.Add(result1.ToString());
            var result2 = dijkstraProvider.FindDistance("A-D", graph);
            resultList.Add(result2.ToString());
            var result3 = dijkstraProvider.FindDistance("A-D-C", graph);
            resultList.Add(result3.ToString());
            var result4 = dijkstraProvider.FindDistance("A-E-B-C-D", graph);
            resultList.Add(result4.ToString());
            var result5 = dijkstraProvider.FindDistance("A-E-D", graph);
            resultList.Add(result5.ToString());
            var result6 = dijkstraProvider.FindNumberOfRoutesLessThanIntegerStops("C", "C", graph, 3);
            resultList.Add(result6.ToString());
            var result7 = dijkstraProvider.FindNumberOfRoutesExactlyIntegerStops("A", "C", graph, 4);
            resultList.Add(result7.ToString());
    //        var result8 = dijkstraProvider.FindShortestPath("A", "C", graph);
      //      resultList.Add(result8.ToString());
            var result9 = dijkstraProvider.FindShortestPath("B", "B", graph);
            resultList.Add(result9  .ToString());
            var result10 = dijkstraProvider.FindNumberOfRoutesLessThanInteger("C", "C", graph, 30);
            resultList.Add(result10.ToString());
            writer.Write(resultList);
        }
    }
}
