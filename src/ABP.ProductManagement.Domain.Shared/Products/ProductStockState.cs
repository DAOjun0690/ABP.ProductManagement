using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.ProductManagement.Products
{
    public enum ProductStockState : byte
    {
        PreOrder,
        InStock,
        NotAvailable,
        Stopped
    }
}
