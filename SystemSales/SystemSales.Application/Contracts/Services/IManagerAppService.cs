using System.Collections.Generic;
using SystemSales.Application.TransferObjects;

namespace SystemSales.Application.Contracts.Services
{
    public interface IManagerAppService : IAppServiceBase<ManagerDto>
    {
        IEnumerable<ManagerDto> SearchByName(string name);
    }
}
