using ABP.ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ABP.ProductManagement.Products
{
    public interface IProductAppService : IApplicationService
    {
        Task<PagedResultDto<ProductDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task CreateAsync(CreateUpdateProductDto input);
        /// <summary>
        ///  新增產品時，顯示類別的下拉選單
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<CategoryLookupDto>> GetCategoriesAsync();
        /// <summary>
        /// 查詢指定產品，用id查詢
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductDto> GetAsync(Guid id);
        /// <summary>
        /// 更新指定id的產品
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task UpdateAsync(Guid id, CreateUpdateProductDto input);

        Task DeleteAsync(Guid id);
    }
}
