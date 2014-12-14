using System.Collections.Generic;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.Services
{
    public class SaleAppService : ISaleAppService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleAppService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public void Insert(SaleDto entity)
        {
            _saleRepository.Insert(Mapper.Map<SaleDto, Sale>(entity));
        }

        public SaleDto GetById(int id)
        {
            return Mapper.Map<Sale, SaleDto>(_saleRepository.GetById(id));
        }

        public IEnumerable<SaleDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDto>>(_saleRepository.GetAll());
        }

        public void Update(SaleDto entity)
        {
            _saleRepository.Update(Mapper.Map<SaleDto, Sale>(entity));
        }

        public void Delete(int id)
        {
            _saleRepository.Delete(id);
        }
    }
}