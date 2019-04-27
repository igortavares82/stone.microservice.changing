using Microsoft.Extensions.Options;
using Stone.Charging.Infrastructure.Abstractions;
using Stone.Charging.Models.Entities;
using Stone.Framework.Data.Concretes;
using Stone.Framework.Data.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Charging.Infrastructure.Concretes
{
    public class ChargeRepository : FirebaseRepository<Charge>, IChargeRepository
    {
        public ChargeRepository(IOptions<FirebaseClientOptions> clientOptions) : base(clientOptions) { }

        public async Task<List<Charge>> GetAsync(string cpf, short? referenceMonth)
        {
            IEnumerable<Charge> charges = await base.GetAsync(it => it.Cpf == cpf || it.Maturity.Month == referenceMonth);
            return charges.ToList();
        }

        public async Task RegisterAsync(Charge model)
        {
            await base.InsertAsync(model);
        }
    }
}
