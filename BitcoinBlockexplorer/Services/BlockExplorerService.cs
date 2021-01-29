using BitcoinBlockexplorer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BitcoinBlockexplorer.Models;
using Newtonsoft.Json;
using System.Text;

namespace BitcoinBlockexplorer.Services
{
    public class BlockExplorerService : IBlockExplorerService
    {
        #region Fields

        private readonly HttpClient _httpClient;

        #endregion Fields

        #region Constructors

        public BlockExplorerService()
        {
            var baseAddress = BlockchainHostConfiguration.Host + ":" + BlockchainHostConfiguration.Port;
            var user = BlockchainHostConfiguration.Username + ":" + BlockchainHostConfiguration.Password;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(user)));
        }

        #endregion Constructors

        #region Methods

        public async Task<string> GetResultsFromHost(string queryJson)
        {
            try
            {                
                var queryString = new StringContent(queryJson, Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync("/", queryString);
                var response = await result.Content.ReadAsStringAsync();

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<Block>> GetNLastBlocks(int n, string startingBlockHash)
        {
            var nextBlockHash = startingBlockHash;
            var blocks = new List<Block>();

            while (n > 0)
            {
                Block currentBlock = await GetBlock(nextBlockHash);
                blocks.Add(currentBlock);
                n--;
                nextBlockHash = currentBlock.result.previousblockhash;
            }

            return blocks;
        }

        public async Task<Block> GetBlock(string blockHash)
        {
            try
            {
                var queryString = CreateRequestData("getblock", new List<string> { blockHash });
                var result = await _httpClient.PostAsync("/", queryString);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var blockResponse = JsonConvert.DeserializeObject<Block>(jsonResponse);

                return blockResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        } 
        
        public async Task<List<MempoolEntry>> GetMempoolEntries(List<string> txids)
        {            
            var mempoolEntries = new List<MempoolEntry>();

            foreach (var txid in txids)
            {
                MempoolEntry mempoolEntry = await GetMempoolEntry(txid);
                mempoolEntries.Add(mempoolEntry);
            }           

            return mempoolEntries;
        }

        public async Task<MempoolEntry> GetMempoolEntry(string txid)
        {
            try
            {
                var queryString = CreateRequestData("getmempoolentry", new List<string> { txid });
                var result = await _httpClient.PostAsync("/", queryString);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var blockResponse = JsonConvert.DeserializeObject<MempoolEntry>(jsonResponse);

                return blockResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        private StringContent CreateRequestData(string methodName, List<string> parameters)
        {
            var requestData = new BitcoinApiRequestData()
            {
                Jsonrpc = "1.0",
                Id = "curltest",
                Method = methodName,
                Params = parameters
            };

            var queryJson = JsonConvert.SerializeObject(requestData).ToLower();
            var queryString = new StringContent(queryJson, Encoding.UTF8, "application/json");

            return queryString;
        }

        #endregion Methods
    }
}
