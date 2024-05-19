using ABP.ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace ABP.ProductManagement.Products
{
    public class ProductAppService : ProductManagementAppService, IProductAppService
    {
        private readonly IRepository<Product, Guid> _productRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ProductAppService(
            IRepository<Product, Guid> productRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _productRepository = productRepository;
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
    }
}
