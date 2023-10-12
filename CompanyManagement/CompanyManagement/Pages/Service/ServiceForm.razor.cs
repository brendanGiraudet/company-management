using CompanyManagement.Constants;
using CompanyManagement.Enums;
using CompanyManagement.Store.Service;
using CompanyManagement.Store.Service.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CompanyManagement.Pages.Service
{
    public partial class ServiceForm
    {
        [Inject] public required IState<ServiceState> ServiceState { get; set; }

        [Inject] public required IDispatcher Dispatcher { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public string Action { get; set; }

        [Parameter] public string? ServiceId { get; set; }

        public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);

        private bool CanShowDeletedButton => FormMode == FormMode.Update;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Dispatcher.Dispatch(new GetServiceAction(ServiceId));
        }

        private async Task RedirectToServiceList()
        {
            NavigationManager.NavigateTo(PagesUrl.ServicesUrl);

            await Task.CompletedTask;
        }

        private async Task SaveService()
        {
            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new UpdateServiceAction(ServiceState.Value.Service));
                    break;
                case FormMode.Creation:
                    Dispatcher.Dispatch(new CreateServiceAction(ServiceState.Value.Service));
                    break;
                default:
                    break;
            }

            await RedirectToServiceList();
        }

        private async Task DeleteAsync()
        {
            Dispatcher.Dispatch(new DeleteServiceAction(ServiceState.Value.Service.Id));

            await RedirectToServiceList();
        }
    }
}
