using CompanyManagement.Models;

namespace CompanyManagement.Store.Import.Actions
{
    public class ImportClientsResultAction
    {
        public IEnumerable<ClientModel> CreatedClients { get; }

        public ImportClientsResultAction(IEnumerable<ClientModel> createdClients)
        {
            CreatedClients = createdClients;
        }
    }
}
