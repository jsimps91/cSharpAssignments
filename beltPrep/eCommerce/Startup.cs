using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stripe;
using eCommerce.Models;

namespace eCommerce
{

    public class Startup
    {
        
        public IConfiguration Configuration { get; private set; }
        


        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddSession();
            services.AddDbContext<Context>(options => options.UseNpgsql(Configuration["DBInfo:ConnectionString"]));
            StripeConfiguration.SetApiKey("pk_test_8HBdAkyUIfjAMHl92NWAfkDo");
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
            
        }
    }
}
