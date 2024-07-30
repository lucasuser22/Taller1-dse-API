using Microsoft.EntityFrameworkCore;
using MVCProducto.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add DbContext
builder.Services.AddDbContext<ProductosDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PeliculasCN")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Hola",
    pattern: "{controller=HelloWorld}/{action=Welcome}/{nombre}/{apellido}/{numVeces}");

app.Run();
