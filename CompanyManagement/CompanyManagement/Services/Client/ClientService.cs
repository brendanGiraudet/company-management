using CompanyManagement.Constants;
using CompanyManagement.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace CompanyManagement.Services.Client
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.CompanyManagementAPI);
        }

        /// <inheritdoc/>
        public async Task<(int statusCode, IEnumerable<ClientModel> createdClients)> CreateAsync(IEnumerable<ClientModel> clientModels)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ClientApiEndpoints.CreationEndpoint, clientModels);

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ClientModel>());

                var createdClients = await response.Content.ReadFromJsonAsync<IEnumerable<ClientModel>>();

                return (StatusCodes.Status201Created, createdClients);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ClientModel>());
            }
        }
        
        /// <inheritdoc/>
        public async Task<(int statusCode, IEnumerable<ClientModel> clients)> GetAsync()
        {
            try
            {
                var clients = await _httpClient.GetFromJsonAsync<IEnumerable<ClientModel>>(ClientApiEndpoints.GetEndpoint);

                return (StatusCodes.Status200OK, clients);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ClientModel>());
            }
        }
    }
}
