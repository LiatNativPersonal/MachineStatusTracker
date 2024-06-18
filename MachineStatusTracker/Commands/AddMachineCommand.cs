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
    public class AddMachineCommand : AsyncCommandBase
    {
        private readonly AddMachineViewModel _machineViewModel;
        private readonly MachineStore _machineStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddMachineCommand(AddMachineViewModel machineViewModel, MachineStore machineStore, ModalNavigationStore modalNavigationStore)
        {
            _machineViewModel = machineViewModel;
            _machineStore = machineStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var formViewModel = _machineViewModel.MachineDetailsFormViewModel;
            Machine machine = new Machine(Guid.NewGuid(), formViewModel.MachineName,
                formViewModel.MachineDescription,
                new Status(formViewModel.MachineStatus.Id, formViewModel.MachineStatus.Name));
            try
            {
                await _machineStore.Add(machine);
                _modalNavigationStore.Close();
            }
            catch (Exception )
            {
            }
            
        }
    }
}
