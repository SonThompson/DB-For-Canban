using FunPart.Helpers;
using FunPart.Repository.IRepos;
using FunPart.Repository.Repos;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

namespace FunPart
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // create a logger factory
            var loggerFactory = LoggerFactory.Create(
                builder => builder.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Debug));

            // create a logger
            var logger = loggerFactory.CreateLogger<Startup>();

            // logging
            logger.LogTrace("Trace message");
            logger.LogDebug("Debug message");
            logger.LogInformation("Info message");
            logger.LogWarning("Warning message");
            logger.LogError("Error message");
            logger.LogCritical("Critical message");

            services.AddSingleton(typeof(ILogger), logger);

            services.AddAutoMapper(typeof(AutoMapperProfile).GetTypeInfo().Assembly);

            services.AddScoped<ITaskCategoryRepo, TaskCategoryRepo>();
            services.AddScoped<ITaskRepo, TaskRepo>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddHttpContextAccessor();

            services.AddDbContext<Context>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("FunPart"));
            });
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Social CRM API v1");
                x.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
