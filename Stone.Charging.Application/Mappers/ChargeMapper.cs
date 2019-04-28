using Stone.Charging.Messages;
using Stone.Charging.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Charging.Application.Mappers
{
    public class ChargeMapper
    {
        public static Charge MapTo(ChargeMessage message)
        {
            if (message == null)
                return new Charge();

            return new Charge(message.Cpf, message.Maturity.Value, message.Value.Value);
        }

        public static ChargeMessage MapTo(Charge model)
        {
            if (model == null)
                return new ChargeMessage();

            return new ChargeMessage() { Cpf = model.Cpf, Maturity = model.Maturity, Value = model.Value };
        }

        public static List<ChargeMessage> MapTo(List<Charge> models)
        {
            if (models == null)
                return new List<ChargeMessage>();

            return models.Select(MapTo).ToList();
        }
    }
}
