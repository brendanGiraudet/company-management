using CompanyManagement.Models;
using Microsoft.AspNetCore.Components.Forms;
using OfficeOpenXml;

namespace CompanyManagement.Services.Excel
{
    public class ExcelService : IExcelService
    {
        private readonly long maxFileSize = 1024 * 5000;

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

                    if(client == null) client = GetClientFromExcel(fs, "Devis");

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

        public async Task<Stream> GetClientsFileStreamAsync(IEnumerable<ClientModel> clientModels)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var clientFilePath = @"c:\temp\clients.xlsx";

            using var package = new ExcelPackage(clientFilePath);
            
            var sheet = package.Workbook.Worksheets.Add("Clients");
            sheet.Cells["A1"].Value = "Id";
            sheet.Cells["B1"].Value = "Nom";
            sheet.Cells["C1"].Value = "Adresse";
            sheet.Cells["D1"].Value = "Téléphone";
            sheet.Cells["E1"].Value = "Email";

            for (int i = 0; i < clientModels.Count(); i++)
            {
                sheet.Cells[$"A{i+ 2}"].Value = clientModels.ElementAt(i).Id;
                sheet.Cells[$"B{i+ 2}"].Value = clientModels.ElementAt(i).Name;
                sheet.Cells[$"C{i+ 2}"].Value = clientModels.ElementAt(i).Addresses?.First()?.ToString();
                sheet.Cells[$"D{i+ 2}"].Value = clientModels.ElementAt(i).PhoneNumber;
                sheet.Cells[$"E{i+ 2}"].Value = clientModels.ElementAt(i).Email;
            }

            // Save to file
            package.Save();

            FileStream fRead = new FileStream(clientFilePath, 
                       FileMode.Open, FileAccess.Read, FileShare.Read);

            return fRead;
        }
    }
}
