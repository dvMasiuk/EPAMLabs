using SystemSales.Application.TransferObjects;
using SystemSales.Presentation.Models;
using AutoMapper;

namespace SystemSales.Presentation.AutoMapper
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ManagerDto, ManagerViewModel>();
            Mapper.CreateMap<CustomerDto, CustomerViewModel>();
            Mapper.CreateMap<ProductDto, ProductViewModel>();
            Mapper.CreateMap<SaleDto, SaleViewModel>();
        }
    }
}