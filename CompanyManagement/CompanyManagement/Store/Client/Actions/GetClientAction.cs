namespace CompanyManagement.Store.Client.Actions;

public class GetClientAction
{
    public string ClientId { get; }

    public GetClientAction(string clientId)
    {
        ClientId = clientId;
    }
}