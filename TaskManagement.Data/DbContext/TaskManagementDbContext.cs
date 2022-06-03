using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace TaskManagement.Data;

//public class AppConfiguration
//{
//    public readonly IConfigurationRoot Configuration;
//    public AppConfiguration()
//    {
//        Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../TaskManagement.Data/Configs/dataSetting.json").Build();
//    }
//}
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskManagementDbContext>
{
    public TaskManagementDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../TaskManagement.Data/Configs/dataSetting.json").Build();
        var builder = new DbContextOptionsBuilder<TaskManagementDbContext>();
        var connectionString = configuration["PostgreSql:db_conn_string"];
        builder.UseNpgsql(connectionString);
        return new TaskManagementDbContext(builder.Options);
    }
}
public class TaskManagementDbContext : IdentityDbContext<ApplicationUser>
{


    public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options)
       : base(options)
    {
    }
    public DbSet<TaskManagement.Core.Domains.TaskModel> Tasks { get; set; }
   

}

public class ApplicationUser : IdentityUser
{
}
