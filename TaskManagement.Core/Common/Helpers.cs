using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TaskManagement.Core.Common
{
    public static class Helpers
    {
        public static IConfiguration GetConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../TaskManagement.Data/Configs/dataSetting.json", optional: false, reloadOnChange: false)
                .AddJsonFile("/../TaskManagement.Data/Configs/appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"/../TaskManagement.Data/Configs/appsettings.{env}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            return builder.Build();
        }


    }
}
