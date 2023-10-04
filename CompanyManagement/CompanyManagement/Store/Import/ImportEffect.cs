using CompanyManagement.Services.Client;
using CompanyManagement.Services.Excel;
using CompanyManagement.Store.Import.Actions;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    public class ImportEffect
    {
        private IExcelService _excelService;
        private IClientService _clientService;

        public ImportEffect(IExcelService excelService, IClientService clientService)
        {
            _excelService = excelService;
            _clientService = clientService;
        }

        [EffectMethod]
        public async Task HandleFetchClientsAction(ImportClientsAction action, IDispatcher dispatcher)
        {
            var clients = await _excelService.GetClientsAsync(action.ClientFiles);

            await Console.Out.WriteLineAsync($"handle {clients.Count()}");

            var createdClientsResult = await _clientService.CreateAsync(clients);

            dispatcher.Dispatch(new ImportClientsResultAction(createdClientsResult.createdClients));
        }
    }
}
