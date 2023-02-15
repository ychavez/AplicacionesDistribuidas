using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Api.Gateway
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Host.ConfigureAppConfiguration((ctx, conf) =>
            {
                conf.AddJsonFile(Path.Combine("Configuration", $"ocelot.{ctx.HostingEnvironment.EnvironmentName}.json"));
            });
            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddOcelot();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.MapControllers();

            await app.UseOcelot();

            app.Run();
        }
    }
}