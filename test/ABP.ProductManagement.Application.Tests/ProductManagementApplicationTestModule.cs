using Volo.Abp.Modularity;

namespace ABP.ProductManagement;

[DependsOn(
    typeof(ProductManagementApplicationModule),
    typeof(ProductManagementDomainTestModule)
)]
public class ProductManagementApplicationTestModule : AbpModule
{

}
