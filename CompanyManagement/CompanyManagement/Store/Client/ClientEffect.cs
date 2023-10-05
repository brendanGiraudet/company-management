using CompanyManagement.Services.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    public class ClientEffect
    {
        private IClientService _clientService;
        private IDispatcher _dispatcher;

        public ClientEffect(IClientService clientService, IDispatcher dispatcher)
        {
            _clientService = clientService;
            _dispatcher = dispatcher;
        }

        [EffectMethod(typeof(GetClientsAction))]
        public async Task HandleGetClientsAction(IDispatcher dispatcher)
        {
            var clientsResult = await _clientService.GetAsync();

            _dispatcher.Dispatch(new GetClientsResultAction(clientsResult.clients));
        }

    }
}
