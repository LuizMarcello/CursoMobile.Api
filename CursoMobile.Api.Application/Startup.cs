using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CursoMobile.Api.Infra.CrossCutting.InversionOfControl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle.Application;
using Swashbuckle.AspNetCore.SwaggerUI;
using DocExpansion = Swashbuckle.Application.DocExpansion;

namespace CursoMobile.Api.Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapper();
            services.AddMongo(Configuration);
            services.AddRepositories();
            services.AddServices();
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portifólio Vmo");
                c.DocumentTitle = "Api Luiz Marcello";
                c.DocExpansion((Swashbuckle.AspNetCore.SwaggerUI.DocExpansion)DocExpansion.List);
            });
        }
    }
}
            
            
