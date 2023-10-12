using CompanyManagement.Models;

namespace CompanyManagement.Store.Service.Actions;

public class CreateServiceAction
{
    public ServiceModel ServiceModel { get; }

    public CreateServiceAction(ServiceModel serviceModel)
    {
        ServiceModel = serviceModel;
    }
}