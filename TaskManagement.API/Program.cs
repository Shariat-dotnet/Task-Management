using Microsoft.EntityFrameworkCore;

using Npgsql;
using Newtonsoft.Json;

using TaskManagement.API.Configureation;
using TaskManagement.Core.Attributes;
using TaskManagement.Core.Common;
using TaskManagement.Core.ConfigurationSettings;
using TaskManagement.Data;
using TaskManagement.Service.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


IConfiguration configuration = Helpers.GetConfiguration();
// Add services to the container.
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
builder.Services.AddSingleton(appSettings);
//Add DB context
builder.Services.AddDatabaseModule(configuration);

//Mediator, dependency
builder.Services
    .AddServiceModule()
    .AddMediaR()
    .AddCors()
    .AddSwaggerModule()
    .AddControllers(config =>
    {
        config.Filters.Add(new ValidateRequestAttribute());
    })
    .AddNewtonsoftJson();
//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseRouting();
app.UseCors(options => options
.WithOrigins(appSettings.AllowedHosts.Split(','))
.AllowAnyMethod()
.AllowAnyHeader()
//.AllowCredentials()
);
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseAppSwagger(configuration);
}
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks("/health");
});


app.Run();
