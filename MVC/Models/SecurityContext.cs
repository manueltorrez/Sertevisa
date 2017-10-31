using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SecurityContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<SecurityContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static SecurityContext Create()
        {
            return new SecurityContext();
        }
    }
}