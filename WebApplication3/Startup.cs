using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data.Interfaces;
using WebApplication3.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data.Repository;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace WebApplication3
{
    public class Startup
    {
        private IConfigurationRoot _confSting;
        public Startup(IHostEnvironment hostEnv) 
        {
            _confSting = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confSting.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllMovies, MovieRepository>(); 
            services.AddTransient<IAllActors, ActorsRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages(); // просто отобразит код странички 200 - хорош, 400 - плохо
            app.UseStaticFiles(); // для картинок, css файлов
            app.UseRouting(); // for endpoint
            /* IApplicationBuilder applicationBuilder = app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // вместо app.UseMvcWithDefaultRoute();
            }); */
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", "{controller=Movies}/{action=List}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
