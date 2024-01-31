
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Product , ProductToReturnDto>()
            .ForMember(d => d.productbrand , o => o.MapFrom(s => s.productbrand.name))
            .ForMember(d => d.producttype , o => o.MapFrom(s => s.producttype.name))
            .ForMember(d => d.pictureUrl , o => o.MapFrom<ProductUrlResolver>());
            
        }
    }
}