using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Obs_Proje.Data;
//using Obs_Proje.Identity;

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

            
            builder.Services.AddDbContext<OBSContext>(
                 options => options.UseSqlServer(constr)
                );

            builder.Services.AddIdentity<WebUser, WebRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0; /// TODO: Nedir?
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<OBSContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.LogoutPath = new PathString("/Account/Logout");
                options.AccessDeniedPath = new PathString("/Home/AccessDenied");

                options.Cookie = new()
                {
                    Name = "OBSCookie",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always,
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan= TimeSpan.FromDays(30);   

                // http security, cookie base security
            });

            


            
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

            app.UseAuthentication(); // otantikeyþýn
            app.UseAuthorization();  // otorizeyþýn
           

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}