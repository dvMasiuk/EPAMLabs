using System.Collections.Generic;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Insert(CustomerDto entity)
        {
            _customerRepository.Insert(Mapper.Map<CustomerDto, Customer>(entity));
        }

        public CustomerDto GetById(int id)
        {
            return Mapper.Map<Customer, CustomerDto>(_customerRepository.GetById(id));
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(_customerRepository.GetAll());
        }

        public void Update(CustomerDto entity)
        {
            _customerRepository.Update(Mapper.Map<CustomerDto, Customer>(entity));
        }

        public void Delete(int id)
        {
            _customerRepository.Delete(id);
        }

        public IEnumerable<CustomerDto> SearchByName(string name)
        {
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(_customerRepository.SearchByName(name));
        }
    }
}
