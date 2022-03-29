using AutoMapper;
using WhyzrOnBoarding.Products;
namespace WhyzrOnBoarding
{
    public class WhyzrOnBoardingApplicationAutoMapperProfile : Profile
    {
        public WhyzrOnBoardingApplicationAutoMapperProfile()
        {
            //CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();

            //CreateMap<VariantDto, Variant>();
            CreateMap<Variant, VariantDto>();

            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<CreateUpdateVariantDto, Variant>();
            
            //create 
        }
    }
}
