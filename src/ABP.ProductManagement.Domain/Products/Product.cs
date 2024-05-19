using ABP.ProductManagement.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ABP.ProductManagement.Products
{
    /// <summary>
    /// FullAuditedAggregateRoot 類 有軟刪除功能
    /// </summary>
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 正常DDD 不會有此屬性，但規矩是死的，有此項我們會更好操作
        /// </summary>
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsFreeCargo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductStockState StockState { get; set; }
    }
}
