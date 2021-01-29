using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitcoinBlockexplorer.Services.Interfaces;

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

        [HttpPost]
        [Route("getresults")]
        public async Task<ActionResult> GetResultsFromHost (string queryJson)
        {
            var result = await _blockExplorerService.GetResultsFromHost(queryJson);

            return Ok(result);
        }
    }
}
