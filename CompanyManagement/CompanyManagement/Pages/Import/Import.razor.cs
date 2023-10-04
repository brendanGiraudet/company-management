using CompanyManagement.Store.Import;
using CompanyManagement.Store.Import.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CompanyManagement.Pages.Import
{
    public partial class Import
    {
        private int maxAllowedFiles = 3;

        [Inject] public IState<ImportState> ImportState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles(maxAllowedFiles);

            Dispatcher.Dispatch(new ImportClientsAction(files));
        }
    }
}