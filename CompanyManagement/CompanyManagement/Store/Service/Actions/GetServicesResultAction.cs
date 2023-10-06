using CompanyManagement.Models;

namespace CompanyManagement.Store.Service.Actions
{
    public class GetServicesResultAction
    {
        public IEnumerable<ServiceModel> Services { get; }

        public GetServicesResultAction(IEnumerable<ServiceModel> services)
        {
            Services = services;
        }
    }
}
