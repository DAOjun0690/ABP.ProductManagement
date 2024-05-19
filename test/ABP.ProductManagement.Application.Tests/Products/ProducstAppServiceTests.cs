using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Modularity;
using Xunit;

namespace ABP.ProductManagement.Products
{
    public class ProducstAppServiceTests<TStartupModule> :　
        ProductManagementApplicationTestBase<TStartupModule> where TStartupModule : IAbpModule
    {
        private readonly IProductAppService _productAppService;

        public ProducstAppServiceTests()
        {
            _productAppService = GetRequiredService<IProductAppService>();
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
}
