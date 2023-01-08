using Jardines2022.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jardines2022.Datos
{
    public class Jardines2022DbContext:DbContext
    {
        public Jardines2022DbContext():base("MiConexion")
        {
            Database.CommandTimeout = 45;
            Configuration.UseDatabaseNullSemantics = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<Jardines2022DbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Pais> Paises { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }

    }
}
