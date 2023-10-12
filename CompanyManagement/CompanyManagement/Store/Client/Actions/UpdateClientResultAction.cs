using CompanyManagement.Models;

namespace CompanyManagement.Store.Client.Actions;

public class UpdateClientResultAction{
    public ClientModel? ClientModel { get; }

    public UpdateClientResultAction(ClientModel? clientModel)
    {
        ClientModel = clientModel;
    }
}