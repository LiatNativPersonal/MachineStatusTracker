using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Models.Commands
{
    public interface ICreateMachineCommand
    {
        Task Execute (Machine machine);
    }
}
