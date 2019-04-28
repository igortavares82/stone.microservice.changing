using Stone.Charging.Messages;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.Application.Abstractions
{
    public interface IChargeApplication
    {
        Task<IApplicationResult<List<ChargeMessage>>> GetAsync(ChargeSearchMessage message);
        Task<IApplicationResult<List<ChargeMessage>>> GetAsync(string[] cpfs);
        Task<IApplicationResult<bool>> RegisterAsync(ChargeMessage message);
    }
}
