using ABP.ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace ABP.ProductManagement.Products
{
    public class ProductAppService : ProductManagementAppService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        //private readonly IRepository<Product, Guid> _productRepository;
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ProductAppService(
            IProductRepository productRepository,
            IRepository<Category, Guid> categoryRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<PagedResultDto<ProductDto>> GetListAsync
            (PagedAndSortedResultRequestDto input)
        {
            var queryable = await _productRepository.WithDetailsAsync(x => x.Category);

            queryable = queryable.Skip(input.SkipCount)
                .Take(input.MaxResultCount) // IQueryable<Product>
                .OrderBy(input.Sorting ?? nameof(Product.Name)); // IOrderQueryable<Product>

            var products = await AsyncExecuter.ToListAsync(queryable);
            var count = await _productRepository.GetCountAsync();

            return new PagedResultDto<ProductDto>(
                count,
                ObjectMapper.Map<List<Product>, List<ProductDto>>(products));
        }

        async Task IProductAppService.CreateAsync(CreateUpdateProductDto input)
        {
            var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(input);
            await _productRepository.InsertAsync(product);
        }

        async Task<ListResultDto<CategoryLookupDto>> IProductAppService.GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetListAsync();
            var categoryLookupDtos = ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>(categories);
            return new ListResultDto<CategoryLookupDto>(categoryLookupDtos);
        }

        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);
            // ef core 有實體追蹤功能，所以只要查詢出來，更新model後，會在請求結束時，保存更新資料。
            ObjectMapper.Map(input, product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id); // 軟刪除
        }
    }
}
