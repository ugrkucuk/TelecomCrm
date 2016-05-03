using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Input_Manager
{
    public static class ReaderFactory
    {
        private static IDictionary<string, IReader> _readers = new Dictionary<string, IReader>();

        public static IReader GetReader(string key = "")
        {
            if (key == "")
            {
                key = ConfigurationManager.AppSettings["ReaderKey"];
            }
            return _readers[key];
        }

        public static void RegisterReader(string key, IReader reader)
        {
            _readers.Add(new KeyValuePair<string, IReader>(key, reader));
        }
    }
}
