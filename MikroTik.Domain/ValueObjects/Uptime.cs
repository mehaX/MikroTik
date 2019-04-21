using MikroTik.Domain.Enumerations;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MikroTik.Domain.ValueObjects
{
    public class Uptime
    {
        private static Regex Regex = new Regex("([0-9]+)([a-z])");
        public string FullValue;
        public Dictionary<UptimeType, int> Values { get; private set; }

        public Uptime(string value)
        {
            FullValue = value;

            Values = new Dictionary<UptimeType, int>();

            //var match = Regex.Match(value);
            //if (match.Success)
            //{
                
            //}
        }
    }
}
