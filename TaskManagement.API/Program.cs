using Microsoft.EntityFrameworkCore;

using Npgsql;

using TaskManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../TaskManagement.Data/Configs/dataSetting.json");
var connectionString = builder.Configuration["PostgreSql:db_conn_string"];
var dbPassword = builder.Configuration["PostgreSql:DbPassword"];
var builders = new NpgsqlConnectionStringBuilder(connectionString)
{
    Password = dbPassword
};
builder.Services.AddDbContext<TaskManagementDbContext>(options => options.UseNpgsql(builders.ConnectionString));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
