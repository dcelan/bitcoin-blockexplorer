using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Models
{
    public class MempoolEntry
    {
        public MempoolEntryResult result { get; set; }
        public object error { get; set; }
        public string id { get; set; }
    }

    public class MempoolEntryResult
    {
        public Fees fees { get; set; }
        public int size { get; set; }
        public double fee { get; set; }
        public double modifiedfee { get; set; }
        public int time { get; set; }
        public int height { get; set; }
        public int descendantcount { get; set; }
        public int descendantsize { get; set; }
        public int descendantfees { get; set; }
        public int ancestorcount { get; set; }
        public int ancestorsize { get; set; }
        public int ancestorfees { get; set; }
        public string wtxid { get; set; }
        public string txid { get; set; }
        public List<object> depends { get; set; }
        public List<object> spentby { get; set; }
        [JsonProperty("bip125-replaceable")]
        public bool Bip125Replaceable { get; set; }
    }

    public class Fees
    {
        public double @base { get; set; }
        public double modified { get; set; }
        public double ancestor { get; set; }
        public double descendant { get; set; }
    }
}
