
using APIs.Data;
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

            var localConnection = builder.Configuration.GetConnectionString("LocalConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(localConnection);
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
            builder.Services.AddScoped<IIncidentGenerator, IncidentGenerator>();
            builder.Services.AddRateLimiter(options =>
            {
                options.AddPolicy("bandwidthPerIp", context =>
                {
                    var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                    return RateLimitPartition.GetTokenBucketLimiter(ipAddress, key => new TokenBucketRateLimiterOptions
                    {
                        TokenLimit = 100 * 1024, // 100 KB
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        QueueLimit = 0,
                        ReplenishmentPeriod = TimeSpan.FromSeconds(1),
                        TokensPerPeriod = 100 * 1024, // refill 100 KB every second
                        AutoReplenishment = true
                    });
                });
            });

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
