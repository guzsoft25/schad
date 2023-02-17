namespace Ecommerce.Business.Profiles
{
    using AutoMapper;
    using Ecommerce.Shared.Models.Daos;
    using Ecommerce.Shared.Models.Dtos;

    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDao, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.productCategory.CategoryName));



                
        }
    }
}
