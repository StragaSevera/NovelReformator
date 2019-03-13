using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NovelReformatorWebAPI.Services;
using Prism.Events;

namespace NovelReformatorWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            services.AddHttpContextAccessor();

            services.AddSingleton<IEventAggregator, EventAggregator>(); // можно ли сделать его Transient?
            services.AddSingleton<LoggerService, DebugLogger>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.ApplicationServices.GetService<LoggerService>();
        }
    }
}