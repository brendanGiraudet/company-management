using CompanyManagement.Models;

namespace CompanyManagement.Services.Client
{
    public interface IClientService
    {
        /// <summary>
        /// Client creation
        /// </summary>
        /// <param name="clientModels"></param>
        /// <returns></returns>
        Task<(int statusCode, IEnumerable<ClientModel> createdClients)> CreateAsync(IEnumerable<ClientModel> clientModels);

        /// <summary>
        /// Get clients
        /// </summary>
        /// <param name="clientModels"></param>
        /// <returns></returns>
        Task<(int statusCode, IEnumerable<ClientModel> clients)> GetAsync();
        
        /// <summary>
        /// Update client
        /// </summary>
        /// <param name="clientModel"></param>
        /// <returns></returns>
        Task<(int statusCode, ClientModel? updatedClient)> UpdateAsync(ClientModel clientModel);
        
        /// <summary>
        /// Delete client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        Task<(int statusCode, string? deletedClientId)> DeleteAsync(string clientId);
    }
}
