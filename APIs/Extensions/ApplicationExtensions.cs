using APIs.Data;
using APIs.Helpers;
using APIs.Interfaces;
using APIs.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using System.IO.Compression;
using System.Threading.RateLimiting;

namespace APIs.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            var localConnection = configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(localConnection).UseLazyLoadingProxies();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<IIncidentGenerator, IncidentGenerator>();


            services.AddRateLimiter(options =>
            {
                options.AddPolicy("bandwidthPerIp", context =>
                {
                    var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

                    return RateLimitPartition.GetTokenBucketLimiter(ipAddress, key => new TokenBucketRateLimiterOptions
                    {
                        TokenLimit = 100 * 1024,
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        QueueLimit = 0,
                        ReplenishmentPeriod = TimeSpan.FromSeconds(1),
                        TokensPerPeriod = 100 * 1024,
                        AutoReplenishment = true
                    });
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("clientPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
                });
            });


            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "application/json",
                    "text/plain",
                    "text/json",
                    "text/html"
                    });
              });

            
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
