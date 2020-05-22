using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        [StringLength(30, ErrorMessage = "Email must not be more than 30 char")]
        [Remote("IsAlreadySigned", "Members", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        public string Email { get; set; }
    }
}
