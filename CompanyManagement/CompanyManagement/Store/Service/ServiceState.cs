using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Service
{
    [FeatureState]
    public class ServiceState
    {
        public bool IsLoading { get; }

        public IEnumerable<ServiceModel> Services { get; set; } = Enumerable.Empty<ServiceModel>();
        
        public ServiceModel Service { get; }

        private ServiceState() 
        { 
            IsLoading = false;
            Services = Enumerable.Empty<ServiceModel>();
            Service = new();
        }

        public ServiceState(bool? isLoading = null, IEnumerable<ServiceModel>? services = null, ServiceModel? service = null)
        {
            IsLoading = isLoading ?? false;
            Services = services ?? Enumerable.Empty<ServiceModel>();
            Service = service ?? new();
        }
    }
}
