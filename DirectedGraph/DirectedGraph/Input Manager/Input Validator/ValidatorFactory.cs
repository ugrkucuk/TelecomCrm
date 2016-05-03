using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectedGraph.Input_Manager.Input_Validator
{
    public static class ValidatorFactory
    {
        private static IDictionary<string, IValidator> _validators = new Dictionary<string, IValidator>();

        public static IValidator GetValidator(string key = "")
        {
            if (key == "")
            {
                key = ConfigurationManager.AppSettings["ValidatorKey"];
            }
            return _validators[key];
        }

        public static void RegisterValidator(string key, IValidator validator)
        {
            _validators.Add(new KeyValuePair<string, IValidator>(key, validator));
        }
    }
}
