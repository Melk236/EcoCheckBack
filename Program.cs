using EcoCheck.Data;
using EcoCheck.Data.Seeders;
using EcoCheck.Middlewares;
using EcoCheck.Models;
using EcoCheck.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")
    )));

// 1.2 Identity (después del DbContext)
builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
{
    // Configuración de contraseñas
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<AppDbContext>();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// 1. Registrar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.AddControllers();

// Por esta línea corregida:
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<MarcaService>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<PuntuacionService>();
builder.Services.AddScoped<CertificacionService>();
builder.Services.AddScoped<EmpresaCertificacionService>();
builder.Services.AddTransient<MarcaSeeder>();
builder.Services.AddTransient<CertificacionSeeder>();
builder.Services.AddTransient<EmpresaCertificacionSeeder>();

// Registrar HttpClient
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())//Creamos los datos iniciales de las tablas de la bd con los dataseeders correspondientes
{
    var marcaSeeder = scope.ServiceProvider.GetRequiredService<MarcaSeeder>();
    var certificacionSeeder = scope.ServiceProvider.GetRequiredService<CertificacionSeeder>();
    var empresaCertificacionSeeder = scope.ServiceProvider.GetRequiredService<EmpresaCertificacionSeeder>();

    await marcaSeeder.SeedMarcas();
    await certificacionSeeder.SeedCertificaciones();
    await empresaCertificacionSeeder.seedEmpresaCertificacion();
}

app.Run();
