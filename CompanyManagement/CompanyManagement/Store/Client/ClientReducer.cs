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
        public static ClientState ReducerCreateClientAction(ClientState state) => new (isLoading: true);

        [ReducerMethod]
        public static ClientState ReducerCreateClientResultAction(ClientState state, CreateClientResultAction action) => new(isLoading: false, clients: state.Clients.Append(action.ClientModel));
        #endregion
    }
}
