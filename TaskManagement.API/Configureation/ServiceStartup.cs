using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Npgsql;

using TaskManagement.Core.ConfigurationSettings;
using TaskManagement.Core.Domains;
using TaskManagement.Core.Infrastructure.Factory;
using TaskManagement.Core.Interfaces.Database;
using TaskManagement.Core.Repository;
using TaskManagement.Data;
using TaskManagement.Data.Repositories;

namespace TaskManagement.API.Configureation;

public static class ServiceStartup
{

    public static IServiceCollection AddDatabaseModule(this IServiceCollection services, IConfiguration configuration)
    {

        var appSettingsSection = configuration.GetSection("AppSettings");
        var appSettings = appSettingsSection.Get<AppSettings>();

        var builders = new NpgsqlConnectionStringBuilder(appSettings.PostgreSql.db_conn_string)
        {
            Password = appSettings.PostgreSql.password
        };
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<TaskManagementDbContext>(options => options.UseNpgsql(builders.ConnectionString));
        return services;
    }
    public static IServiceCollection AddSwaggerModule(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Task Management",
                Version = "v1",
                Description = "Swagger aides in development across the entire API lifecycle, from design and documentation, to test and deployment.",
            });
           
        });
        return services;
    }

    public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseSwagger(c =>
        {
            c.SerializeAsV2 = true;
            c.RouteTemplate = "taskManagement/{documentName}/swagger.json";
        });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/taskManagement/v1/swagger.json", "Task Management");
            c.RoutePrefix = "taskManagement";
        });
        return app;
    }
    public static IServiceCollection AddServiceModule(this IServiceCollection services)
    {
        // services will be added here by the generator
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITaskManagementHttpClientFactory, TaskManagementHttpClientFactory>();

        services.AddScoped<IRepository<TaskModel>, Repository<TaskModel>>();
        //services.AddScoped<IBCKDService, BCKDService>();
        return services;

    }


}
