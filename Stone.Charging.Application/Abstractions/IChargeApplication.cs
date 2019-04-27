using Stone.Charging.Messages;
using Stone.Framework.Result.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Application.Abstractions
{
    public interface IChargeApplication
    {
        Task<IApplicationResult<List<ChargeMessage>>> GetAsync(ChargeSearchMessage message);
        Task<IApplicationResult<bool>> RegisterAsync(ChargeMessage message);
    }
}
