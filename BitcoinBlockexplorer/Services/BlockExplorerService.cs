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
            var queryString = CreateRequestData("getblock", new List<string> { blockHash });
            var result = await _httpClient.PostAsync("/", queryString);
            var jsonResponse = await result.Content.ReadAsStringAsync();
            var block = JsonConvert.DeserializeObject<Block>(jsonResponse);

            if (block.error != null)
                throw new Exception(jsonResponse);

            return block;
        }

        public async Task<List<Transaction>> GetTransactions(List<string> txids)
        {
            var transactions = new List<Transaction>();

            foreach (var txid in txids)
            {
                Transaction transaction = await GetTransaction(txid);
                transactions.Add(transaction);
            }

            return transactions;
        }

        public async Task<Transaction> GetTransaction(string txid)
        {
            //TODO: Write method that receives different kind of object types into List

            var queryJson = "{\"jsonrpc\":\"1.0\"," +
                "\"id\":\"curltest\"," +
                "\"method\":\"getrawtransaction\"," +
                "\"params\":[\"" + txid + "\",true]}";
            var queryString = new StringContent(queryJson, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync("/", queryString);
            var jsonResponse = await result.Content.ReadAsStringAsync();
            var transaction = JsonConvert.DeserializeObject<Transaction>(jsonResponse);

            if (transaction.error != null)
                throw new Exception(jsonResponse);
            else
                transaction.result.txid = txid;

            return transaction;
        }

        public async Task<string> GetAdditionalTransactionInfo(string txid)
        {
            var response = await GetResultFromBlockChairWebPage("transaction/" + txid);

            return response;
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
            var queryString = CreateRequestData("getmempoolentry", new List<string> { txid });
            var result = await _httpClient.PostAsync("/", queryString);
            var jsonResponse = await result.Content.ReadAsStringAsync();
            var mempoolEntry = JsonConvert.DeserializeObject<MempoolEntry>(jsonResponse);

            if (mempoolEntry.error != null)
                throw new Exception(jsonResponse);
            else
                mempoolEntry.result.txid = txid;

            return mempoolEntry;
        }

        public async Task<AddressInfo> GetAddressInfo(string address)
        {
            var queryString = CreateRequestData("getaddressinfo", new List<string> { address });
            var result = await _httpClient.PostAsync("/", queryString);
            var jsonResponse = await result.Content.ReadAsStringAsync();
            var addressInfo = JsonConvert.DeserializeObject<AddressInfo>(jsonResponse);

            if (addressInfo.error != null)
                throw new Exception(jsonResponse);

            return addressInfo;
        }

        public async Task<string> GetAdditionalAddressInfo(string address)
        {
            var response = await GetResultFromBlockChairWebPage("address/" + address);

            return response;
        }

        private async Task<string> GetResultFromBlockChairWebPage(string request)
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://api.blockchair.com/bitcoin/testnet/dashboards/" + request);
            var jsonResponse = await result.Content.ReadAsStringAsync();

            return jsonResponse;
        }

        private StringContent CreateRequestData(string methodName, List<string> parameters)
        {
            var requestData = new BitcoinApiRequestData()
            {
                jsonrpc = "1.0",
                id = "curltest",
                method = methodName,
                Params = parameters
            };

            var queryJson = JsonConvert.SerializeObject(requestData).Replace("Params", "params");
            var queryString = new StringContent(queryJson, Encoding.UTF8, "application/json");

            return queryString;
        }

        #endregion Methods
    }
}
