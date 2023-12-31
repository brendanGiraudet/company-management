﻿using CompanyManagement.Constants;
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

                return (StatusCodes.Status201Created, createdClients ?? Enumerable.Empty<ClientModel>());

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

                return (StatusCodes.Status200OK, clients ?? Enumerable.Empty<ClientModel>());

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ClientModel>());
            }
        }

        /// <inheritdoc/>
        public async Task<(int statusCode, ClientModel? updatedClient)> UpdateAsync(ClientModel clientModel)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(ClientApiEndpoints.UpdateEndpoint, clientModel);

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, null);

                var updatedClient = await response.Content.ReadFromJsonAsync<ClientModel>();

                return (StatusCodes.Status201Created, updatedClient ?? new());

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, null);
            }
        }
        
        /// <inheritdoc/>
        public async Task<(int statusCode, string? deletedClientId)> DeleteAsync(string clientId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(ClientApiEndpoints.GetDeleteEndpoint(clientId));

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, null);

                return (StatusCodes.Status200OK, clientId);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, null);
            }
        }
    }
}
