using Microsoft.Extensions.Logging;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
             var host = CreateHostBuilder(args).Build();
             using (var scope = host.Services.CreateScope()){
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try{
                    var context = services.GetRequiredService<StoreContext>();
                    await  context.Database.MigrateAsync();
                     await StoreContextTemp.TempAsync(context,loggerFactory);
                }
                catch(Exception e){

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e,"AN ERROR During Migration ");
                }
             }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
