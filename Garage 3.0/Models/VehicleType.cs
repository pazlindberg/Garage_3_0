using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    public class VehicleType
    {
        public int Id { get; set; }

        [Display(Name = "Vehicle Type")]
        public string TypeName { get; set; }
        public double Size { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
