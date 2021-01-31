using BitcoinBlockexplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinBlockexplorer.Services.Interfaces
{
    public interface IBlockExplorerService
    {
        Task<string> GetResultsFromHost(string queryJson);
        Task<List<Block>> GetNLastBlocks(int n, string startingBlockHash);
        Task<Block> GetBlock(string blockHash);
        Task<List<MempoolEntry>> GetMempoolEntries(List<string> txids);
        Task<MempoolEntry> GetMempoolEntry(string txid);
        Task<List<Transaction>> GetTransactions(List<string> txids);
        Task<Transaction> GetTransaction(string txid);
        Task<string> GetAdditionalTxInfo(string txid);
    }
}
