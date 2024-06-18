using MachineStatusTracker.EntityFramework.DTO;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.Queries
{
    public class GetAllMachineQuery : IGetAllMachines
    {

        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;

        public GetAllMachineQuery(MachineStatusTrackerDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Machine>> Execute()
        {
            using (MachineStatusTrackerDBContext context = _dbContextFactory.Create())
            {
                IEnumerable<MachineDto> machineDtos = await context.Machines.ToListAsync();
                return machineDtos.Select(d => new Machine(d.Id, d.Name, d.Description, new Status(d.Status.Id, d.Status.Name)));
            }

        }
    }
}
