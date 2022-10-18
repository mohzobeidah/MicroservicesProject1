using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlateformService.Models;

namespace PlateformService.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Plateform> Plateforms { get; set; }
    }
}