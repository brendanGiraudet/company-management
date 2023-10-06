using CompanyManagement.Models;

namespace CompanyManagement.Store.Import.Actions
{
    public class ImportServicesResultAction
    {
        public IEnumerable<ServiceModel> CreatedServices { get; }

        public ImportServicesResultAction(IEnumerable<ServiceModel> createdServices)
        {
            CreatedServices = createdServices;
        }
    }
}
