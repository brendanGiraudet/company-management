using Microsoft.AspNetCore.Components.Forms;

namespace CompanyManagement.Store.Import.Actions
{
    public class ImportServicesAction
    {
        public IReadOnlyList<IBrowserFile>  ServiceFiles { get; }

        public ImportServicesAction(IReadOnlyList<IBrowserFile> serviceFiles)
        {
            ServiceFiles = serviceFiles;
        }
    }
}
