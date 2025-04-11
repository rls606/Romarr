using System.Net;
using System.Net.Mail;

using Romarr.Application.Common.Interfaces;
using Romarr.Infrastructure.Common;
using Romarr.Infrastructure.Reminders.BackgroundServices;
using Romarr.Infrastructure.Reminders.Persistence;
using Romarr.Infrastructure.Security;
using Romarr.Infrastructure.Security.CurrentUserProvider;
using Romarr.Infrastructure.Security.PolicyEnforcer;
using Romarr.Infrastructure.Security.TokenGenerator;
using Romarr.Infrastructure.Security.TokenValidation;
using Romarr.Infrastructure.Services;
using Romarr.Infrastructure.Users.Persistence;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        services.AddEmailNotifications(configuration);

        return services;
    }

    private static IServiceCollection AddEmailNotifications(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        EmailSettings emailSettings = new();
        configuration.Bind(EmailSettings.Section, emailSettings);

        if (!emailSettings.EnableEmailNotifications)
        {
            return services;
        }

        services.AddHostedService<ReminderEmailBackgroundService>();

        services
            .AddFluentEmail(emailSettings.DefaultFromEmail)
            .AddSmtpSender(new SmtpClient(emailSettings.SmtpSettings.Server)
            {
                Port = emailSettings.SmtpSettings.Port,
                Credentials = new NetworkCredential(
                    emailSettings.SmtpSettings.Username,
                    emailSettings.SmtpSettings.Password),
            });

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = Romarr.sqlite"));

        services.AddScoped<IRemindersRepository, RemindersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

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

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        return services;
    }
}