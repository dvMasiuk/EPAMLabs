using System.Collections.Generic;
using SystemSales.Application.TransferObjects;

namespace SystemSales.Application.Contracts.Services
{
    public interface IProductAppService : IAppServiceBase<ProductDto>
    {
        IEnumerable<ProductDto> SearchByName(string name);
    }
}
