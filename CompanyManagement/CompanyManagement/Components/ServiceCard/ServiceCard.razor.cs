using Microsoft.AspNetCore.Components;
using CompanyManagement.Models;

namespace CompanyManagement.Components.ServiceCard
{
    public partial class ServiceCard
    {
        [Parameter] public ServiceModel Service { get; set; }
    }
}
