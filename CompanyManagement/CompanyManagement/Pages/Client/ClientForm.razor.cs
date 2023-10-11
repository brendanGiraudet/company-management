using CompanyManagement.Constants;
using CompanyManagement.Enums;
using CompanyManagement.Store.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CompanyManagement.Pages.Client
{
    public partial class ClientForm
    {
        [Inject] public required IState<ClientState> ClientState { get; set; }

        [Inject] public required IDispatcher Dispatcher { get; set; }

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Parameter] public string Action { get; set; }

        [Parameter] public string? ClientId { get; set; }

        public FormMode FormMode => (FormMode)Enum.Parse(typeof(FormMode), Action);

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        private async Task RedirectToClientList()
        {
            NavigationManager.NavigateTo(PagesUrl.ClientsUrl);

            await Task.CompletedTask;
        }

        private async Task SaveClient()
        {
            switch (FormMode)
            {
                case FormMode.Update:
                    Dispatcher.Dispatch(new UpdateClientAction(ClientState.Value.Client));
                    break;
                case FormMode.Creation:
                    Dispatcher.Dispatch(new CreateClientAction(ClientState.Value.Client, ClientState.Value.Address));
                    break;
                default:
                    break;
            }

            NavigationManager.NavigateTo(PagesUrl.ClientsUrl);

            await Task.CompletedTask;
        }
    }
}
