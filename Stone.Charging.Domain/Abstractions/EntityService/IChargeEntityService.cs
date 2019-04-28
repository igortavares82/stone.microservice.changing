using Stone.Charging.Models.Entities;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Domain.Abstractions.EntityService
{
    public interface IChargeEntityService
    {
        Task<IDomainResult<List<Charge>>> GetAsync(string cpf, short? referenceMonth);
        Task<IDomainResult<List<Charge>>> GetAsync(string[] cpfs);
        Task<IDomainResult<bool>> RegisterAsync(Charge model);
    }
}
