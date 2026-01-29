using CompanyWeb.Models.CompanyDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var companyConnStr = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


// Add services to the container.
builder.Services.AddRazorPages();

// CompanyContext is registered here for Dependency Injection
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlite(companyConnStr));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
