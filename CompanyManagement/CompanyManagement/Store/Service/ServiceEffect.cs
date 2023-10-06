using CompanyManagement.Services.Service;
using CompanyManagement.Store.Service.Actions;
using Fluxor;

namespace CompanyManagement.Store.Service
{
    public class ServiceEffect
    {
        private IServiceService _serviceService;
        private IDispatcher _dispatcher;

        public ServiceEffect(IServiceService serviceService, IDispatcher dispatcher)
        {
            _serviceService = serviceService;
            _dispatcher = dispatcher;
        }

        [EffectMethod(typeof(GetServicesAction))]
        public async Task HandleGetServicesAction(IDispatcher dispatcher)
        {
            var clientsResult = await _serviceService.GetAsync();

            _dispatcher.Dispatch(new GetServicesResultAction(clientsResult.services));
        }
    }
}
