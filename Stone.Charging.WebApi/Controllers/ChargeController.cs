using Microsoft.AspNetCore.Mvc;
using Stone.Charging.Application.Abstractions;
using Stone.Charging.Messages;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Charging.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargeController : ControllerBase
    {
        private IChargeApplication ChargeApplication { get; }

        public ChargeController(IChargeApplication chargeApplication)
        {
            ChargeApplication = chargeApplication;
        }

        [HttpGet, Produces("application/json", Type = typeof(IApplicationResult<List<ChargeMessage>>))]
        public async Task<IActionResult> GetAsync(ChargeSearchMessage message)
        {
            return await ChargeApplication.GetAsync(message);
        }

        [HttpPost, Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public async Task<IActionResult> RegisterAsync(ChargeMessage message)
        {
            return await ChargeApplication.RegisterAsync(message);
        }
    }
}