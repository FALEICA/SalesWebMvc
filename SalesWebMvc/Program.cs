using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SalesWebMvc.Data;
using SalesWebMvc.Services;
using System.Configuration;
using System.Drawing.Printing;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();




builder.Services.AddDbContext<SalesWebMvcContext>(options =>
   options.UseMySql(
        serverVersion: new MySqlServerVersion(new Version(8, 0, 29)), 
        connectionString: builder.Configuration.GetConnectionString("SalesWebMvcContext") 
        )
   ) ;



// Add services to the container.
builder.Services.AddControllersWithViews();







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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
