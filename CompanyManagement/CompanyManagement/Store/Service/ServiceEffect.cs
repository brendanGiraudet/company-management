using CompanyManagement.Models;
using CompanyManagement.Services.Service;
using CompanyManagement.Store.Service.Actions;
using Fluxor;

namespace CompanyManagement.Store.Service
{
    public class ServiceEffect
    {
        private IServiceService _serviceService;

        public ServiceEffect(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [EffectMethod(typeof(GetServicesAction))]
        public async Task HandleGetServicesAction(IDispatcher dispatcher)
        {
            var servicesResult = await _serviceService.GetAsync();

            dispatcher.Dispatch(new GetServicesResultAction(servicesResult.services));
        }

        [EffectMethod]
        public async Task HandleCreateServiceAction(CreateServiceAction action, IDispatcher dispatcher)
        {
            var serviceResult = await _serviceService.CreateAsync(new List<ServiceModel>() { action.ServiceModel });

            dispatcher.Dispatch(new CreateServiceResultAction(serviceResult.createdServices.First()));
        }

        [EffectMethod]
        public async Task HandleUpdateServiceAction(UpdateServiceAction action, IDispatcher dispatcher)
        {
            var service = action.ServiceModel;

            var updateResult = await _serviceService.UpdateAsync(service);

            dispatcher.Dispatch(new UpdateServiceResultAction(updateResult.updatedService));
        }

        [EffectMethod]
        public async Task HandleDeleteServiceAction(DeleteServiceAction action, IDispatcher dispatcher)
        {
            var deleteResult = await _serviceService.DeleteAsync(action.ServiceId);

            dispatcher.Dispatch(new DeleteServiceResultAction(deleteResult.deletedServiceId));
        }
    }
}
