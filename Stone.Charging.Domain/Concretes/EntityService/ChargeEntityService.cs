using Stone.Charging.Domain.Abstractions.EntityService;
using Stone.Charging.Infrastructure.Abstractions;
using Stone.Charging.Models.Entities;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Concretes;
using Stone.Framework.Result.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Domain.Concretes.EntityService
{
    public class ChargeEntityService : IChargeEntityService
    {
        private IChargeRepository ChargeRepository { get; }

        public ChargeEntityService(IChargeRepository chargeRepository)
        {
            ChargeRepository = chargeRepository;
        }

        public async Task<IDomainResult<List<Charge>>> GetAsync(string cpf, short? referenceMonth)
        {
            IDomainResult<List<Charge>> result = new DomainResult<List<Charge>>();

            if (string.IsNullOrEmpty(cpf) && !referenceMonth.HasValue)
            {
                result.ResulType = DomainResultType.DomainError;
                result.Messages.Add("At least one of those parameters must be settled");
            }
            else
            {
                result.ResulType = DomainResultType.Success;
                result.Data = await ChargeRepository.GetAsync(cpf, referenceMonth);
            }

            return result;
        }

        public async Task<IDomainResult<bool>> RegisterAsync(Charge model)
        {
            IDomainResult<bool> result = new DomainResult<bool>();

            await ChargeRepository.RegisterAsync(model);

            result.Data = true;
            result.ResulType = DomainResultType.Success;
            result.Messages.Add("Charge has been registered successfully");

            return result;
        }
    }
}
