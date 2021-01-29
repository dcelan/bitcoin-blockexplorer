using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Helper
{
    public class Block
    {
        public Result result { get; set; }
        public object error { get; set; }
        public string id { get; set; }
    }

    public class Result
    {
        public string hash { get; set; }
        public long confirmations { get; set; }
        public long strippedsize { get; set; }
        public long size { get; set; }
        public long weight { get; set; }
        public long height { get; set; }
        public long version { get; set; }
        public string versionHex { get; set; }
        public string merkleroot { get; set; }
        public List<string> tx { get; set; }
        public long time { get; set; }
        public long mediantime { get; set; }
        public long nonce { get; set; }
        public string bits { get; set; }
        public double difficulty { get; set; }
        public string chainwork { get; set; }
        public long nTx { get; set; }
        public string previousblockhash { get; set; }
    }
}
