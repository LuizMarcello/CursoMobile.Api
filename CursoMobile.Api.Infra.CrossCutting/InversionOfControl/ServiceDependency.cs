using CursoMobile.Api.Domain.Interfaces;
using CursoMobile.Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CursoMobile.Api.Infra.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        //Inversão de controle(IoC)
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceUser, UserService>();
        }
    }
}

