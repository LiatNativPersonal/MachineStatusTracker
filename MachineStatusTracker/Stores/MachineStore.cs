using MachineStatusTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Stores
{
    public class MachineStore
    {
        public event Action<Machine> MachineAdded;
        public event Action<Machine> MachineUpdated;
        public async Task Add(Machine machine)
        {
            MachineAdded?.Invoke(machine);
        }

        public async Task Update(Machine machine)
        {
            MachineUpdated?.Invoke(machine);
        }
    }
}
