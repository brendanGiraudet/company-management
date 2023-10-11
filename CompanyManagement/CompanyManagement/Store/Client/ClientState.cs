using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Client
{
    [FeatureState]
    public class ClientState
    {
        public bool IsLoading { get; }

        public IEnumerable<ClientModel> Clients { get; set; } = Enumerable.Empty<ClientModel>();
        
        public ClientModel Client { get; }
        
        public AddressModel Address { get; }

        private ClientState() 
        { 
            IsLoading = false;
            Clients = Enumerable.Empty<ClientModel>();
            Client = new();
            Address = new();
        }

        public ClientState(bool? isLoading = null, IEnumerable<ClientModel>? clients = null, ClientModel? client = null, AddressModel? address = null)
        {
            IsLoading = isLoading ?? false;
            Clients = clients ?? Enumerable.Empty<ClientModel>();
            Client = client ?? new();
            Address = address ?? new();
        }
    }
}
