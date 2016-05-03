using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectedGraph.Algorithm_Manager
{
    public class UgurDijkstraProvider : IDijkstraProvider
    {
        public int FindDirectDistance(Node startNode, Node endNode)
        {
            var query1 = startNode.Edges.Where(x => x.Target.Name.Equals(endNode.Name));
            return query1.Count() > 0 ? query1.First().Length : -1;
        }

        public int FindDistance(string route, List<Node> graph)
        {
            var cities = route.Split('-');
            var searchGraph = new List<Node>();
            List<int> distances = new List<int>();
            foreach (var city in cities)
            {
                foreach(var node in graph)
                {
                    if (node.Name.Equals(city))
                    {
                        searchGraph.Add(node);
                    }
                }
            }

            for (int i = 0; i<searchGraph.Count -1; i++)
            {
                distances.Add(FindDirectDistance(searchGraph.ElementAt(i), searchGraph.ElementAt(i + 1)));
            }
            if (distances.Contains(-1))
                return -1;
            else
                return distances.Sum();
        }

        public int FindNumberOfRoutesLessThanInteger(string start, string end, List<Node> graph, int targetCount)
        {
            Node startNode = null;
            Node endNode = null;
            var finishedRoutes = 0;

            foreach (var node in graph)
            {
                if (node.Name == start)
                    startNode = node;

                if (node.Name == end)
                    endNode = node;
            }

            if (startNode == null || endNode == null)
                return -1;

            var searchGraph = new List<List<Node>>
            {
                new List<Node>()
                {
                    startNode
                }
            };

            while (searchGraph.Count > finishedRoutes)
            {
                finishedRoutes = 0;
                var listCount = searchGraph.Count;
                for (int l = 0; l < listCount; l++)
                {
                    var isFinished = true;
                    var lastElement = searchGraph[l].Last();
                    var lastListCount = searchGraph[l].Count;
                    for (int j = 0; j < lastElement.Edges.Count; j++)
                    {
                        var routeCount = 0;
                        for (int i = 0; i < lastListCount - 1; i++)
                        {
                            var edge =
                                searchGraph[l][i].Edges.FirstOrDefault(x => x.Target.Equals(searchGraph[l][i + 1]));
                            routeCount += edge.Length;
                        }

                        if (routeCount + lastElement.Edges[j].Length >= targetCount)
                            continue;

                        if (isFinished == true)
                        {
                            searchGraph[l].Add(lastElement.Edges[j].Target);
                            isFinished = false;
                        }
                        else
                        {
                            searchGraph.Add(new List<Node>());
                            for (int k = 0; k < lastListCount; k++)
                            {
                                searchGraph.Last().Add(searchGraph[l][k]);
                            }
                            searchGraph.Last().Add(lastElement.Edges[j].Target);
                        }
                    }
                    if (isFinished)
                        finishedRoutes++;
                }
            }

            List<string> routes = new List<string>();

            var count = 0;
            foreach (var nodes in searchGraph)
            {
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (nodes[i].Equals(endNode))
                    {
                        var route = "";

                        for (int j = 0; j < i + 1; j++)
                        {
                            route += nodes[j].Name;
                        }

                        if (!routes.Contains(route))
                        {
                            routes.Add(route);
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public int FindNumberOfRoutesExactlyIntegerStops(string start, string end, List<Node> graph, int targetStop)
        {
            Node startNode = null;
            Node endNode = null;

            foreach (var node in graph)
            {
                if (node.Name == start)
                    startNode = node;

                if (node.Name == end)
                    endNode = node;
            }

            if (startNode == null || endNode == null)
                return -1;

            var searchGraph = new List<List<Node>>
            {
                new List<Node>()
                {
                    startNode
                }
            };

            for (int i = 0; i < targetStop; i++)
            {
                var listCount = searchGraph.Count;
                for (int l = 0; l < listCount; l++)
                {
                    var lastElement = searchGraph[l].Last();
                    for (int j = 0; j < lastElement.Edges.Count; j++)
                    {
                        if (j == 0)
                        {
                            searchGraph[l].Add(lastElement.Edges[j].Target);
                        }
                        else
                        {
                            searchGraph.Add(new List<Node>());
                            for (int k = 0; k < searchGraph[l].Count - 1; k++)
                            {
                                searchGraph.Last().Add(searchGraph[l][k]);
                            }
                            searchGraph.Last().Add(lastElement.Edges[j].Target);
                        }
                    }
                }
            }

            var count = 0;
            foreach (var nodes in searchGraph)
            {
                if (nodes.Count == targetStop + 1)
                {
                    if (nodes.Last().Equals(endNode))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int FindNumberOfRoutesLessThanIntegerStops(string start, string end, List<Node> graph, int targetStop)
        {
            Node startNode = null;
            Node endNode = null;

            foreach (var node in graph)
            {
                if (node.Name == start)
                    startNode = node;

                if (node.Name == end)
                    endNode = node;
            }

            if (startNode == null || endNode == null)
                return -1;

            var searchGraph = new List<List<Node>>
            {
                new List<Node>()
                {
                    startNode
                }
            };

            for (int i = 0; i < targetStop; i++)
            {
                var listCount = searchGraph.Count;
                for (int l = 0; l < listCount; l++)
                {
                    var lastElement = searchGraph[l].Last();
                    for (int j = 0; j < lastElement.Edges.Count; j++)
                    {
                        if (j == 0)
                        {
                            searchGraph[l].Add(lastElement.Edges[j].Target);
                        }
                        else
                        {
                            searchGraph.Add(new List<Node>());
                            for (int k = 0; k < searchGraph[l].Count - 1; k++)
                            {
                                searchGraph.Last().Add(searchGraph[l][k]);
                            }
                            searchGraph.Last().Add(lastElement.Edges[j].Target);
                        }
                    }
                }
            }

            List<string> routes = new List<string>();

            var count = 0;
            foreach (var nodes in searchGraph)
            {
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (nodes[i].Equals(endNode))
                    {
                        var route = "";

                        for (int j = 0; j < i + 1; j++)
                        {
                            route += nodes[j].Name;
                        }

                        if (!routes.Contains(route))
                        {
                            routes.Add(route);
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public int FindShortestPath(string start, string end, List<Node> graph)
        {
            Node startNode = null;
            Node endNode = null;

            foreach (var node in graph)
            {
                if (node.Name == start)
                    startNode = node;

                if (node.Name == end)
                    endNode = node;
            }
            if (startNode == null || endNode == null)
                return -1;

            var searchGraph = new List<Node>();
            int[] distances = new int[graph.Count];

            for (int i = 0; i < graph.Count; i++)
            {
                distances[i] = Int32.MaxValue;
                searchGraph.Add(graph[i]);
            }

            distances[startNode.Index] = 0;

            while (searchGraph.Count > 0)
            {
                var minIndex = searchGraph[0].Index;
                foreach (var node1 in searchGraph)
                {
                    if (distances[node1.Index] < distances[minIndex])
                        minIndex = node1.Index;
                }

                var node = searchGraph.FirstOrDefault(x => x.Index == minIndex);
                searchGraph.Remove(node);

                foreach (var edge in node.Edges)
                {
                    var alt = distances[minIndex] + edge.Length;
                    if (alt < distances[edge.Target.Index])
                        distances[edge.Target.Index] = alt;
                }
            }

            return distances[endNode.Index];
        }
    }
}
