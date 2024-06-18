﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models.Commands
{
    public interface IUpdateMachineCommand
    {
        Task Execute(Machine machine);
    }
}
