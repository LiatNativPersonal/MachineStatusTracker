using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Commands
{
    public class LoadMachineStatusesCommand : AsyncCommandBase
    {
        private readonly MachineStore _machineStore;

        public LoadMachineStatusesCommand(MachineStore machineStore)
        {
            _machineStore = machineStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _machineStore.LoadStauses();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
