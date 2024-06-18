using MachineStatusTracker.EntityFramework.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework
{
    public class MachineStatusTrackerDBContext: DbContext
    {
        public MachineStatusTrackerDBContext(DbContextOptions options) : base(options) { }
        
        public DbSet<MachineDto> Machines { get; set; }
        public DbSet<StatusDto> Statuses { get; set; }
    }

       

    
}
