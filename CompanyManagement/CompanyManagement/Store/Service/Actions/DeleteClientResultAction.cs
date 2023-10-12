namespace CompanyManagement.Store.Service.Actions;

public class DeleteServiceResultAction{
    public string? DeletedServiceId { get; }

    public DeleteServiceResultAction(string? deletedServiceId)
    {
        DeletedServiceId = deletedServiceId;
    }
}