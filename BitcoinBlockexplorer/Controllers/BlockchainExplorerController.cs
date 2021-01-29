using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitcoinBlockexplorer.Services.Interfaces;
using BitcoinBlockexplorer.Models;

namespace BitcoinBlockexplorer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockchainExplorerController : Controller
    {
        private IBlockExplorerService _blockExplorerService;

        public BlockchainExplorerController(IBlockExplorerService blockExplorerService)
        {
            _blockExplorerService = blockExplorerService;
        }

        [HttpGet]
        [Route("getresultsfromhost")]
        public async Task<ActionResult> GetResultsFromHost (string queryJson)
        {
            var result = await _blockExplorerService.GetResultsFromHost(queryJson);

            return Ok(result);
        }
        
        [HttpGet]
        [Route("getblock")]
        public async Task<Block> GetBlock(string blockHash)
        {
            var result = await _blockExplorerService.GetBlock(blockHash);

            return result;
        }
        
        [HttpGet]
        [Route("getnlastblocks")]
        public async Task<List<Block>> GetNLastBlocks(int numberOfBlocks, string startingBlockHash)
        {
            var result = await _blockExplorerService.GetNLastBlocks(numberOfBlocks, startingBlockHash);

            return result;
        }

        [HttpGet]
        [Route("getmempoolentry")]
        public async Task<MempoolEntry> GetMempoolEntry(string transactionId)
        {
            var result = await _blockExplorerService.GetMempoolEntry(transactionId);

            return result;
        }

        [HttpPost]
        [Route("getmempoolentries")]
        public async Task<List<MempoolEntry>> GetMempoolEntries(List<string> transactionIds)
        {
            var result = await _blockExplorerService.GetMempoolEntries(transactionIds);

            return result;
        }
    }
}
