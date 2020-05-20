using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Garage_3._0.Services
{
    public interface ILookupService
    {
        List<SelectListItem> VehicleTypes();

    }

}