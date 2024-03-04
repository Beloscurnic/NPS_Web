using Application.Service.Token;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.Service.URL_API;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddSingleton<URL_Admin_NPS>();
            services.AddSingleton<URL_User_NPS>();
            services.AddSingleton<GlobalQuery>();
            services.AddTransient<ITokenService, TokenService>();
            return services;
        }
    }
}
