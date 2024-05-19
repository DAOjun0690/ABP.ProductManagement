using ABP.ProductManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ABP.ProductManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ProductManagementEntityFrameworkCoreModule),
    typeof(ProductManagementApplicationContractsModule)
    )]
public class ProductManagementDbMigratorModule : AbpModule
{
}
