using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models.Entities;

namespace Proyecto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<ClienteFinanza> ClienteFinanza { get; set; }

        public virtual DbSet<Transaccion> Transaccion { get; set; }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {

            optionBuilder.UseSqlServer(@"Server=DESKTOP-PDNHCQI;Database=DbBcp;
            Trusted_Connection=True;MultipleActiveResultSets=true");

        }

    }
}