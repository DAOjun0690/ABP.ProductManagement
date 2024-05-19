using System;
using System.Collections.Generic;
using System.Text;
using ABP.ProductManagement.Localization;
using Volo.Abp.Application.Services;

namespace ABP.ProductManagement;

/* Inherit your application services from this class.
 */
public abstract class ProductManagementAppService : ApplicationService
{
    protected ProductManagementAppService()
    {
        LocalizationResource = typeof(ProductManagementResource);
    }
}
