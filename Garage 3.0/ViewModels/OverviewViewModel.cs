using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.ViewModels
{
    public class OverviewViewModel
    {
        [Display(Name = "Member")]
        public string Email { get; set; }

        [Display(Name = "Type of vehicle")]
        public string TypeName { get; set; }

        [Display(Name = "Reg.nr")]
        public string RegNr { get; set; }

        [Display(Name = "Time parked")]
        public string TimeInGarage { get; set; }
    }
}
