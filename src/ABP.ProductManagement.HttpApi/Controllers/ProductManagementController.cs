using ABP.ProductManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABP.ProductManagement.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ProductManagementController : AbpControllerBase
{
    protected ProductManagementController()
    {
        LocalizationResource = typeof(ProductManagementResource);
    }
}
