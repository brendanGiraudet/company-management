using CompanyManagement.Models;
using CompanyManagement.Services.Client;
using CompanyManagement.Services.Excel;
using CompanyManagement.Services.Service;
using CompanyManagement.Store.Import.Actions;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    public class ImportEffect
    {
        private readonly IExcelService _excelService;
        private readonly IClientService _clientService;
        private readonly IServiceService _serviceService;

        public ImportEffect(IExcelService excelService, IClientService clientService, IServiceService serviceService)
        {
            _excelService = excelService;
            _clientService = clientService;
            _serviceService = serviceService;
        }

        [EffectMethod]
        public async Task HandleImportClientsAction(ImportClientsAction action, IDispatcher dispatcher)
        {
            var clients = await _excelService.GetClientsAsync(action.ClientFiles);

            var createdClientsResult = await _clientService.CreateAsync(clients);

            dispatcher.Dispatch(new ImportClientsResultAction(createdClientsResult.createdClients));
        }
        
        [EffectMethod]
        public async Task HandleImportServicesAction(ImportServicesAction action, IDispatcher dispatcher)
        {
            var services = await _excelService.GetServicesAsync(action.ServiceFiles);

            var createdServicesResult = await _serviceService.CreateAsync(services);

            dispatcher.Dispatch(new ImportServicesResultAction(createdServicesResult.createdServices));
        }
    }
}
