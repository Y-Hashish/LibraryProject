using LibraryProject.Models;
using LibraryProject.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITestRepo, TestRepo>();
            builder.Services.AddScoped<IHistoryRepo, HistoryRepo>();
            builder.Services.AddScoped<IBookRepo, BookRepo>();
            builder.Services.AddScoped<IBorrowRepo, BorrowRepo>();


            builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration
                .GetConnectionString("db")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 4;

            }).
                AddEntityFrameworkStores<ApplicationDBContext>();

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
