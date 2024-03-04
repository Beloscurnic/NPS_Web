using Application.Requests.Commands.Authorize_User;
using Application.Requests.Commands.ForgotPassword;
using Application.Service;
using Application.Service.Token;
using Application.Service.URL_API;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddTransient<IValidator<ForgotPas.Command>, ForgotPas.Validation>();
            services.AddTransient<IValidator<User_Authorize.Command>, Auth_User_Validation>();
            return services;
        }
    }
}
