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
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<SaleDto, Sale>()
                .ForMember(dest => dest.Manager, opt => opt.Condition(src => src.Id > 0 || src.Manager.Id == 0))
                .ForMember(dest => dest.Customer, opt => opt.Condition(src => src.Id > 0 || src.Customer.Id == 0))
                .ForMember(dest => dest.Product, opt => opt.Condition(src => src.Id > 0 || src.Product.Id == 0))
                .ForMember(dest => dest.ManagerId, opt => opt.MapFrom(src => src.Manager.Id))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id));
        }
    }
}