using EventManagementSystem.BLL;
using EventManagementSystem.DAL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ERSContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ERSContext>()
            .AddDefaultUI();


            builder.Services.AddScoped(typeof(GenericDAL<,>));
            builder.Services.AddScoped<AttendeeDAL>();
            builder.Services.AddScoped<EventDAL>();
            builder.Services.AddScoped<RegistrationDAL>();
            builder.Services.AddScoped<AttendeeService>();
            builder.Services.AddScoped<EventService>();
            builder.Services.AddScoped<RegistrationService>();

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

            app.UseAuthentication();
            app.UseAuthorization();

            // convention-based routing
            app.MapControllerRoute(
                name: "area",
                pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Registration}/{action=Index}/{id?}");
            // attribute-based routing
            app.MapControllers();

            app.MapRazorPages();

            app.Run();
        }
    }
}
