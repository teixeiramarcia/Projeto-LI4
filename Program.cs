using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Quartz;
using eudaci.API;

namespace eudaci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddQuartz(q =>
                    {
                        q.UseMicrosoftDependencyInjectionScopedJobFactory();

                        var jobKey = new JobKey("FetchDataJob");
                        var notKey = new JobKey("NotificationsJob");

                        // Register the job with the DI container
                        q.AddJob<FetchDataJob>(opts => opts.WithIdentity(jobKey));
                        q.AddJob<NotificationsJob>(opts => opts.WithIdentity(notKey));

                        // Create a trigger for the job
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey)
                            .WithIdentity("FetchDataJob")
                            .WithCronSchedule("0 0 2 * * ?")); // every day at 02:00:00
                            //.WithCronSchedule("0/30 * * * * ?")); // every minute at second 0 and 30
                        
                        q.AddTrigger(opts => opts
                            .ForJob(notKey)
                            .WithIdentity("NotificationsJob")
                            .WithCronSchedule("0/30 * * * * ?"));
                    });

                    services.AddQuartzHostedService(
                        q => q.WaitForJobsToComplete = true);
                });
    }
}
