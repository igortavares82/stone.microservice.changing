using Stone.Framework.Validator.Concretes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Stone.Charging.Messages
{
    [DataContract(Namespace = "http://www.stone.com/charging/charge/type")]
    public class ChargeMessage
    {
        [DataMember(Name = "cpf")]
        [Cpf(ErrorMessage = "invalid value")]
        [Required(ErrorMessage = "field is required")]
        public string Cpf { get; set; }

        [DataMember(Name = "maturity")]
        [Required(ErrorMessage = "field is required")]
        public DateTime? Maturity { get; set; }

        [DataMember(Name = "value")]
        [Required(ErrorMessage = "field is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "invalid value ")]
        public decimal? Value { get; set; }
    }
}
