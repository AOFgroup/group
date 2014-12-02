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
            AutomaticMigrationsEnabled = false;
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
            Guid roleId = Guid.NewGuid();
            Guid userId = Guid.NewGuid();
            Guid cityId = Guid.NewGuid();
            Guid hostelId = Guid.NewGuid();
            Guid roomId = Guid.NewGuid();
            Guid hostelNameId = Guid.NewGuid();
            Guid NameToCityId = Guid.NewGuid();
            Guid bookingId = Guid.NewGuid();
            Customer pass = new Customer();
            string salt = pass.GenerateSalt();
            string hash = pass.HashPassword("HostelPro");

            context.HostelRoles.AddOrUpdate(
                new HostelRole { ID = roleId, Name = "Admin" }
                );
            context.Customers.AddOrUpdate(
                new Customer { ID = userId, Name = "Oleksandr Klymchuk", Email = "olkly85@gmail.com", Phone = 24961850, HostelRoleId = roleId, Hash = hash, Salt = salt }
                );
            context.Cities.AddOrUpdate(new City { ID = cityId, CITY1 = "Aarhus", ZIP = 8000 });
            context.Hostels.AddOrUpdate(new Hostel { ID = hostelId, Address = "Havnegade 20", Phone = 86192055, CityId = cityId, Email = "sleep-in@citysleep-in.dk", Information = "P� Aarhus Hostel f�r du overnatninger p� en tidligere h�jskole. Her f�r du i en god atmosf�re BILLIG overnatning t�t p� Aarhus" });
            context.Rooms.AddOrUpdate(new Room { ID = roomId, BedNumber = 4, HostelId = hostelId, Price = 200, PetAllow = true });
            context.HostelNames.AddOrUpdate(new HostelName { ID = hostelNameId, Name = "City Sleep-IN" });
            context.HostelNameToCities.AddOrUpdate(new HostelNameToCity { ID = NameToCityId, CityId = cityId, HostelNameId = hostelNameId });
            context.SaveChanges();




        }
    }
}
