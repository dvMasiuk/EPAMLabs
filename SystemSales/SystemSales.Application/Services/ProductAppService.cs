using System.Collections.Generic;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;

        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Insert(ProductDto entity)
        {
            _productRepository.Insert(Mapper.Map<ProductDto, Product>(entity));
        }

        public ProductDto GetById(int id)
        {
            return Mapper.Map<Product, ProductDto>(_productRepository.GetById(id));
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_productRepository.GetAll());
        }

        public void Update(ProductDto entity)
        {
            _productRepository.Update(Mapper.Map<ProductDto, Product>(entity));
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public IEnumerable<ProductDto> SearchByName(string name)
        {
            return Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(_productRepository.SearchByName(name));
        }
    }
}
