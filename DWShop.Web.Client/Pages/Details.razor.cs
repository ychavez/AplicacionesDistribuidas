using DWShop.Web.Client.Services.Contracts;
using DWShop.Web.Common.Models;
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
        public int ProductId { get; set; }

        public Product? Product { get; set; }

        protected override async Task OnInitializedAsync()
        {
             Product = await ProductService.GetAsync(ProductId);
        }

    }
}
