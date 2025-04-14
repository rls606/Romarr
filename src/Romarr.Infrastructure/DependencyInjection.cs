using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Romarr.Application.Common.Interfaces;
using Romarr.Infrastructure.Common;
using Romarr.Infrastructure.Security;
using Romarr.Infrastructure.Security.CurrentUserProvider;
using Romarr.Infrastructure.Security.PolicyEnforcer;
using Romarr.Infrastructure.Security.TokenGenerator;
using Romarr.Infrastructure.Security.TokenValidation;

namespace Romarr.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHttpContextAccessor()
            .AddServices()
            .AddBackgroundServices(configuration)
            .AddAuthentication(configuration)
            .AddAuthorization()
            .AddPersistence();

        return services;
    }

    private static IServiceCollection AddBackgroundServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }


    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = Romarr.sqlite"));

        return services;
    }

    private static IServiceCollection AddAuthorization(this IServiceCollection services)
    {
        services.AddScoped<IAuthorizationService, AuthorizationService>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        services.AddSingleton<IPolicyEnforcer, PolicyEnforcer>();

        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section));

        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}