using MachineStatusTracker.EntityFramework.DTO;
using MachineStatusTracker.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.Commands
{
    public class DeleteMachineCommand : IDeleteMachineCommand
    {
        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;

        public DeleteMachineCommand(MachineStatusTrackerDBContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (MachineStatusTrackerDBContext context = _dbContextFactory.Create())
            {
                MachineDto machineDto = new MachineDto()
                {
                    Id = id                   
                };
                context.Machines.Remove(machineDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
