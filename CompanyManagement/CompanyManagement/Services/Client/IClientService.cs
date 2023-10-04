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
    }
}
