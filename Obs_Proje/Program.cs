using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Obs_Proje.Data;
using Obs_Proje.Identity;

namespace Obs_Proje
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

           
            var constr = builder.Configuration.GetConnectionString("ObsSqlServer");

            //builder.Services.AddDbContext<WebIdentityContext>(
            //    options => options.UseSqlServer(constr)
            //   );

            builder.Services.AddDbContext<OBSContext>(
                 options => options.UseSqlServer(constr)
                );

            builder.Services.AddIdentity<WebUser, WebRole>()
                            .AddEntityFrameworkStores<WebIdentityContext>();


            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();  // otorizeyþýn
            app.UseAuthentication(); // otantikeyþýn

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}