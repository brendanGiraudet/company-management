﻿using CompanyManagement.Constants;
using CompanyManagement.Services.Client;
using CompanyManagement.Services.Excel;
using CompanyManagement.Services.Service;

namespace CompanyManagement.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IServiceService, ServiceService>();
        }

        public static void AddNamedHttpClient(this IServiceCollection services)
        {
            services.AddHttpClient(NameHttpClient.CompanyManagementAPI, config =>
            {
                config.BaseAddress = new Uri("https://localhost:7293");
            });
        }
    }
}
