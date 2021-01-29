using BitcoinBlockexplorer.Helper;
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
    }
}
