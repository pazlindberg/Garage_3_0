using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.ViewModels
{
    public class IndexOverviewViewModel
    {
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        public string Email { get; set; }
        public string RegNr { get; set; }
        public string TypeName { get; set; }
        public int NrOfWheels { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime? TimeOfArrival { get; set; }
    }
}
