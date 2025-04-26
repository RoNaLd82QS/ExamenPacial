using EquiposPeruanos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar puerto dinámico (usado por Render)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://*:{port}");

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();

// Configurar DbContext con PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection"))
);

var app = builder.Build();

// Configuración del middleware HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Ruta por defecto: controlador Player, acción Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Player}/{action=Index}/{id?}");

app.Run();
