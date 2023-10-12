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

        #region GetService
        [ReducerMethod]
        public static ServiceState ReducerGetServiceAction(ServiceState state, GetServiceAction action) => new(
            services: state.Services, service: state.Services.FirstOrDefault(c => c.Id == action.ServiceId));
        #endregion

        #region UpdateService
        [ReducerMethod(typeof(UpdateServiceAction))]
        public static ServiceState ReducerUpdateServiceAction(ServiceState state) => new(isLoading: true,
            services: state.Services);

        [ReducerMethod]
        public static ServiceState ReducerUpdateServiceResultAction(ServiceState state, UpdateServiceResultAction action)
        {
            var services = state.Services.Where(c => c.Id != action.ServiceModel.Id);
            services = services.Append(action.ServiceModel);

            return new(isLoading: false, services: services);
        }
        #endregion

        #region DeleteService
        [ReducerMethod(typeof(DeleteServiceAction))]
        public static ServiceState ReducerDeleteServiceAction(ServiceState state) => new(isLoading: true,
                    services: state.Services);

        [ReducerMethod]
        public static ServiceState ReducerDeleteServiceResultAction(ServiceState state, DeleteServiceResultAction action)
        {
            var services = state.Services.Where(c => c.Id != action.DeletedServiceId);

            return new(isLoading: false, services: services);
        }

        #endregion
    }
}
