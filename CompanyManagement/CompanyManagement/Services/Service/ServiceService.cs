using CompanyManagement.Constants;
using CompanyManagement.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace CompanyManagement.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly HttpClient _httpClient;

        public ServiceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(NameHttpClient.CompanyManagementAPI);
        }

        /// <inheritdoc/>
        public async Task<(int statusCode, IEnumerable<ServiceModel> createdServices)> CreateAsync(IEnumerable<ServiceModel> serviceModels)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(ServiceApiEndpoints.CreationEndpoint, serviceModels);

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ServiceModel>());

                var createdServices = await response.Content.ReadFromJsonAsync<IEnumerable<ServiceModel>>();

                return (StatusCodes.Status201Created, createdServices ?? Enumerable.Empty<ServiceModel>());

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ServiceModel>());
            }
        }
        
        /// <inheritdoc/>
        public async Task<(int statusCode, IEnumerable<ServiceModel> services)> GetAsync()
        {
            try
            {
                var services = await _httpClient.GetFromJsonAsync<IEnumerable<ServiceModel>>(ServiceApiEndpoints.GetEndpoint);

                return (StatusCodes.Status200OK, services ?? Enumerable.Empty<ServiceModel>());

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, Enumerable.Empty<ServiceModel>());
            }
        }

        /// <inheritdoc/>
        public async Task<(int statusCode, ServiceModel? updatedService)> UpdateAsync(ServiceModel serviceModel)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync(ServiceApiEndpoints.UpdateEndpoint, serviceModel);

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, null);

                var updatedService = await response.Content.ReadFromJsonAsync<ServiceModel>();

                return (StatusCodes.Status201Created, updatedService ?? new());
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, null);
            }
        }
        
        /// <inheritdoc/>
        public async Task<(int statusCode, string? deletedServiceId)> DeleteAsync(string serviceId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(ServiceApiEndpoints.GetDeleteEndpoint(serviceId));

                if (!response.IsSuccessStatusCode) return (StatusCodes.Status500InternalServerError, null);

                return (StatusCodes.Status200OK, serviceId);

            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error {ex.Message}");
                return (StatusCodes.Status500InternalServerError, null);
            }
        }
    }
}
