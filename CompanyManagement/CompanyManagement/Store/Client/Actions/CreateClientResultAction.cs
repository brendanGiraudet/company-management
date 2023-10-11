using CompanyManagement.Models;

namespace CompanyManagement.Store.Client.Actions;

public class CreateClientResultAction
{
public ClientModel ClientModel { get; }

    public CreateClientResultAction(ClientModel clientModel)
    {
        ClientModel = clientModel;
    }
}