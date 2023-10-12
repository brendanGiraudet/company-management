using CompanyManagement.Models;
using CompanyManagement.Services.Client;
using CompanyManagement.Store.Client.Actions;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    public class ClientEffect
    {
        private IClientService _clientService;

        public ClientEffect(IClientService clientService)
        {
            _clientService = clientService;
        }

        [EffectMethod(typeof(GetClientsAction))]
        public async Task HandleGetClientsAction(IDispatcher dispatcher)
        {
            var clientsResult = await _clientService.GetAsync();

            dispatcher.Dispatch(new GetClientsResultAction(clientsResult.clients));
        }

        [EffectMethod]
        public async Task HandleCreateClientAction(CreateClientAction action, IDispatcher dispatcher)
        {
            var client = action.ClientModel;
            client.Addresses = new() { action.AddressModel };

            var clientsResult = await _clientService.CreateAsync(new List<ClientModel>() { client });

            dispatcher.Dispatch(new CreateClientResultAction(clientsResult.createdClients.First()));
        }
        
        [EffectMethod]
        public async Task HandleUpdateClientAction(UpdateClientAction action, IDispatcher dispatcher)
        {
            var client = action.ClientModel;

            var updateResult = await _clientService.UpdateAsync(client);

            dispatcher.Dispatch(new UpdateClientResultAction(updateResult.updatedClient));
        }
        
        [EffectMethod]
        public async Task HandleDeleteClientAction(DeleteClientAction action, IDispatcher dispatcher)
        {
            var deleteResult = await _clientService.DeleteAsync(action.ClientId);

            dispatcher.Dispatch(new DeleteClientResultAction(deleteResult.deletedClientId));
        }
    }
}
