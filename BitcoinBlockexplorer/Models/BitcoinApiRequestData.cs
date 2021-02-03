using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Models
{
    public class BitcoinApiRequestData
    {
        public string jsonrpc { get; set; }

        public string id { get; set; }

        public string method { get; set; }

        public List<string> Params { get; set; }
    }
}
