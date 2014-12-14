using System.Collections.Generic;
using SystemSales.Application.TransferObjects;

namespace SystemSales.Application.Contracts.Services
{
    public interface ICustomerAppService : IAppServiceBase<CustomerDto>
    {
        IEnumerable<CustomerDto> SearchByName(string name);
    }
}