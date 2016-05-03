using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Output_Manager
{
    public class FileWriter : IWriter
    {
        private string _outputHelper;

        public FileWriter()
        {
            this._outputHelper = ConfigurationManager.AppSettings["OutputHelper"];
        }

        public void Write(List<string> resultlList)
        {
            var tempString = "";
            foreach (var result in resultlList)
            {
                if (result.Equals("-1"))
                {
                    tempString += "NO SUCH ROUTE \n";
                }
                else
                    tempString += result + "\n";
            }
            File.WriteAllText(_outputHelper, tempString);
        }
    }
}
