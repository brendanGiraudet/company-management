using CompanyManagement.Models;

namespace CompanyManagement.Store.Service.Actions;

public class UpdateServiceAction
{
    public ServiceModel ServiceModel { get; }

    public UpdateServiceAction(ServiceModel serviceModel)
    {
        ServiceModel = serviceModel;
    }
}