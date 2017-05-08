namespace DataAccessLayer.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.GarageDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataAccessLayer.GarageDataContext context)
        {
            var vehicle1 = new VehicleType { Name = "Car" };
            var vehicle2 = new VehicleType { Name = "Motorcycle" };
            var vehicle3 = new VehicleType { Name = "Bus" };
            var vehicle4 = new VehicleType { Name = "Boat" };
            var vehicle5 = new VehicleType { Name = "Airplane" };
            var vehicle6 = new VehicleType { Name = "Rocket" };

            context.VehicleTypes.AddOrUpdate(
                p => p.Name,
                vehicle1,
                vehicle2,
                vehicle3,
                vehicle4,
                vehicle5,
                vehicle6

                );
            var member1 = new Member { FirstName = "Patrik", LastName = "Luukkonen" };
            var member2 = new Member { FirstName = "Liselott", LastName = "Brunnberg" };
            var member3 = new Member { FirstName = "Gustav", LastName = "Arneving" };
            var member4 = new Member { FirstName = "Mikael", LastName = "Herz" };
            context.Members.AddOrUpdate(
                p => p.FirstName,
                member1,
                member2,
                member3,
                member4
                );

            context.ParkedVehicles.AddOrUpdate(
                p => p.RegNum,
                new ParkedVehicle { RegNum = "TYB735", Member = member1, VehicleType = vehicle1, Color = "Pink" },
                new ParkedVehicle { RegNum = "AAA001", Member = member2, VehicleType = vehicle2, Color = "Blue" },
                new ParkedVehicle { RegNum = "SLA071", Member = member3, VehicleType = vehicle3, Color = "Orange" },
                new ParkedVehicle { RegNum = "ANY719", Member = member4, VehicleType = vehicle4, Color = "Black" }
                );

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
        }
    }
}
