using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Service
{
    [FeatureState]
    public class ServiceState
    {
        public bool IsLoading { get; }

        public IEnumerable<ServiceModel> Services { get; set; } = Enumerable.Empty<ServiceModel>();

        private ServiceState() { }

        public ServiceState(bool? isLoading = null, IEnumerable<ServiceModel>? services = null)
        {
            IsLoading = isLoading ?? false;
            Services = services ?? Enumerable.Empty<ServiceModel>();
        }
    }
}
