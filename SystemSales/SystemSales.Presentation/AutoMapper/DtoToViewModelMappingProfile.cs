using SystemSales.Application.TransferObjects;
using SystemSales.Presentation.Models;
using AutoMapper;

namespace SystemSales.Presentation.AutoMapper
{
    public class DtoToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<SaleDto, SaleModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name));
            Mapper.CreateMap<SaleDto, SaleModel>()
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager.SecondName));
            Mapper.CreateMap<SaleDto, SaleModel>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}