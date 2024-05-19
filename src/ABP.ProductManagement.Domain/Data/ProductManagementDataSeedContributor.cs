using ABP.ProductManagement.Categories;
using ABP.ProductManagement.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ABP.ProductManagement.Data
{
    public class ProductManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<Product, Guid> _productRepository;

        public ProductManagementDataSeedContributor(
            IRepository<Category, Guid> categoryRepository,
            IRepository<Product, Guid> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _categoryRepository.CountAsync() > 0)
            {
                return;
            }

            var phones = new Category { Name = "Phone" };
            var pads = new Category { Name = "Pad" };
            await _categoryRepository.InsertManyAsync(new[] { phones, pads });

            var phone1 = new Product
            {
                Category = phones,
                Name = "小米 Redmi K60 至尊版",
                Price = 3699,
                ReleaseDate = new DateTime(2023, 08, 14),
                StockState = ProductStockState.PreOrder
            };
            var phone2 = new Product
            {
                Category = phones,
                Name = "iQOO 11S 16GB",
                Price = 4399,
                ReleaseDate = new DateTime(2023, 07, 08),
                StockState = ProductStockState.InStock
            };
            var pad1 = new Product
            {
                Category = pads,
                Name = "聯想拯救者 Y700",
                Price = 2799,
                ReleaseDate = new DateTime(2023, 08, 10),
                StockState = ProductStockState.PreOrder
            };
            var pad2 = new Product
            {
                Category = pads,
                Name = "小米平板 6 Max",
                Price = 2999,
                ReleaseDate = new DateTime(2023, 08, 14),
                StockState = ProductStockState.NotAvailable
            };

            await _productRepository.InsertManyAsync(new[] { phone1, phone2, pad1, pad2 });
        }
    }
}
