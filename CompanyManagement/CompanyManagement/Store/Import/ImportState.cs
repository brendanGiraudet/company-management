using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    [FeatureState]
    public class ImportState
    {
        public bool IsLoading { get; }

        public IEnumerable<ClientModel> CreatedClients { get; } = Enumerable.Empty<ClientModel>();
        
        public IEnumerable<ServiceModel> CreatedServices { get; } = Enumerable.Empty<ServiceModel>();

        private ImportState() 
        { 
            IsLoading = false;
            CreatedClients = Enumerable.Empty<ClientModel>();
            CreatedServices = Enumerable.Empty<ServiceModel>();
        }
        
        public ImportState(bool? isLoading = null, IEnumerable<ClientModel>? createdClients = null, IEnumerable<ServiceModel> createdServices = null)
        {
            IsLoading = isLoading ?? false;
            CreatedClients = createdClients ?? Enumerable.Empty<ClientModel>();
            CreatedServices = createdServices ?? Enumerable.Empty<ServiceModel>();
        }
    }
}
