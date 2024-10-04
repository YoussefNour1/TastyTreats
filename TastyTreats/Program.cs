using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TastyTreats.Contexts;
using TastyTreats.Repositories;
using TastyTreats.Repositories.OrderRepos;
using TastyTreats.Repositories.UserRepos;
using TastyTreats.Repositories;
using TastyTreats.Models;
using Microsoft.Extensions.Options;
using System.Configuration;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Identity.UI.Services;




internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<TastyTreatsContext>(options =>
            options.UseSqlServer(connectionString));

        //builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<TastyTreatsContext>();
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddMvc();
        builder.Services.AddRazorPages();

        //Services for Authentication with User Google Account
        builder.Services.AddAuthentication()
        .AddGoogle(options =>
        {
            IConfigurationSection googleAuthSection = builder.Configuration.GetSection("Authentication:Google");
            options.ClientId = googleAuthSection["ClientId"];
            options.ClientSecret = googleAuthSection["ClientSecret"];
        });

        //register
        builder.Services.AddTransient<IItemRepository, ItemRepository>();
        builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
        builder.Services.AddTransient<ICartRepository, CartRepository>();
        builder.Services.AddTransient<IOrderRepository, OrderRepository>();
        builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>().AddEntityFrameworkStores<TastyTreatsContext>().AddDefaultTokenProviders();

        //Register the Email Service
        builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
        builder.Services.AddTransient<IEmailSenderRepository, EmailSenderRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        
        //Should use Authentication before Authorization

        app.UseAuthentication();        //Who are you and you have cookies or not?
        app.UseAuthorization();         //What is your Role?

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
        app.MapRazorPages();

        app.Run();
    }
}