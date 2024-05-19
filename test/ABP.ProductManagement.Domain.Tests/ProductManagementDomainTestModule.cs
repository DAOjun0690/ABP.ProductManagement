using Volo.Abp.Modularity;

namespace ABP.ProductManagement;

[DependsOn(
    typeof(ProductManagementDomainModule),
    typeof(ProductManagementTestBaseModule)
)]
public class ProductManagementDomainTestModule : AbpModule
{

}
