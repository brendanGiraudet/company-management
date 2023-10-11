using CompanyManagement.Enums;

namespace CompanyManagement.Constants
{
    public class PagesUrl
    {
        public static string GetClientFormUrl(FormMode formMode, string? clientId = null) => clientId != null ? $"{ClientsUrl}/{formMode}/{clientId}" : $"{ClientsUrl}/{formMode}";

        public static string ClientsUrl => $"/clients";
    }
}