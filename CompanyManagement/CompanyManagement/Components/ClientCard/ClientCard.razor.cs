using Microsoft.AspNetCore.Components;
using CompanyManagement.Models;

namespace CompanyManagement.Components.ClientCard
{
    public partial class ClientCard
    {
        [Parameter] public ClientModel Client { get; set; }
    }
}
