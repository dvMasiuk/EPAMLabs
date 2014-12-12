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
            Mapper.CreateMap<ManagerDto, Manager>();
                //.ForMember(dest => dest.Sales, opt => opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>();
                //.ForMember(dest => dest.Sales, opt => opt.Ignore());
            Mapper.CreateMap<ProductDto, Product>();
                //.ForMember(dest => dest.Sales, opt => opt.Ignore());
            Mapper.CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Manager.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id));
        }
    }
}