﻿namespace CompanyManagement.Constants
{
    public static class ClientApiEndpoints
    {
        public const string BasePath = "/clients";

        public const string CreationEndpoint = BasePath;
        
        public const string GetEndpoint = BasePath;

        public const string UpdateEndpoint = BasePath;
        
        public const string DeleteEndpoint = BasePath;
        public static string GetDeleteEndpoint(string id) => $"{DeleteEndpoint}/{id}";
    }
}
