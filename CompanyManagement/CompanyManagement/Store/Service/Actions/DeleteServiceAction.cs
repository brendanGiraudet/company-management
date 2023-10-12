namespace CompanyManagement.Store.Service.Actions;

public class DeleteServiceAction
{
    public string ServiceId { get; }

    public DeleteServiceAction(string serviceId)
    {
        ServiceId = serviceId;
    }
}