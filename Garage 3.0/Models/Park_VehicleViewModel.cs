using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Garage_3._0.Models
{
    public class Park_VehicleViewModel
    {
        [Required(ErrorMessage = "Enter Email")] 
        public string Email { get; set; }
        public string RegNr { get; set; }
        [Required(ErrorMessage = "Enter reg.nr")] 
        public List<SelectListItem> RegNrList { get; }
    }
}
