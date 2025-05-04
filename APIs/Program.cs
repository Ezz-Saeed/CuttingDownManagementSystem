
using APIs.Data;
using APIs.Extensions;
using APIs.Interfaces;
using APIs.MiddleWares;
using APIs.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.RateLimiting;

namespace APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.WriteIndented = false;
            });
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

            app.UseCors("clientPolicy");
            app.UseMiddleware<RateLimitingMiddleware>();

            app.UseHttpsRedirection();

            app.UseResponseCompression();

            app.UseAuthorization();


            app.MapControllers().RequireRateLimiting("bandwidthPerIp");

            app.Run();
        }
    }
}
