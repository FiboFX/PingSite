using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PingSite.Core.EF;
using PingSite.Core.Repositories;
using PingSite.Core.Services;

namespace PingSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<PingSiteContext>(
                options => options.UseSqlServer(Configuration["Sql:ConnectionString"]));
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration["Sql:ConnectionString"]));

            // Repositories
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IHostRepository, HostRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IHostHistoryRepository, HostHistoryRepository>();

            // Services
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IHostService, HostService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISettingService, SettingService>();
            services.AddScoped<IHostHistoryService, HostHistoryService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseHangfireServer();
            app.UseHangfireDashboard();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
