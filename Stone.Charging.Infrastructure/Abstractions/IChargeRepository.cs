using Stone.Charging.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Charging.Infrastructure.Abstractions
{
    public interface IChargeRepository
    {
        Task RegisterAsync(Charge model);
        Task<List<Charge>> GetAsync(string cpf, DateTime? maturity);
    }
}
