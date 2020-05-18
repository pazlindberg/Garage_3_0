using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double size { get; set; } //hur stor del av en parkeringsplats tar denna fordonstyp?

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
