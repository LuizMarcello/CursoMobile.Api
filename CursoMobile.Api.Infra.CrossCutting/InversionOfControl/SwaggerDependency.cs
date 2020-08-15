using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle;
using Swashbuckle.Swagger;
using Microsoft.OpenApi.Models;

namespace CursoMobile.Api.Infra.CrossCutting.InversionOfControl
{
    public static class SwaggerDependency
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1",
                    //new Info
                    //new Microsoft.OpenApi.Models.OpenApiInfo
                    new OpenApiInfo
                    {
                        Title = "Api Luiz Marcello",
                        Version = "v1",
                        Description = "Portifólio Vmo"
                    });
            });
        }
    }
}
