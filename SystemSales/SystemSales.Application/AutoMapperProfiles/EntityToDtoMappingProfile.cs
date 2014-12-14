using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.AutoMapperProfiles
{
    public class EntityToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "EntityToDtoMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Manager, ManagerDto>();
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<Sale, SaleDto>();
        }
    }
}