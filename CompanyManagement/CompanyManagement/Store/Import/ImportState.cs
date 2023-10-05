using CompanyManagement.Models;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    [FeatureState]
    public class ImportState
    {
        public bool IsLoading { get; }

        public IEnumerable<ClientModel> CreatedClients { get; } = Enumerable.Empty<ClientModel>();

        private ImportState() { }
        public ImportState(bool isLoading = false, IEnumerable<ClientModel>? createdClients = null)
        {
            IsLoading = isLoading;
            CreatedClients = createdClients ?? Enumerable.Empty<ClientModel>();
        }
    }
}
