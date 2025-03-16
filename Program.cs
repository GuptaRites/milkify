//using milkify.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using milkify.Areas.Identity.Data;


namespace milkify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("milkifyContextConnection")
                ?? throw new InvalidOperationException("Connection string 'milkifyContextConnection' not found.");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //  Corrected DbContext registration
            //builder.Services.AddDbContext<MilkifyContext>(options =>
            //    options.UseSqlServer(connectionString));

            builder.Services.AddDbContext<MilkifyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("milkifyContextConnection")));

            //  Identity Configuration
            builder.Services.AddDefaultIdentity<MilkifyUser>(options =>
                options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<MilkifyContext>();

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            IApplicationBuilder Session = app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();  //  Ensure authentication is used before authorization
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();
            app.Run();
        }
    }
}
