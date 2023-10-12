using CompanyManagement.Models;

namespace CompanyManagement.Store.Service.Actions;

public class CreateServiceResultAction
{
public ServiceModel ServiceModel { get; }

    public CreateServiceResultAction(ServiceModel serviceModel)
    {
        ServiceModel = serviceModel;
    }
}