using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Api.Gateway
{
    public class Program
    {
        public async static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Host.ConfigureAppConfiguration((ctx, conf) =>
            {
                conf.AddJsonFile(Path.Combine("Configuration", $"ocelot.{ctx.HostingEnvironment.EnvironmentName}.json"));
            });
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddOcelot();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            await app.UseOcelot();

            app.Run();
        }
    }
}