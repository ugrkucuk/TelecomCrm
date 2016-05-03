using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RailroadServices.Input_Manager
{
    class FileReader : IReader
    {
        public IList<City> read()
        {
            string input = File.ReadAllText(ConfigurationManager.AppSettings["FilePath"]);
            Regex regex = new Regex(ConfigurationManager.AppSettings["ValidationString"]);
            IList<City> graph = new List<City>();
            IList<string> formattedInput = input.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string path in formattedInput)
            {
                if (regex.Match(path).Success)
                {
                    int index = -1;
                    foreach (City node in graph)
                    {
                        if (node.name.Equals(path[0].ToString()))
                        {
                            index = graph.IndexOf(node);
                            break;
                        }
                    }

                    City endCity = new City();
                    endCity.name = path[1].ToString();
                    Edge edge = new Edge();
                    edge.endCity = endCity;
                    edge.length = Int32.Parse(path.Substring(2));

                    if (index != -1)
                    {
                        graph.ElementAt<City>(index).routes.Add(edge);
                    }
                    else
                    {
                        City startCity = new City();
                        startCity.name = path[0].ToString();
                        startCity.routes.Add(edge);
                        graph.Add(startCity);
                    }
                }
            }
            return graph;
        }
    }
}
