using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Repositories;
using DBRepository.Interfaces;
using DBRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;

namespace TrainingService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllersWithViews();
            services.AddControllers();
            //Система на место объектов интерфейса IRepositoryContextFactory будет передавать экземпляры класса RepositoryContextFactory.
            services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>(); // 1
            //(ideas) Нужно чтоб получить реализацию IRepositoryContextFactory через provider(абстрагирование)                                                                            // 
            services.AddScoped<ILessonRepository>(provider => new LessonRepository(
                Configuration.GetConnectionString("DefaultConnection"),
                provider.GetService<IRepositoryContextFactory>())); // 2
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            //app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });
            });           
        }
    }
}
