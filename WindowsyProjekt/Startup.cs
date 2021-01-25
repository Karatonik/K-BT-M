using WindowsyProjekt.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WindowsyProjekt.Utils;
using WindowsyProjekt.Utils.ExtensionMethods;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace WindowsyProjekt
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<WinProjDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            RegisterUtilities(ref services);
            RegisterServices(ref services);
            RegisterRepositories(ref services);

#if DEBUG
            services.AddCors(options =>
            {
                options.AddPolicy(AppSettings.CorsConfigurationName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });
#endif
        }

        private static void RegisterUtilities(ref IServiceCollection services)
        {
            //
        }

        private static void RegisterServices(ref IServiceCollection services)
        {
            //services.AddTransient<IUsersDataService, UsersDataService>();
        }

        private static void RegisterRepositories(ref IServiceCollection services)
        {
            services.AddTransient<IProjectRepository, ProjectRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(AppSettings.CorsConfigurationName);
            }
            else
            {
                app.UseHsts();
            }

            app.UpdateDatabase();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
