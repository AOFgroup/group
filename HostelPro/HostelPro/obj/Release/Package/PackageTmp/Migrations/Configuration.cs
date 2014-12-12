namespace HostelPro.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HostelPro.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<HostelPro.Models.MasterData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HostelPro.Models.MasterData context)
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
            //Guid roleId = Guid.NewGuid();
            //Guid userId = Guid.NewGuid();
            //Guid cityId = Guid.NewGuid();
            //Guid hostelId = Guid.NewGuid();
            //Guid roomId = Guid.NewGuid();
            //Guid hostelNameId = Guid.NewGuid();
            //Guid NameToCityId = Guid.NewGuid();
            //Guid bookingId = Guid.NewGuid();
            //Customer pass = new Customer();
            //string salt = pass.GenerateSalt();
            //string hash = pass.HashPassword("HostelPro");

            //context.HostelRoles.AddOrUpdate(
            //    new HostelRole { Name = "Admin" }
            //    );
            //context.Customers.AddOrUpdate(
            //    new Customer { Name = "Oleksandr Klymchuk", Email = "olkly85@gmail.com", Phone = 24961850, HostelRoleId = 1, Hash = hash, Salt = salt }
            //    );
            //context.Cities.AddOrUpdate(new City { CITY1 = "Aarhus", ZIP = 8000 });
            //context.Hostels.AddOrUpdate(new Hostel { Name = "Radison", Address = "Havnegade 20", Phone = 86192055, ZIP = 8000, Email = "sleep-in@citysleep-in.dk", Information = "På Aarhus Hostel får du overnatninger på en tidligere højskole. Her får du i en god atmosfære BILLIG overnatning tæt på Aarhus" });
            //context.Rooms.AddOrUpdate(new Room { BedNumber = 4 });
            ////context.SaveChanges();




        }
    }
}
