
using APIs.Data;
using APIs.Interfaces;
using APIs.MiddleWares;
using APIs.Services;
using Microsoft.EntityFrameworkCore;

namespace APIs
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

            var localConnection = builder.Configuration.GetConnectionString("LocalConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(localConnection);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            builder.Services.AddScoped<IIncidentGenerator, IncidentGenerator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<RateLimitingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
