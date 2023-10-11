using CompanyManagement.Constants;
using CompanyManagement.Enums;
using CompanyManagement.Services.Excel;
using CompanyManagement.Store.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CompanyManagement.Pages.Client
{
    public partial class Client
    {
        [Inject] public required IState<ClientState> ClientState { get; set; }

        [Inject] public required IDispatcher Dispatcher { get; set; }

        [Inject] public required IJSRuntime JS { get; set; }

        [Inject] public required IExcelService ExcelService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher.Dispatch(new GetClientsAction());
        }

        private async Task<Stream> GetFileStream()
        {
            return await ExcelService.GetClientsFileStreamAsync(ClientState.Value.Clients);
        }

        private async Task DownloadFileFromStream()
        {
            var fileStream = await GetFileStream();
            var fileName = "clients.xlsx";

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private async Task RedirectToClientForm(FormMode formMode, string? clientId = null)
        {
            NavigationManager.NavigateTo(PagesUrl.GetClientFormUrl(formMode, clientId));

            await Task.CompletedTask;
        }
    }
}
