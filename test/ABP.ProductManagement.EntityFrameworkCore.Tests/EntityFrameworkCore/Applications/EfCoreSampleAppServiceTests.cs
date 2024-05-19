using ABP.ProductManagement.Samples;
using Xunit;

namespace ABP.ProductManagement.EntityFrameworkCore.Applications;

[Collection(ProductManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ProductManagementEntityFrameworkCoreTestModule>
{

}
