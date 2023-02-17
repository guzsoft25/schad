using AutoMapper;
using Ecommerce.Shared.Models.Daos;
using Ecommerce.Shared.Models.Dtos;

namespace Ecommerce.Business.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDao, CustomerDto>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Rnc, opt => opt.MapFrom(src => src.Rnc))
               .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.CustomerType.Description))
               .ForMember(dest => dest.CustomerTypeId, opt => opt.MapFrom(src => src.CustomerType.CustomerTypeId));


            CreateMap<CustomerDto, CustomerDao>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
               .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
               .ForMember(dest => dest.Rnc, opt => opt.MapFrom(src => src.Rnc))
               .ForMember(dest => dest.CustomerType, act => act.Ignore());

            //ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => new CustomerTypeDao { CustomerTypeId = src.CustomerTypeId, Description = src.CustomerType }));
        }
    }
}
