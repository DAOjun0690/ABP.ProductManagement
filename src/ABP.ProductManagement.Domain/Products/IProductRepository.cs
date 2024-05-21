using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ABP.ProductManagement.Products
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<List<Product>> GetListAsync(ProductStockState stockState, bool includeCategory = false);
    }
}
