using NSubstitute;
using Stone.Charging.Domain.Abstractions.EntityService;
using Stone.Charging.Domain.Concretes.EntityService;

namespace Stone.Charging.UnitTest.Helpers
{
    internal class ChargeEntityServiceHelper
    {
        internal static IChargeEntityService GetMock()
        {
            return Substitute.For<ChargeEntityService>(ChargeRepositoryHelper.GetMock());
        }
    }
}
