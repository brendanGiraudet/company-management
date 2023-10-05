using CompanyManagement.Store.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace CompanyManagement.Pages.Client
{
    public partial class Client
    {
        [Inject] public IState<ClientState> ClientState { get; set; }
        [Inject] public IDispatcher Dispatcher { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Dispatcher.Dispatch(new GetClientsAction());
        }
    }
}
