using NSubstitute;
using NSubstitute.Core;
using Stone.Charging.Infrastructure.Abstractions;
using Stone.Charging.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Charging.UnitTest.Helpers
{
    internal static class ChargeRepositoryHelper
    {
        private static List<Charge> Charges { get; set; } = new List<Charge>();

        internal static IChargeRepository GetMock()
        {
            IChargeRepository repositroy = Substitute.For<IChargeRepository>();

            repositroy.GetAsync(Arg.Any<string>(), Arg.Any<short?>()).Returns(GetAsyncReturn);
            repositroy.RegisterAsync(Arg.Any<Charge>()).Returns(RegisterAsyncReturn);

            return repositroy;
        }

        private static List<Charge> GetAsyncReturn(CallInfo info)
        {
            string cpf = info.Args()[0] as string;
            short? referenceMonth = info.Args()[1] as short?;

            return Charges.Where(it => it.Cpf == cpf || it.Maturity.Month == referenceMonth).ToList();
        }

        private static async Task RegisterAsyncReturn(CallInfo info)
        {
            lock(Charges) { Charges.Add(info.Arg<Charge>()); }
        }
    }
}
