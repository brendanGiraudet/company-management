using Microsoft.AspNetCore.Components.Forms;

namespace CompanyManagement.Store.Import.Actions
{
    public class ImportClientsAction
    {
        public IReadOnlyList<IBrowserFile>  ClientFiles { get; }

        public ImportClientsAction(IReadOnlyList<IBrowserFile> clientFiles)
        {
            ClientFiles = clientFiles;
        }
    }
}
