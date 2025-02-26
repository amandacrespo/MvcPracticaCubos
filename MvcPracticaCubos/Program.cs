using Microsoft.EntityFrameworkCore;
using MvcnetCoreUtilidades.Helpers;
using MvcPracticaCubos.Data;
using MvcPracticaCubos.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession();

string connectionString = builder.Configuration.GetConnectionString("SqlClaseMySql");
builder.Services.AddDbContext<PracticaContext>(options => options.UseMySQL(connectionString));

builder.Services.AddTransient<RepositoryCubos>();
builder.Services.AddSingleton<HelperPathProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseRouting();
app.UseStaticFiles();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cubos}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
