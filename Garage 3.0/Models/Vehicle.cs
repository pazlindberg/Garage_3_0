using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        public int? ParkingSpaceId { get; set; }
        public int VehicleTypeId { get; set; }
        public int MemberId { get; set; }

        [Range(0, 16)]
        [Display(Name = "Number of wheels")]
        public int NrOfWheels { get; set; }

        [StringLength(32)]
        public string Color { get; set; }

        [StringLength(32)]
        public string Brand { get; set; }

        [StringLength(64)]
        public string Model { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Time of arrival")]
        public DateTime TimeOfArrival { get; set; }

        public string TimeInGarage
        {
            get
            {
                var timeInGarage = DateTime.Now.Subtract(TimeOfArrival);
                return String.Format($"{timeInGarage.Days}d  {timeInGarage.Hours:00}h { timeInGarage.Minutes:00}m");
            }
        }
    }
}