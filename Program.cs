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

                        var jobKey = new JobKey("FetchPTDataJob");

                        // Register the job with the DI container
                        q.AddJob<FetchPTDataJob>(opts => opts.WithIdentity(jobKey));

                        // Create a trigger for the job
                        q.AddTrigger(opts => opts
                            .ForJob(jobKey)
                            .WithIdentity("FetchPTDataJob")
                            .WithCronSchedule("0/30 * * * * ?"));
                    });

                    services.AddQuartzHostedService(
                        q => q.WaitForJobsToComplete = true);
                });
    }
}
