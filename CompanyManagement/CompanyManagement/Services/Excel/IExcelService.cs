using CompanyManagement.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace CompanyManagement.Services.Excel
{
    public interface IExcelService
    {
        /// <summary>
        /// Get clients from excel files
        /// </summary>
        /// <param name="browserFiles"></param>
        /// <returns>Client list</returns>
        Task<IEnumerable<ClientModel>> GetClientsAsync(IReadOnlyList<IBrowserFile> browserFiles);

        /// <summary>
        /// Get the file stream of the excel clients file
        /// </summary>
        /// <param name="clientModels"></param>
        /// <returns></returns>
        Task<Stream> GetClientsFileStreamAsync(IEnumerable<ClientModel> clientModels);
    }
}
