using System.Collections.Generic;
using SystemSales.Application.Contracts.Services;
using SystemSales.Application.TransferObjects;
using SystemSales.Domain.Contracts.Repositories;
using SystemSales.Domain.Entities;
using AutoMapper;

namespace SystemSales.Application.Services
{
    public class ManagerAppService : IManagerAppService
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerAppService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public void Insert(ManagerDto entity)
        {
            _managerRepository.Insert(Mapper.Map<ManagerDto, Manager>(entity));
        }

        public ManagerDto GetById(int id)
        {
            return Mapper.Map<Manager, ManagerDto>(_managerRepository.GetById(id));
        }

        public IEnumerable<ManagerDto> GetAll()
        {
            return Mapper.Map<IEnumerable<Manager>, IEnumerable<ManagerDto>>(_managerRepository.GetAll());
        }

        public void Update(ManagerDto entity)
        {
            _managerRepository.Update(Mapper.Map<ManagerDto, Manager>(entity));
        }

        public void Delete(int id)
        {
            _managerRepository.Delete(id);
        }

        public IEnumerable<ManagerDto> SearchByName(string name)
        {
            return Mapper.Map<IEnumerable<Manager>, IEnumerable<ManagerDto>>(_managerRepository.SearchByName(name));
        }
    }
}
