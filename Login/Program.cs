using Login;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>      //configures and creates IHostBuilder
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();       //use Startup class to configure the app
                });
    }
}