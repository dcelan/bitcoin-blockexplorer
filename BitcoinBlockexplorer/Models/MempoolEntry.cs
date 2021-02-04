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
        public long size { get; set; }
        public double fee { get; set; }
        public double modifiedfee { get; set; }
        public long time { get; set; }
        public long height { get; set; }
        public long descendantcount { get; set; }
        public long descendantsize { get; set; }
        public long descendantfees { get; set; }
        public long ancestorcount { get; set; }
        public long ancestorsize { get; set; }
        public long ancestorfees { get; set; }
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
