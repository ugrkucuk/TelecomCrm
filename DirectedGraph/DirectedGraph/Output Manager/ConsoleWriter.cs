using System;
using System.Collections.Generic;

namespace DirectedGraph.Output_Manager
{
    public class ConsoleWriter : IWriter
    {
        public void Write(List<string> resultlList)
        {
            foreach (var result in resultlList)
            {
                Console.WriteLine(result + "\n");
            }
            Console.ReadKey();
        }
    }
}
