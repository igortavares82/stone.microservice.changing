using Stone.Charging.Application.Abstractions;
using Stone.Charging.Application.Mappers;
using Stone.Charging.Domain.Abstractions.EntityService;
using Stone.Charging.Messages;
using Stone.Charging.Models.Entities;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Application.Concretes
{
    public class ChargeApplication : IChargeApplication
    {
        private IChargeEntityService ChargeEntityService { get; }

        public ChargeApplication(IChargeEntityService chargeEntityService)
        {
            ChargeEntityService = chargeEntityService;
        }

        public async Task<IApplicationResult<List<ChargeMessage>>> GetAsync(ChargeSearchMessage message)
        {
            IDomainResult<List<Charge>> domainResult = await ChargeEntityService.GetAsync(message.Cpf, message.ReferenceMonth);
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => ChargeMapper.MapTo(domain));
        }

        public async Task<IApplicationResult<bool>> RegisterAsync(ChargeMessage message)
        {
            IDomainResult<bool> domainResult = await ChargeEntityService.RegisterAsync(ChargeMapper.MapTo(message));
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }

        public async Task<IApplicationResult<bool>> RegisterAsync(List<ChargeMessage> messages)
        {
            IDomainResult<bool> domainResult = await ChargeEntityService.RegisterAsync(ChargeMapper.MapTo(messages));
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => domain);
        }
    }
}
