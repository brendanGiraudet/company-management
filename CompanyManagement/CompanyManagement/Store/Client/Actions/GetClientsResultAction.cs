using CompanyManagement.Models;

namespace CompanyManagement.Store.Client.Actions
{
    public class GetClientsResultAction
    {
        public IEnumerable<ClientModel> Clients { get; }

        public GetClientsResultAction(IEnumerable<ClientModel> clients)
        {
            Clients = clients;
        }
    }
}
