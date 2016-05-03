using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectedGraph.Input_Manager.Input_Validator
{
    public class RegexValidator : IValidator
    {
        private string validationFormat;
        public RegexValidator()
        {
            this.validationFormat = ConfigurationManager.AppSettings["ValidationHelper"];
        }

        public bool Validate(string item)
        {
            Match matcher = Regex.Match(item, validationFormat);
            return matcher.Success;
        }
    }
}
