
using APIs.Data;
using APIs.Extensions;
using APIs.Interfaces;
using APIs.MiddleWares;
using APIs.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

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

            builder.Services.AddApplicationExtensions(builder.Configuration);

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


            app.MapControllers().RequireRateLimiting("bandwidthPerIp");

            app.Run();
        }
    }
}
