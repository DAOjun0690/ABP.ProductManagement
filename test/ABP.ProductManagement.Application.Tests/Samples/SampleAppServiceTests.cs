using ABP.ProductManagement.Products;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Xunit;

namespace ABP.ProductManagement.Samples;

/* This is just an example test class.
 * Normally, you don't test code of the modules you are using
 * (like IIdentityUserAppService here).
 * Only test your own application services.
 */
public abstract class SampleAppServiceTests<TStartupModule> : ProductManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly IIdentityUserAppService _userAppService;
    private readonly IProductAppService _productAppService;

    protected SampleAppServiceTests()
    {
        _userAppService = GetRequiredService<IIdentityUserAppService>();
        _productAppService = GetRequiredService<IProductAppService>();
    }

    [Fact]
    public async Task Initial_Data_Should_Contain_Admin_User()
    {
        //Act
        var result = await _userAppService.GetListAsync(new GetIdentityUsersInput());

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.Items.ShouldContain(u => u.UserName == "admin");
    }

    [Fact]
    public async Task Should_Get_Product_List()
    {
        //Act
        var result = await _productAppService.GetListAsync(new PagedAndSortedResultRequestDto());

        //Assert
        result.TotalCount.ShouldBe(4);
        result.Items.ShouldContain(u => u.Name.Contains("小米 Redmi K60 至尊版"));
    }
}
