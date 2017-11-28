using Microsoft.AspNet.Identity.EntityFramework;
using MVC.Entidades;
using MVC.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace MVC.Contexto
{
    public class ModeloContexto : IdentityDbContext<ApplicationUser>
    {
        public ModeloContexto() : base("DefaultConexion", 
            throwIfV1Schema: false)
        {
            Database.SetInitializer<ModeloContexto>(null);
        }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            base.OnModelCreating(modelBuilder);

            #region EntityConfiguration
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));

            #endregion

        }

        public override int SaveChanges()
        {

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.GetType().GetProperty("DateCreation") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateCreation").CurrentValue = System.DateTime.Now.Date;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where
                (entry => entry.GetType().GetProperty("DateModification") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DateModification").CurrentValue = System.DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

        public static ModeloContexto Create()
        {
            return new ModeloContexto();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Desglose> Desgloses { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<OrdenEntrada> OrdenEntradas { get; set; }
        public DbSet<Adelanto> Adelantos { get; set; }

        public System.Data.Entity.DbSet<MVC.Entidades.Equipo> Equipoes { get; set; }
    }
}