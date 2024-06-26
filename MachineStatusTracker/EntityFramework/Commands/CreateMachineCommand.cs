﻿using MachineStatusTracker.EntityFramework.DTO;
using MachineStatusTracker.Models;
using MachineStatusTracker.Models.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.EntityFramework.Commands
{
    public class CreateMachineCommand : ICreateMachineCommand
    {

        private readonly MachineStatusTrackerDBContextFactory _dbContextFactory;

        public CreateMachineCommand(MachineStatusTrackerDBContextFactory dbContextFactory)
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
                    Status = context.Statuses.FirstOrDefault(y=>y.Id==machine.Status.Id)
                };
                context.Machines.Add(machineDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
