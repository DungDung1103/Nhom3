using BTLNhom3.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
 
builder.Services.AddScoped<Service, ServiceImpl>();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{

    
    options.IdleTimeout = TimeSpan.FromSeconds(10);
     options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddDbContext<MvcMovieContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MvcMovieContext") ?? throw new InvalidOperationException("Connection string 'MvcMovieContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

<<<<<<< HEAD
=======
// Configure the HTTP request pipeline.
// void ConfigureServices(IServiceCollection service)
// {
//     service.AddDistributedMemoryCache();
//     service.AddSession(options => {
//         options.Cookie.Name = "BTLNhom3";
//         options.IdleTimeout = new TimeSpan(0,60,0);
//     });
// }
>>>>>>> cff410838e847451aed9f6511bea2e77d09b7596
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

app.UseSession();
<<<<<<< HEAD

app.MapRazorPages();
app.MapDefaultControllerRoute();
=======
// app.UseEndpoints(Endpoints =>
// {
//     Endpoints.MapGet("/", async context =>
//     {
        
//         await context.Response.WriteAsync("Hello World!");
//     });
// });
>>>>>>> cff410838e847451aed9f6511bea2e77d09b7596

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
