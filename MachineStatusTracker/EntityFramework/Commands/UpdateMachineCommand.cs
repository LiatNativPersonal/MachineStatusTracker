using MachineStatusTracker.EntityFramework.DTO;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.Commands
{
    public class UpdateMachineCommand : IUpdateMachineCommand
    {
        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;

        public UpdateMachineCommand(MachineStatusTrackerDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Execute(Machine machine)
        {
            
            using (MachineStatusTrackerDBContext context = _dbContextFactory.Create())
            {
                MachineDto machineDto = new MachineDto()
                {
                    Id = machine.Id,
                    Name = machine.Name,
                    Description = machine.Description,
                    Status = new StatusDto() { Id = machine.Status.Id, Name = machine.Status.Name }
                };
                context.Machines.Update(machineDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
