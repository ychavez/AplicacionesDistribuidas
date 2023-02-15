using DWShop.Web.Client.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace DWShop.Web.Client.Pages
{
    public partial class Details
    {
        [Inject]
        public IProductService ProductService { get; set; } = null!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public string ProductId { get; set; }
       
    }
}
