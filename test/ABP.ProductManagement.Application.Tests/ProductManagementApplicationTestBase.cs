using Volo.Abp.Modularity;

namespace ABP.ProductManagement;

public abstract class ProductManagementApplicationTestBase<TStartupModule> : ProductManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
