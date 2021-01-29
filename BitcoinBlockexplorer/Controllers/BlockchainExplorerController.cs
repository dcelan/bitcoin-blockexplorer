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
        [Route("getrawtransaction")]
        public async Task<ActionResult> GetRawTransaction(List<string> parameters)
        {
            var result = await _blockExplorerService.GetRawTransaction("getrawtransaction", parameters);

            return Ok(result);
        }
    }
}
