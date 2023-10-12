using CompanyManagement.Models;

namespace CompanyManagement.Store.Service.Actions;

public class UpdateServiceResultAction{
    public ServiceModel? ServiceModel { get; }

    public UpdateServiceResultAction(ServiceModel? serviceModel)
    {
        ServiceModel = serviceModel;
    }
}