using JccbIncomeExpense.Data;
using JccbIncomeExpense.Models;
using JccbIncomeExpense.Repositories.Abstract;
using JccbIncomeExpense.Repositories.Inplementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// here is the database connection 
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));
// 

// authentication path 
builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");
//builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
//add services to container
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();




//builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();


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
    //pattern: "{controller=Home}/{action=Index}/{id?}");
   pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");

// Seed starts from here 
AppDbInitializer.Seed(app);
app.Run();
