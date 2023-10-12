namespace CompanyManagement.Store.Service.Actions;

public class GetServiceAction
{
    public string ServiceId { get; }

    public GetServiceAction(string serviceId)
    {
        ServiceId = serviceId;
    }
}