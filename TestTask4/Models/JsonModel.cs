using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask4.Models
{
    public class JsonModel
    {
        public DateTime Date { get; set; }
        public DateTime PreviousDate { get; set; }
        public string PreviousURL { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, CurrencyModel> Valute { get; set; }
    }
}
