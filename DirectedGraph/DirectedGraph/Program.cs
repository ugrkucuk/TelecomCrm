using System;
using System.Collections.Generic;
using System.Linq;
using DirectedGraph.Algorithm_Manager;
using DirectedGraph.Input_Manager;
using DirectedGraph.Input_Manager.Input_Validator;
using DirectedGraph.Output_Manager;
using static System.Configuration.ConfigurationManager;

namespace DirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            IDijkstraProvider dijkstraProvider = DijkstraProviderFactory.GetProvider();
            IReader reader = ReaderFactory.GetReader();
            IWriter writer = WriterFactory.GetWriter();

            var dijkstraManager = new DijkstraManager(dijkstraProvider, reader, writer);
        }

        public static void Initialize()
        {
            ReaderFactory.RegisterReader("File", new FileReader());
            ReaderFactory.RegisterReader("Console", new ConsoleReader());
            WriterFactory.RegisterWriter("File", new FileWriter());
            WriterFactory.RegisterWriter("Console", new ConsoleWriter());
            ValidatorFactory.RegisterValidator("Regex", new RegexValidator());
            DijkstraProviderFactory.RegisterProvider("Ugur", new UgurDijkstraProvider());
        }
    }
}
