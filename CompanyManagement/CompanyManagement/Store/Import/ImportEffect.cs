using CompanyManagement.Services.Client;
using CompanyManagement.Services.Excel;
using CompanyManagement.Store.Import.Actions;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    public class ImportEffect
    {
        private readonly IExcelService _excelService;
        private readonly IClientService _clientService;

        public ImportEffect(IExcelService excelService, IClientService clientService)
        {
            _excelService = excelService;
            _clientService = clientService;
        }

        [EffectMethod]
        public async Task HandleFetchClientsAction(ImportClientsAction action, IDispatcher dispatcher)
        {
            var clients = await _excelService.GetClientsAsync(action.ClientFiles);

            var createdClientsResult = await _clientService.CreateAsync(clients);

            dispatcher.Dispatch(new ImportClientsResultAction(createdClientsResult.createdClients));
        }
    }
}
