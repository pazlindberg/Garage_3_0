using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_3._0.Models;

namespace Garage_3._0.Data
{
    public class Garage_3_0Context : DbContext
    {
        public Garage_3_0Context (DbContextOptions<Garage_3_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_3._0.Models.Vehicle> Vehicle { get; set; }
    }
}
