using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ModelBindingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        })
        //    .UseSerilog((hostingContext, loggerConfiguration) =>
        //    {
        //        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
        //    });

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
        .UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration
                .WriteTo.Map(
                    (LogEvent le) => le.Timestamp.Date,
                    (date, wt) => wt.File(
                        $"Logs/{date:yyyy-MM-dd}/log-.txt",
                        rollingInterval: RollingInterval.Hour,
                        outputTemplate: "{Timestamp:o} [{Level:u3}] ({SourceContext}) - ({ActionName}) {Message:j}{NewLine}{Exception}",
                        retainedFileCountLimit: 2
                    )
                )
                .ReadFrom.Configuration(hostingContext.Configuration);
        });
    }
}
