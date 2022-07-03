using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using panel.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerContext") ?? throw new InvalidOperationException("Connection string 'ServerContext' not found.")));
builder.Services.AddDbContext<NodeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NodeContext") ?? throw new InvalidOperationException("Connection string 'NodeContext' not found.")));
var connectionString = builder.Configuration.GetConnectionString("panelContextConnection") ?? throw new InvalidOperationException("Connection string 'panelContextConnection' not found.");

builder.Services.AddDbContext<panelContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<panelContext>();;

// Add services to the container.

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

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
