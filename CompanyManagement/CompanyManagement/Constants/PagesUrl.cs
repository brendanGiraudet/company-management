using CompanyManagement.Enums;

namespace CompanyManagement.Constants
{
    public class PagesUrl
    {
        public static string GetClientFormUrl(FormMode formMode, string? clientId = null) => clientId != null ? $"{ClientsUrl}/{formMode}/{clientId}" : $"{ClientsUrl}/{formMode}";
        public static string ClientsUrl => $"/clients";
        
        public static string GetServiceFormUrl(FormMode formMode, string? serviceId = null) => serviceId != null ? $"{ServicesUrl}/{formMode}/{serviceId}" : $"{ServicesUrl}/{formMode}";
        public static string ServicesUrl => $"/services";
    }
}