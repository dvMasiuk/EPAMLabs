using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToDtoMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Manager, ManagerDto>();
            Mapper.CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager));

        }
    }
}