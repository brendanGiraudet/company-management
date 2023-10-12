using CompanyManagement.Store.Client.Actions;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    public class ClientReducer
    {
        #region GetClients
#pragma warning disable IDE0060
        [ReducerMethod(typeof(GetClientsAction))]
        public static ClientState ReduceGetClientsAction(ClientState state) => new(isLoading: true);

        [ReducerMethod]
        public static ClientState ReduceGetClientsResultAction(ClientState state, GetClientsResultAction action) => new(clients: action.Clients);
#pragma warning restore IDE0060
        #endregion

        #region CreateClient
        [ReducerMethod(typeof(CreateClientAction))]
        public static ClientState ReducerCreateClientAction(ClientState state) => new(isLoading: true);

        [ReducerMethod]
        public static ClientState ReducerCreateClientResultAction(ClientState state, CreateClientResultAction action) => new(isLoading: false, clients: state.Clients.Append(action.ClientModel));
        #endregion

        #region GetClient
        [ReducerMethod]
        public static ClientState ReducerGetClientAction(ClientState state, GetClientAction action) => new(
            clients: state.Clients, client: state.Clients.FirstOrDefault(c => c.Id == action.ClientId), address: state.Clients.FirstOrDefault(c => c.Id == action.ClientId)?.Addresses?.FirstOrDefault());
        #endregion

        #region UpdateClient
        [ReducerMethod(typeof(UpdateClientAction))]
        public static ClientState ReducerUpdateClientAction(ClientState state) => new(isLoading: true,
            clients: state.Clients);

        [ReducerMethod]
        public static ClientState ReducerUpdateClientResultAction(ClientState state, UpdateClientResultAction action)
        {
            var clients = state.Clients.Where(c => c.Id != action.ClientModel.Id);
            clients = clients.Append(action.ClientModel);

            return new(isLoading: false, clients: clients);
        }
        #endregion

        #region DeleteClient
        [ReducerMethod(typeof(DeleteClientAction))]
        public static ClientState ReducerDeleteClientAction(ClientState state) => new(isLoading: true,
                    clients: state.Clients);

        [ReducerMethod]
        public static ClientState ReducerDeleteClientResultAction(ClientState state, DeleteClientResultAction action)
        {
            var clients = state.Clients.Where(c => c.Id != action.DeletedClientId);

            return new(isLoading: false, clients: clients);
        }

        #endregion
    }
}
