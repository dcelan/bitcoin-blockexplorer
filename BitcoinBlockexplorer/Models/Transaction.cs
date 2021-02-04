using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Models
{
    public class Transaction
    {
        public TransactionResult result { get; set; }
        public object error { get; set; }
        public string id { get; set; }
    }

    public class TransactionResult
    {
        public string txid { get; set; }
        public string hash { get; set; }
        public long version { get; set; }
        public long size { get; set; }
        public long vsize { get; set; }
        public long weight { get; set; }
        public long locktime { get; set; }
        public List<Vin> vin { get; set; }
        public List<Vout> vout { get; set; }
        public string hex { get; set; }
        public string blockhash { get; set; }
        public long confirmations { get; set; }
        public long time { get; set; }
        public long blocktime { get; set; }
    }

    public class Vin
    {
        public string txid { get; set; }
        public long vout { get; set; }
        public ScriptSig scriptSig { get; set; }
        public long sequence { get; set; }
    }
    public class Vout
    {
        public double value { get; set; }
        public long n { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
    }

    public class ScriptSig
    {
        public string asm { get; set; }
        public string hex { get; set; }
    }

    public class ScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public long reqSigs { get; set; }
        public string type { get; set; }
        public List<string> addresses { get; set; }
    }    
}
