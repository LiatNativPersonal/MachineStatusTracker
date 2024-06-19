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
                List<Machine> machines = new List<Machine>();
                IEnumerable<MachineDto> machineDtos = await context.Machines.ToListAsync();
                IEnumerable<StatusDto> statusDtos = await context.Statuses.ToListAsync();
                foreach (MachineDto  machineDto in machineDtos)
                {
                    StatusDto statusDto = statusDtos.First(y => y.Id == machineDto.Status.Id);
                    Machine machine = new Machine(machineDto.Id, machineDto.Name, machineDto.Description,
                        new Status(statusDto.Id, statusDto.Name));
                    machines.Add(machine);
                }
                return machines;
            }

        }
    }
}
