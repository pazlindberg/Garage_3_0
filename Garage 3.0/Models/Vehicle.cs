using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int NrOfWheels { get; set; }

        public int MemberId { get; set; }
        public int VehicleTypeId { get; set; }
        
        public Member Member { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
