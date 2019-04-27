using Stone.Framework.Validator.Concretes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Stone.Charging.Messages
{
    public class ChargeSearchMessage
    {
        [DataMember(Name = "cpf")]
        [Cpf(ErrorMessage = "invalid value")]
        public string Cpf { get; set; }

        [DataMember(Name = "referenceMonth")]
        [Range(1, 12, ErrorMessage = "invalid value")]
        public short? ReferenceMonth { get; set; }
    }
}
