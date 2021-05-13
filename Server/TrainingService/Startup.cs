using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using TrainingService.DBRepository;
using Microsoft.EntityFrameworkCore;
using TrainingService.Models;
using Microsoft.AspNetCore.Identity;

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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TrainingServiceContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<User, IdentityRole>(options => {
                //options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequiredLength = 5;   // ����������� �����
                options.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                options.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                options.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                options.Password.RequireDigit = false; // ��������� �� �����
                options.User.RequireUniqueEmail = false;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz@.1234567890 ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // ���������� �������
            }).AddEntityFrameworkStores<TrainingServiceContext>();

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "525960053225-gd2g1f2bh1qjoao527mracp1lgf302hj.apps.googleusercontent.com";
                options.ClientSecret = "iRs4hQ646v9dnvDJFEEoFWGj";
            }).AddVkontakte(options =>
            {
                options.ClientId = "7850272";
                options.ClientSecret = "8zKgzfnjan2ivJu8wwgo";
                options.Scope.Add("email");
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllersWithViews();
            services.AddControllers();
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

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
