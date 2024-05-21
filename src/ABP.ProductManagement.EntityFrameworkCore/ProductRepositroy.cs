using ABP.ProductManagement.EntityFrameworkCore;
using ABP.ProductManagement.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ABP.ProductManagement
{
    public class ProductRepositroy : EfCoreRepository<ProductManagementDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepositroy(IDbContextProvider<ProductManagementDbContext>
            dbContextProvider) : base(dbContextProvider)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stockState"></param>
        /// <param name="includeCategory">是否包含類別</param>
        /// <returns></returns>

        public async Task<List<Product>> GetListAsync(ProductStockState stockState, bool includeCategory = false)
        {
            var dbContext = await GetDbContextAsync();
            var query = dbContext.Products
                .Where(x => x.StockState == stockState)
                .IncludeIf(includeCategory, Product => Product.Category);

            return await query.ToListAsync();
        }

        public Task<List<Product>> GetListAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
