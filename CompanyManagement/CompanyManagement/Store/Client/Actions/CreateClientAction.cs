using CompanyManagement.Models;

namespace CompanyManagement.Store.Client.Actions;

public class CreateClientAction
{
    public ClientModel ClientModel { get; }
    
    public AddressModel AddressModel { get; }

    public CreateClientAction(ClientModel clientModel, AddressModel addressModel)
    {
        ClientModel = clientModel;
        AddressModel = addressModel;
    }
}