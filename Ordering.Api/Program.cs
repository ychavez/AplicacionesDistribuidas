using Microsoft.EntityFrameworkCore;
using Ordering.Application;
using Ordering.Application.Contracts;
using Ordering.Infraestructure.Persistence;
using Ordering.Infraestructure.Repositories;

namespace Ordering.Api
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

            builder.Services.AddDbContext<OrderContext>(options
                => options.UseSqlServer(builder.Configuration.GetConnectionString("OrderingConnectionString")));

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            builder.Services.AddApplicationServices();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}