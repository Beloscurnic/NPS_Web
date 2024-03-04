using Application;
using FluentValidation.AspNetCore;
using ISNPSWeb.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ISNPSWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                var services = builder.Services;

                services.AddApplication();
                builder.Services.AddControllersWithViews();

                builder.Services.AddMvc();

                services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
                services.AddTransient<RefreshToken>();

                services.AddRazorPages()
                    .AddViewLocalization()
                    .AddSessionStateTempDataProvider();
          
                services.AddControllersWithViews()
                    .AddSessionStateTempDataProvider();

                services.AddDistributedMemoryCache();

                services.Configure<IISServerOptions>(options =>
                {
                    options.AutomaticAuthentication = false;
                });

                //Added sessions
                services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(40);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });

                services.AddHttpContextAccessor();
                services.AddDataProtection();

                services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.Events = new CookieAuthenticationEvents
                        {
                            OnRedirectToLogin = context =>
                            {
                                //определяется как относительный URL до страницы входа (/Account/Login) с учетом запроса
                                //может содержать дополнительные данные включая исходную строницу рендиректа
                                string relativeRedirectUri = new Uri(context.RedirectUri).PathAndQuery;

                                if (IsJquery.IsAjaxRequest(context.Request))
                                {
                                    context.Response.Headers["Location"] = relativeRedirectUri;
                                    context.Response.StatusCode = 401;
                                }
                                else
                                {
                                    context.Response.Redirect(relativeRedirectUri);
                                }
                                return Task.CompletedTask;
                            }
                        };
                    });

                //Added fluent validation
                services.AddControllers().AddFluentValidation(options =>
                {
                    // Automatic registration of validators in assembly
                    //options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                    options.RegisterValidatorsFromAssemblyContaining<Program>();
                    options.LocalizationEnabled = true;
                });

               // ValidatorViewModel validatorViewModel = new ValidatorViewModel(services);

                //services.AddScoped<IViewRenderService, ViewRenderService>();
                services.AddScoped<ICurrentUserService, CurrentUserService>();

                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }
                else
                {
                    app.UseDeveloperExceptionPage();
                }
              
                app.Use(async (context, next) =>
                {
                    await next();
                    if (context.Response.StatusCode == 404)
                    {
                        context.Request.Path = "/404";
                        await next();
                    }
                });
                app.UseHttpsRedirection();

                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthentication();
                app.UseAuthorization();

                app.UseSession();

                app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}