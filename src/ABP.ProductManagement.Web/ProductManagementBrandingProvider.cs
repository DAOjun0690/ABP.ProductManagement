using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ABP.ProductManagement.Web;

[Dependency(ReplaceServices = true)]
public class ProductManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "ProductManagement";
}
