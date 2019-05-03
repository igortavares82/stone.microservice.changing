using Stone.Charging.Messages;
using Stone.Framework.Utils.Cpf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Charging.UnitTest.DataProviders
{
    public class ChargeMessageDataProvider
    {
        private static List<ChargeMessage> charges = new List<ChargeMessage>()
        {
            new ChargeMessage(){ Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now, Value = 50.00M },
            new ChargeMessage(){ Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now, Value = 50.10M },
            new ChargeMessage(){ Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now.AddMonths(1), Value = 50.20M },
            new ChargeMessage(){ Cpf = CpfGenerator.Generate(), Maturity = DateTime.Now.AddMonths(2), Value = 50.30M }
        };

        public static IEnumerable<object[]> GetValidCharge()
        {
            yield return new object[] { charges.First() };
        }

        public static IEnumerable<object[]> GetInvalidCpfChargeMessage()
        {
            ChargeMessage charge = charges[1];
            charge.Cpf = charge.Cpf.Insert(10, "2");

            yield return new object[] { charge };
        }

        public static IEnumerable<object[]> GetInvalidMatirityChargeMessage()
        {
            ChargeMessage charge = charges[2];
            charge.Maturity = null;

            yield return new object[] { charge };
        }

        public static IEnumerable<object[]> GetInvalidValueChargeMessage()
        {
            ChargeMessage charge = charges[3];
            charge.Value = 0;

            yield return new object[] { charge };
        }
    }
}
