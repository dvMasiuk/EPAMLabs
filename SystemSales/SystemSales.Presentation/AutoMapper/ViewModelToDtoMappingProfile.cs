﻿using SystemSales.Application.TransferObjects;
using SystemSales.Presentation.Models;
using AutoMapper;

namespace SystemSales.Presentation.AutoMapper
{
    public class ViewModelToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDtoMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ManagerViewModel, ManagerDto>();
            Mapper.CreateMap<CustomerViewModel, CustomerDto>();
            Mapper.CreateMap<ProductViewModel, ProductDto>();
            Mapper.CreateMap<SaleViewModel, SaleDto>();
        }
    }
}