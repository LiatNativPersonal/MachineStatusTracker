using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Commands
{
    public class LoadMachinesCommand : AsyncCommandBase
    {

        private readonly MachineStore _machineStore;

        public LoadMachinesCommand(MachineStore machineStore)
        {
            _machineStore = machineStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _machineStore.LoadMachines();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
