using ABP.ProductManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ABP.ProductManagement.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class ProductManagementPageModel : AbpPageModel
{
    protected ProductManagementPageModel()
    {
        LocalizationResourceType = typeof(ProductManagementResource);
    }
}
