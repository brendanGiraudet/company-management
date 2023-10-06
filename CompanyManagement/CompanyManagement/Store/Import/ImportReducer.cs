using CompanyManagement.Store.Import.Actions;
using Fluxor;

namespace CompanyManagement.Store.Import
{
    public class ImportReducer
    {
        #region ImportClients
        [ReducerMethod(typeof(ImportClientsAction))]
        public static ImportState ReduceImportClientsAction(ImportState state) => new ImportState(isLoading: true);

        [ReducerMethod]
        public static ImportState ReduceImportClientsResultAction(ImportState state, ImportClientsResultAction action) => new ImportState(isLoading: false, createdClients: action.CreatedClients);
        #endregion
        
        #region ImportServices
        [ReducerMethod(typeof(ImportServicesAction))]
        public static ImportState ReduceImportServicesAction(ImportState state) => new ImportState(isLoading: true);

        [ReducerMethod]
        public static ImportState ReduceImportServicesResultAction(ImportState state, ImportServicesResultAction action) => new ImportState(isLoading: false, createdServices: action.CreatedServices);
        #endregion

    }
}
