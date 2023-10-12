namespace CompanyManagement.Store.Client.Actions;

public class DeleteClientResultAction{
    public string? DeletedClientId { get; }

    public DeleteClientResultAction(string? deletedClientId)
    {
        DeletedClientId = deletedClientId;
    }
}