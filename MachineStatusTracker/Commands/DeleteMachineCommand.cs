using MachineStatusTracker.Models;
using MachineStatusTracker.Stores;
using MachineStatusTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.Commands
{
    public class DeleteMachineCommand : AsyncCommandBase
    { 

        private MachineStatusViewModel _machineStatusViewModel;
        private MachineStore _machineStore;


        public DeleteMachineCommand(MachineStatusViewModel machineStatusViewModel, MachineStore machineStore)
        {
            _machineStatusViewModel = machineStatusViewModel;
            _machineStore = machineStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            Machine machine = _machineStatusViewModel.Machine;
            try
            {
                await _machineStore.Delete(machine.Id);
            }
            catch (Exception)
            {

                throw;
            }
            
                      
        }
       
    }
}
