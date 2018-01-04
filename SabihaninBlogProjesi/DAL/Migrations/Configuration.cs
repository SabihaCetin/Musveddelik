namespace DAL.Migrations
{
    using DomainEntity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.MyContext context)
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
            if (context.Roles.Count() == 0)
            {
                context.Roles.Add(new IdentityRole() { Name = "Admin" });
                 context.Roles.Add(new IdentityRole() { Name = "Kullanici" });
            }
          
            if (context.Users.Count() == 0)
            {
             
                UserStore<Kullanici> str = new UserStore<Kullanici>(new MyContext());
                UserManager<Kullanici> mng = new UserManager<Kullanici>(str);

                var admin = new Kullanici() { Email = "admin@yaz5.com", UserName = "admin@yaz5.com", AdSoyad = "Yonetici", Meslek = "Yonetici" };
                mng.Create(admin, "Aa123456!"); //2. parametre þifresi
                context.SaveChanges();
                mng.AddToRole(admin.Id, "Admin");
                context.SaveChanges();

            }

        } 
    }
}
