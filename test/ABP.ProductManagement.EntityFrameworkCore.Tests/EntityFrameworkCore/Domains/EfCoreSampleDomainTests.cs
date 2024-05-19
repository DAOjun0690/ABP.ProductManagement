using ABP.ProductManagement.Samples;
using Xunit;

namespace ABP.ProductManagement.EntityFrameworkCore.Domains;

[Collection(ProductManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ProductManagementEntityFrameworkCoreTestModule>
{

}
