using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToEntityMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<ManagerDto, Manager>();
            Mapper.CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager));
        }
    }
}