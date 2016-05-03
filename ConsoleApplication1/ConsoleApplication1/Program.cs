using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods m = new Methods();
            m.initEventList();
            m.createNDayCalendar(2);
            Console.ReadKey(true);
        }
    }
}
