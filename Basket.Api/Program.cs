
using Basket.Api.DataContext;
using Basket.Api.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Basket.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          
            builder.Services.AddDbContext<BasketContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BasketConnection")));

            builder.Services.AddScoped<IBasketRepository, BasketRepository>();

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
                });
            });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();  
                    });
            });

            //  builder.Services.AddMassTransitHostedService();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}