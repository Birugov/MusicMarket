using BozheHvatitDushit_Sharp.Models;
using BozheHvatitDushit_Sharp.Repository;
using BozheHvatitDushitSharp.Middleware;
using BozheHvatitDushitSharp.Models;
using BozheHvatitDushitSharp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Google;


namespace BozheHvatitDushit_Sharp
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
            string connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PurchaseContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));        
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<PurchaseContext>();
            services.AddMvc(options=> {
                options.CacheProfiles.Add("Monthly", new CacheProfile { Duration = 60 * 60 * 24 * 7 * 4 });
            });
            services.AddAuthentication().AddGoogle(options => {
                options.ClientId = "195184219128-sfkja76sq0tijbmk7bivuvp4bcb0snbo.apps.googleusercontent.com";
                options.ClientSecret = "B_-eaatDx1XowA-OaVEmrOw_";


                }
            );
            services.AddControllersWithViews();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => Cart.GetCart(sp));
            services.AddScoped<DBObjects>();
            services.AddScoped<Category>();
            services.AddTransient<LogService>();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseMiddleware<RRLMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "{controller=Category}/{action=List}/{category?}"
                    );
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                PurchaseContext content = scope.ServiceProvider.GetRequiredService<PurchaseContext>();
                DBObjects.Initial(content);
            }
        }
    }
}
