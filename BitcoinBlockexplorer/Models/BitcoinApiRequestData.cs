using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Models
{
    public class BitcoinApiRequestData
    {
        public string Jsonrpc { get; set; }

        public string Id { get; set; }

        public string Method { get; set; }

        public string Params { get; set; }
    }
}
