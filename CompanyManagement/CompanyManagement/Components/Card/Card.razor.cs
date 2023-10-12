using Microsoft.AspNetCore.Components;

namespace CompanyManagement.Components.Card
{
    public partial class Card
    {
        [Parameter] public RenderFragment? Content { get; set; }

        [Parameter] public EventCallback OnClickCallback { get; set; }

        private async Task OnClick()
        {
            if(OnClickCallback.HasDelegate) await OnClickCallback.InvokeAsync();
        }
    }
}
