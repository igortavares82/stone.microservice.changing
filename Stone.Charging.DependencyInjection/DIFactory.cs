using Microsoft.Extensions.DependencyInjection;
using Stone.Charging.Application.Abstractions;
using Stone.Charging.Application.Concretes;
using Stone.Charging.Domain.Abstractions.EntityService;
using Stone.Charging.Domain.Concretes.EntityService;
using Stone.Charging.Infrastructure.Abstractions;
using Stone.Charging.Infrastructure.Concretes;
using System;

namespace Stone.Charging.DependencyInjection
{
    public static class DIFactory
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IChargeApplication, ChargeApplication>();
            services.AddScoped<IChargeEntityService, ChargeEntityService>();
            services.AddScoped<IChargeRepository, ChargeRepository>();
        }
    }
}
