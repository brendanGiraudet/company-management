using CompanyManagement.Models;
using Microsoft.AspNetCore.Components.Forms;
using OfficeOpenXml;

namespace CompanyManagement.Services.Excel
{
    public class ExcelService : IExcelService
    {
        private readonly long maxFileSize = 1024 * 55;

        /// <inheritdoc/>
        public async Task<IEnumerable<ClientModel>> GetClientsAsync(IReadOnlyList<IBrowserFile> browserFiles)
        {
            var clients = new List<ClientModel>();

            foreach (var file in browserFiles)
            {
                try
                {
                    await using MemoryStream fs = new();
                    await file.OpenReadStream(maxFileSize).CopyToAsync(fs);

                    var client = GetClientFromExcel(fs, "Devis&Factures");

                    if(client != null) clients.Add(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File: {file.Name} Error: {ex.Message}");
                }
            }

            return clients;
        }

        private static ClientModel? GetClientFromExcel(Stream fileStream, string sheetName)
        {
            ClientModel? client = null;

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(fileStream);
                var worksheet = package.Workbook.Worksheets[sheetName];
                if (worksheet != null)
                {
                    client = new ClientModel
                    {
                        Name = worksheet.Cells["F2"].Text,
                        Addresses = new HashSet<AddressModel>()
                         {
                             new AddressModel()
                             {
                                 AddressTypeId = "6b78e697-99f4-4c55-aa30-3266247c1f22",
                                 Street = worksheet.Cells["F3"].Text,
                                 ZipCode = worksheet.Cells["F4"].Text,
                                 City = worksheet.Cells["F5"].Text,
                             }
                         },
                        PhoneNumber = worksheet.Cells["F6"].Text,
                        Email = worksheet.Cells["F7"].Text,
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }

            return client;
        }
    }
}
