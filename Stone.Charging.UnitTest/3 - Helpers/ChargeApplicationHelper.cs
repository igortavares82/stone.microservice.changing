using NSubstitute;
using Stone.Charging.Application.Abstractions;
using Stone.Charging.Application.Concretes;

namespace Stone.Charging.UnitTest.Helpers
{
    internal class ChargeApplicationHelper
    {
        internal static IChargeApplication GetMock()
        {
            return Substitute.For<ChargeApplication>(ChargeEntityServiceHelper.GetMock());
        }
    }
}
