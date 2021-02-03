using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Models
{
    public class AddressInfo
    {
        public AddressInfoResult result { get; set; }
        public object error { get; set; }
        public string id { get; set; }
    }
    public class AddressInfoResult
    {
        public string address { get; set; }
        public string scriptPubKey { get; set; }
        public bool ismine { get; set; }
        public bool solvable { get; set; }
        public bool iswatchonly { get; set; }
        public bool isscript { get; set; }
        public bool iswitness { get; set; }
        public int witness_version { get; set; }
        public string witness_program { get; set; }
        public bool ischange { get; set; }
        public List<object> labels { get; set; }
    }  
}
