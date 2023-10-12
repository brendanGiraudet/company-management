
namespace CompanyManagement.Store.Client.Actions;

public class DeleteClientAction{
    public string ClientId { get; }

    public DeleteClientAction(string clientId)
    {
        ClientId = clientId;
    }
}