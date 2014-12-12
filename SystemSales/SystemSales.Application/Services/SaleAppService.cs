using System;
using System.Collections.Generic;
using SystemSales.Application.AutoMapper;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Entities;
using SystemSales.Infrastructure.Repositories;
using AutoMapper;

namespace SystemSales.Application.Services
{
    public class SaleAppService : ISaleAppService, IDisposable
    {
        private readonly SaleRepository _saleRepository = new SaleRepository();

        public SaleAppService()
        {
            Mapper.AddProfile<DtoToEntityMappingProfile>();
            Mapper.AddProfile<EntityToDtoMappingProfile>();
        }
        public void Add(SaleDto entity)
        {
            _saleRepository.Add(Mapper.Map<SaleDto, Sale>(entity));
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

        public void Remove(SaleDto entity)
        {
            _saleRepository.Remove(Mapper.Map<SaleDto, Sale>(entity));
        }

        private bool _disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _saleRepository.Dispose();
            }
            _disposed = true;
        }

        ~SaleAppService()
        {
            Dispose(false);
        }
    }
}