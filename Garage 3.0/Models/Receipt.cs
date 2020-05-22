using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    
    public class Receipt
    {

        /*
         * 
         * var r = parkedVehicle.RegNr;
            var v = parkedVehicle.VehicleType;
            var n = parkedVehicle.NrOfWheels;
            var c = parkedVehicle.Color;
            var b = parkedVehicle.Brand;
            var m = parkedVehicle.Model;            //whatever
            var t = parkedVehicle.TimeOfArrival;
            var tg = parkedVehicle.TimeInGarage;
         */
        public string FullName { get; set; }
        public string ParkedTime { get; set; }
        public string RegNr { get; set; }
        public double Cost { get; set; }

    }
}
