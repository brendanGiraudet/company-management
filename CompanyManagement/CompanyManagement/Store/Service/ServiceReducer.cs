using CompanyManagement.Store.Service.Actions;
using Fluxor;

namespace CompanyManagement.Store.Service
{
    public class ServiceReducer
    {
        #region GetServices
#pragma warning disable IDE0060
        [ReducerMethod(typeof(GetServicesAction))]
        public static ServiceState ReduceGetServicesAction(ServiceState state) => new(isLoading: true);

        [ReducerMethod]
        public static ServiceState ReduceGetServicesResultAction(ServiceState state, GetServicesResultAction action) => new(services: action.Services);
#pragma warning restore IDE0060
        #endregion
    }
}
