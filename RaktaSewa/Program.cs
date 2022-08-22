using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RaktaSewa.Data;
using RaktaSewa.Data.Data;
using RaktaSewa.Repository;
using RaktaSewa.Services;

namespace RaktaSewa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
          

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            DependeciesConfig(builder.Services);
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
            static void DependeciesConfig(IServiceCollection services)
            {
                #region Repositories

                services.AddTransient<ICitizenRepository, CitizenRepository>();
                services.AddTransient<IBloodRepository, BloodRepository>();
                services.AddTransient <IHospitalRepository, HospitalRepository>();


                #endregion Repositories

                #region Services

                services.AddTransient<ICitizenService, CitizenService>();
                services.AddTransient<IBloodService, BloodService>();
                services.AddTransient<IHospitalService, HospitalService>();


                #endregion Services
            }
        }
    }
}