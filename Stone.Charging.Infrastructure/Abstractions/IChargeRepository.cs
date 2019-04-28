using Stone.Charging.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Infrastructure.Abstractions
{
    public interface IChargeRepository
    {
        Task RegisterAsync(Charge model);
        Task<List<Charge>> GetAsync(string[] cpfs);
        Task<List<Charge>> GetAsync(string cpf, short? referenceMonth);
    }
}
