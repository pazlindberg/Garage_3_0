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
        //[Remote("CheckExistMember", "Member", HttpMethod = "POST", ErrorMessage = "Email already exists")]
        // raden ovan fuckar upp create (inget händer när man trycker create efter att ha
        // fyllt i formuläret - troligen måste checkexistmember implementeras men hur är kanske frågan(?)
        public string Email { get; set; }
    }
}


/*** MemberController???      new Member { Id = 1, RegNr = "US_LM126", vehicleType = VehicleType.Airplane, NrOfWheels = 4 },

[AllowAnonymous]
[HttpPost]
public ActionResult CheckExistMember(string email)
{
    try
    {
        return Json(!ExistEmail(email));
    }
    catch (Exception ex)
    {
        return Json(false);
    }

    // return Json(!db.Users.Any(x => x.Email == email), JsonRequestBehavior.AllowGet);
}


private bool ExistEmail(string email)
    => MemberManager.FindByEmail(email) != null;
    
 */
