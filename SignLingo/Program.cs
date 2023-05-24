using ForceDown;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignLingo.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlite(connectionString);
        options.EnableSensitiveDataLogging();
    }
);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ForceDown.DatabaseAbstract>();
builder.Services.AddTransient<Seeder>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    var dbPort = serviceScope.ServiceProvider.GetService<DatabaseAbstract>();
    var dbSeeder = serviceScope.ServiceProvider.GetService<Seeder>();
    
    await dbPort?.GetDatabasePortAsync();
    await context?.Database.MigrateAsync();
    await dbSeeder.SeedAsync();
}

app.Run();