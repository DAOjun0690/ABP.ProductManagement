using ABP.ProductManagement.Products;
using ABP.ProductManagement.Web.Pages.Products;
using AutoMapper;

namespace ABP.ProductManagement.Web;

public class ProductManagementWebAutoMapperProfile : Profile
{
    public ProductManagementWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CreateEditProductViewModel, CreateUpdateProductDto>();
    }
}
