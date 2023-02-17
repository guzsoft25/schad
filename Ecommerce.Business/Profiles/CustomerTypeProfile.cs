using AutoMapper;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Profiles
{
    public class CustomerTypeProfile : Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerTypeDao, CustomerTypeDto>()
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.CustomerTypeId, opt => opt.MapFrom(src => src.CustomerTypeId))
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<CustomerTypeDto, CustomerTypeDao>()
           .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
           .ForMember(dest => dest.CustomerTypeId, opt => opt.MapFrom(src => src.CustomerTypeId))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
