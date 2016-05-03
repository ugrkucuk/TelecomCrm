using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Algorithm_Manager
{
    public class DijkstraProviderFactory
    {
        private static IDictionary<string, IDijkstraProvider> _providers = new Dictionary<string, IDijkstraProvider>();

        public static IDijkstraProvider GetProvider(string key = "")
        {
            if (key == "")
            {
                key = ConfigurationManager.AppSettings["DijkstraProviderKey"];
            }
            return _providers[key];
        }

        public static void RegisterProvider(string key, IDijkstraProvider provider)
        {
            _providers.Add(new KeyValuePair<string, IDijkstraProvider>(key, provider));
        }
    }
}
