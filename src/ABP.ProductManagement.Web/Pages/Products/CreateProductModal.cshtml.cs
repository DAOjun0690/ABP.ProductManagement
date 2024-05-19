using ABP.ProductManagement.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace ABP.ProductManagement.Web.Pages.Products
{
    public class CreateProductModalModel : ProductManagementPageModel
    {
        public SelectListItem[] Categories { get; set; }

        /// <summary>
        /// net core ¯S©Ê
        /// </summary>
        [BindProperty]
        public CreateEditProductViewModel Product { get; set; }

        private readonly IProductAppService _productAppService;
        public CreateProductModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGetAsync()
        {
            Product = new CreateEditProductViewModel
            {
                ReleaseDate = Clock.Now,
                StockState = ProductStockState.InStock
            };

            var categoryLookup = await _productAppService.GetCategoriesAsync();
            Categories = categoryLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArray();
        }

        public async Task<IActionResult> OnPostAsync() 
        {
            var productDto = ObjectMapper.Map<CreateEditProductViewModel, CreateUpdateProductDto>(Product);
            await _productAppService.CreateAsync(productDto);
            return NoContent();
        }
    }
}
