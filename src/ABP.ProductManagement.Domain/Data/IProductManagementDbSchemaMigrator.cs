using System.Threading.Tasks;

namespace ABP.ProductManagement.Data;

public interface IProductManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
