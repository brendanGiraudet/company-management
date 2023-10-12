using CompanyManagement.Services.Excel;
using CompanyManagement.Store.Service.Actions;
using CompanyManagement.Store.Service;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using CompanyManagement.Enums;
using CompanyManagement.Constants;

namespace CompanyManagement.Pages.Service
{
    public partial class Service
    {
        [Inject] public required IState<ServiceState> ServiceState { get; set; }
        
        [Inject] public required IDispatcher Dispatcher { get; set; }
        
        [Inject] public required IJSRuntime JS { get; set; }
        
        [Inject] public required IExcelService ExcelService { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher.Dispatch(new GetServicesAction());
        }

        private async Task<Stream> GetFileStream()
        {
            return await ExcelService.GetServicesFileStreamAsync(ServiceState.Value.Services);
        }

        private async Task DownloadFileFromStream()
        {
            var fileStream = await GetFileStream();
            var fileName = "services.xlsx";

            using var streamRef = new DotNetStreamReference(stream: fileStream);

            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }

        private async Task RedirectToServiceForm(FormMode formMode, string? serviceId = null)
        {
            NavigationManager.NavigateTo(PagesUrl.GetServiceFormUrl(formMode, serviceId));

            await Task.CompletedTask;
        }
    }
}
