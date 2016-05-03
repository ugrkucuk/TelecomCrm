using RailroadServices.Input_Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadServices
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fr = new FileReader();
            fr.read();
        }
    }
}
