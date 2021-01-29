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

        public async Task<string> GetRawTransaction(string methodName, List<string> parameters)
        {
            try
            {                
                var queryString = CreateRequestData(methodName, parameters);
                var result = await _httpClient.PostAsync("/", queryString);
                var response = await result.Content.ReadAsStringAsync();

                return response;
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
