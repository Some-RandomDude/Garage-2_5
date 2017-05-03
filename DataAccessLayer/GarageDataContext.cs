using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class GarageDataContext : DbContext
    {
        public GarageDataContext() : base("DefaultConnection")
        {

        }
        public DbSet<ParkedVehicle> ParkedVehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}
