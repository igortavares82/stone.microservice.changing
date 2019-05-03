using Stone.Charging.Models.Entities;
using Stone.Framework.Utils.Cpf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Charging.UnitTest.DataProviders
{
    internal static class ChargeDataProvider
    {
        private static List<Charge> charges = new List<Charge>()
        {
            new Charge() { Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now, Value = 50.10M },
            new Charge() { Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now.AddMonths(1), Value = 650.20M },
            new Charge() { Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now.AddMonths(2), Value = 2050.30M }
        };

        public static IEnumerable<object[]> GetClients()
        {
            yield return new object[] { charges, charges.First().Cpf, (short?)charges.First().Maturity.Month };
        }

        public static IEnumerable<object[]> GetValidSearch()
        {
            yield return new object[] { charges.First().Cpf, charges.First().Maturity.Month };
        }

        public static IEnumerable<object[]> GetSearchByReferenceMonth()
        {
            yield return new object[] { charges, null, (short?)charges.First().Maturity.Month };
        }

        public static IEnumerable<object[]> GetSearchByCpf()
        {
            yield return new object[] { charges, charges.First().Cpf, null };
        }

        public static IEnumerable<object[]> GetInvalidSearch()
        {
            yield return new object[] { charges, null, null };
        }
    }
}
