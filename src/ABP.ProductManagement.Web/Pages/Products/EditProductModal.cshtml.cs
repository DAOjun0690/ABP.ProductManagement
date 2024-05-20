using ABP.ProductManagement.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ABP.ProductManagement.Web.Pages.Products
{
    public class EditProductModalModel : ProductManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)] // 支持 Get 請求
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditProductViewModel Product { get; set; }
        public SelectListItem[] Categories { get; set; }

        private readonly IProductAppService _productAppService;

        public EditProductModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGetAsync()
        {
            var product = await _productAppService.GetAsync(Id);
            Product = ObjectMapper.Map<ProductDto, CreateEditProductViewModel>(product);
            var categoryLookup = await _productAppService.GetCategoriesAsync();
            Categories = categoryLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToArray();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var productDto = ObjectMapper.Map<
                CreateEditProductViewModel, CreateUpdateProductDto>(Product);
            await _productAppService.UpdateAsync(Id, productDto);
            return NoContent();
        }
    }
}
