namespace MVC.Migrations
{
    using MVC.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC.Contexto.ModeloContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVC.Contexto.ModeloContexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Marcas.AddOrUpdate(
                  p => p.Nombre,
                  new Marca { Nombre = "Sony" },
                  new Marca { Nombre = "Samsung" },
                  new Marca { Nombre = "LG" },
                  new Marca { Nombre = "Dell" },
                  new Marca { Nombre = "Toshiba" },
                  new Marca { Nombre = "LG" },
                  new Marca { Nombre = "Huawei" }
                );

            context.Estados.AddOrUpdate(
                  p => p.Descripcion,
                  new Estado { Descripcion = "Devolución" },
                  new Estado { Descripcion = "Sin revisar" },
                  new Estado { Descripcion = "Propiedad de Sertevisa" },
                  new Estado { Descripcion = "Reparado - No entregado" },
                  new Estado { Descripcion = "Reparado - Entregado" }


                );


        }
    }
}
