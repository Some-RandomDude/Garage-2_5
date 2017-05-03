using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ParkedVehicle
    {
        public ParkedVehicle()
        {
            TimeOfCheckIn = DateTime.Now;
        }
        public int Id { get; set; }
        public string RegNum { get; set; }
        public DateTime TimeOfCheckIn { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
