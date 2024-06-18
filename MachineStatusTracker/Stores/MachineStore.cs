using MachineStatusTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Stores
{
    public class MachineStore
    {
        public event Action<Machine> MachineAdded;

        public async Task Add(Machine machine)
        {
            MachineAdded?.Invoke(machine);
        }
    }
}
