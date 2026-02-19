using EcoCheck.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoCheck.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Productos> Producto { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Puntuacion> Puntuacion { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Certificacion> Certificaciones { get; set; }
        public DbSet<EmpresaCertificacion> EmpresaCertificacion {  get; set; }
        public DbSet<RefreshToken> RefreshToken { get;set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole<int>>().ToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ToTable("UsuarioRoles");
        }
    }
}