using EcoCheck.Infrastructure.Data;
using EcoCheck.Infrastructure.Data.Seeders;
using EcoCheck.Middlewares;
using EcoCheck.Domain.Entities;
using EcoCheck.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EcoCheck.Application.Interfaces;
using EcoCheck.Domain.Interfaces;
using EcoCheck.Infrastructure.Repositories;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


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

// 2. Registrar CORS
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
// Leer config
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddControllers();

// Por esta línea corregida:
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductoService,ProductoService>();
builder.Services.AddScoped<IMarcaService,MarcaService>();
builder.Services.AddScoped<IMaterialService,MaterialService>();
builder.Services.AddScoped<IPuntuacionService,PuntuacionService>();
builder.Services.AddScoped<ICertificacionService,CertificacionService>();
builder.Services.AddScoped<IEmpresaCertificacionService,EmpresaCertificacionService>();
builder.Services.AddScoped<IAuthService,AuthService>();
builder.Services.AddSingleton<IJwtService, JwtService>();

//Repositorios
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthRepository, AuthRepository>();


//Inyección de dependencias Data Seeders
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
app.UseAuthentication();
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
