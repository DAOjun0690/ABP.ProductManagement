using Xunit;

namespace ABP.ProductManagement.EntityFrameworkCore;

[CollectionDefinition(ProductManagementTestConsts.CollectionDefinitionName)]
public class ProductManagementEntityFrameworkCoreCollection : ICollectionFixture<ProductManagementEntityFrameworkCoreFixture>
{

}
