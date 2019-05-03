using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Charging.DependencyInjection;
using Stone.Framework.Filter.Concretes;
using System.IO;
using Stone.Charging.WebApi.Configurations;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;

namespace Stone.Charging.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationBuilder Builder { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Builder = new ConfigurationBuilder()
                     .SetBasePath(Path.Combine(env.ContentRootPath, "Settings"))
                     .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddJsonFile("firebasesettings.json", optional: true, reloadOnChange: true);

            Builder.AddEnvironmentVariables();
            Configuration = Builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureOptions(Configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options => options.Filters.Add(new ValidateModelStateAttribute()));

            DIFactory.Configure(services);

            services.AddSwaggerGen(s => 
            {
                s.SwaggerDoc("v1", new Info { Title = "Charging microservice API", Version = "v1" });

                string applicationPath = PlatformServices.Default.Application.ApplicationBasePath;
                string applicationName = PlatformServices.Default.Application.ApplicationName;
                string xmlDocPath = Path.Combine(applicationPath, $"{applicationName}.xml");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Charge application");
            });

        }
    }
}
