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

        #endregion Methods
    }
}
