using Microsoft.EntityFrameworkCore;
using OpheliaLab.ApplicationCore.Interfaces;
using OpheliaLab.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDB(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<InvoiceContext>(c => c.UseSqlServer(connectionString))
               .BuildServiceProvider();

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));
            //services.AddScoped<ICountryService, CountryService>();
            //services.AddScoped<IGroupService, GroupService>();
            //services.AddScoped<ISeasonService, SeasonService>();
            //services.AddScoped<ITypeOfCompetitionService, TypeOfCompetitionService>();
            //services.AddScoped<IContinentService, ContinentService>();
            //services.AddScoped<IMatchStatusService, MatchStatusService>();

            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            //services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            //services.AddTransient<IEmailSender, EmailSender>();

            //// Add memory cache services
            //services.AddMemoryCache();

            return services;
        }

        public static IServiceCollection AddCorsApp(this IServiceCollection services, string name) =>
            services.AddCors(options =>
            {
                options.AddPolicy(name,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200",
                                                          "https://localhost:4200")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                  });
            });
    }
}
