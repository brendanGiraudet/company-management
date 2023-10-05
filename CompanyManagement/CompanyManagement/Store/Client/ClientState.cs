using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    [FeatureState]
    public class ClientState
    {
        public bool IsLoading { get; }

        public IEnumerable<ClientModel> Clients { get; set; } = Enumerable.Empty<ClientModel>();

        private ClientState() { }

        public ClientState(bool? isLoading = null, IEnumerable<ClientModel>? clients = null)
        {
            IsLoading = isLoading ?? false;
            Clients = clients ?? Enumerable.Empty<ClientModel>();
        }
    }
}
