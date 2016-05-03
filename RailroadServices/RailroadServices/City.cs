using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadServices
{
    public class City
    {
        public string name;
        public IList<Edge> routes = new List<Edge>();
    }
}
