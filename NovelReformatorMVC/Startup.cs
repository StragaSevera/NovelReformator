using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NovelReformatorMVC.Services;
using NovelReformatorMVC.Services.Log;
using NovelReformatorMVC.Services.Reformator;

namespace NovelReformatorMVC
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

//            services.AddTransient<IReformatorService, MockReformator>();
            services.AddTransient<IReformatorService>(_ => new ApiReformator(_configuration["WebApi:BaseUrl"]));
            services.AddTransient<ILogService>(_ => new ApiLog(_configuration["WebApi:LogUrl"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}");
            });
        }
    }
}