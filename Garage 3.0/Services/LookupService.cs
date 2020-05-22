using Garage_3._0.Data;
using Garage_3._0.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_3._0.Services
{
    public class LookupService : ILookupService
    {
        private readonly Garage_3_0Context _context;

        public LookupService(Garage_3_0Context context)
        {
            _context = context;
        }

        public List<SelectListItem> VehicleTypes() =>
             _context.VehicleType
                .Select(v =>
                          new SelectListItem()
                          {
                              Value = v.Id.ToString(),
                              Text = v.TypeName
                          })
                .ToList();
    }
}