using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovelReformatorWebAPI.Data;
using NovelReformatorWebAPI.Models;
using NovelReformatorWebAPI.Repositories;
using NovelReformatorWebAPI.Services;
using Prism.Events;

namespace NovelReformatorWebAPI
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
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            services.AddDbContext<ReformatorContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpContextAccessor();


            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddSingleton<LoggerService, DbLogger>();
            // Не Transient, ибо требует контекста, а он Scoped
            services.AddScoped<IGenericRepository<LogEntry>, LogEntryRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.ApplicationServices.GetService<LoggerService>();
        }
    }
}