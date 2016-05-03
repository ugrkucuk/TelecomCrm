using System.Collections.Generic;
using System.Configuration;

namespace DirectedGraph.Output_Manager
{
    public static class WriterFactory
    {
        private static readonly IDictionary<string, IWriter> _writers = new Dictionary<string, IWriter>();

        public static IWriter GetWriter(string key = "")
        {
            if (key == "")
            {
                key = ConfigurationManager.AppSettings["WriterKey"];
            }
            return _writers[key];
        }

        public static void RegisterWriter(string key, IWriter writer)
        {
            _writers.Add(new KeyValuePair<string, IWriter>(key, writer));
        }
    }
}