namespace MVC.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVC.Contexto;
    using MVC.Entidades;
    using MVC.Models;
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

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ModeloContexto()));

            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false
            };


            var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new ModeloContexto()));

            string name = "sertevisamain@gmail.com";
            string password = "123456";
            string firstName = "Rubén";
            string apellidoB = "Valiente";

            string roleName = "Admin";

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new ApplicationRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);

            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name, FirstName = firstName, EmailConfirmed = true, LastName = apellidoB };
                var result = userManager.Create(user, password);

                result = userManager.SetLockoutEnabled(user.Id, false);
            }



            //Identifico si el usuario tiene rol para luego asignarselo
            var rolesForUser = userManager.GetRoles(user.Id);

            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
            context.SaveChanges();

        }
    }
}
