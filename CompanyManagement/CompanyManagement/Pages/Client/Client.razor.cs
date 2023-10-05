using CompanyManagement.Store.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CompanyManagement.Pages.Client
{
    public partial class Client
    {
        [Inject] public required IState<ClientState> ClientState { get; set; }
        [Inject] public required IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher.Dispatch(new GetClientsAction());
        }
    }
}
