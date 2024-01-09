using Microsoft.EntityFrameworkCore;
using web.Data;
using Microsoft.AspNetCore.Identity;
using web.Models;


var builder = WebApplication.CreateBuilder(args);
    
// Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("oaContext");
    builder.Services.AddDbContext<oaContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddControllersWithViews();

    builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<oaContext>();
        


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    
    var context = scope.ServiceProvider.GetRequiredService<oaContext>();
    DbInitializer.Initialize(context);
}

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
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


