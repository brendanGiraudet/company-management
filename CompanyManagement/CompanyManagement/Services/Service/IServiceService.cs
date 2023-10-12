using CompanyManagement.Models;

namespace CompanyManagement.Services.Service
{
    public interface IServiceService
    {
        /// <summary>
        /// Service creation
        /// </summary>
        /// <param name="serviceModels"></param>
        /// <returns></returns>
        Task<(int statusCode, IEnumerable<ServiceModel> createdServices)> CreateAsync(IEnumerable<ServiceModel> serviceModels);

        /// <summary>
        /// Get services
        /// </summary>
        /// <returns></returns>
        Task<(int statusCode, IEnumerable<ServiceModel> services)> GetAsync();

        /// <summary>
        /// Update service
        /// </summary>
        /// <param name="serviceModel"></param>
        /// <returns></returns>
        Task<(int statusCode, ServiceModel? updatedService)> UpdateAsync(ServiceModel serviceModel);
        
        /// <summary>
        /// Delete client
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        Task<(int statusCode, string? deletedServiceId)> DeleteAsync(string serviceId);
    }
}
