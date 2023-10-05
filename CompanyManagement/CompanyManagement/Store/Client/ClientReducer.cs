using CompanyManagement.Store.Client.Actions;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    public class ClientReducer
    {
        #region GetClients
        [ReducerMethod(typeof(GetClientsAction))]
        public static ClientState ReduceGetClientsAction(ClientState state) => new ClientState(isLoading: true);

        [ReducerMethod]
        public static ClientState ReduceGetClientsResultAction(ClientState state, GetClientsResultAction action) => new ClientState(clients: action.Clients);
        #endregion
    }
}
