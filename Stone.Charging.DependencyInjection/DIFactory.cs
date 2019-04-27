using Microsoft.Extensions.DependencyInjection;
using Stone.Charging.Infrastructure.Abstractions;
using Stone.Charging.Infrastructure.Concretes;
using System;

namespace Stone.Charging.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IChargeRepository, ChargeRepository>();
        }
    }
}
