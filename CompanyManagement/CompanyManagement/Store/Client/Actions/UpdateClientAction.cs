using CompanyManagement.Models;

namespace CompanyManagement.Store.Client.Actions;

public class UpdateClientAction
{
    public ClientModel ClientModel { get; }

    public UpdateClientAction(ClientModel clientModel)
    {
        ClientModel = clientModel;
    }
}