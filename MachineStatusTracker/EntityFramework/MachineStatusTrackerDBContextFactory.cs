using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework
{
    public class MachineStatusTrackerDBContextFactory
    {
        private readonly DbContextOptions _options;

        public MachineStatusTrackerDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public MachineStatusTrackerDBContext Create()
        {
            return new MachineStatusTrackerDBContext(_options);
        }
    }
}
