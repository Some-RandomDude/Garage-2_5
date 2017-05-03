using System.Collections.Generic;

namespace Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        

        public List<ParkedVehicle> ParkedVehicles { get; set; }
    }
}