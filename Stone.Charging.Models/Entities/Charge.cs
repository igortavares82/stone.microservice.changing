using System;

namespace Stone.Charging.Models.Entities
{
    public class Charge
    {
        public Charge() { }

        public Charge(string cpf, DateTime maturity, decimal value)
        {
            Cpf = cpf;
            Maturity = maturity;
            Value = value;
        }

        public string Cpf { get; set; }
        public DateTime Maturity { get; set; }
        public decimal Value { get; set; }
    }
}
