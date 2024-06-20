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
    public class EditMachineCommand : AsyncCommandBase
    {
        private readonly EditMachineViewModel _editMachineViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly MachineStore _machineStore;

        public EditMachineCommand(EditMachineViewModel editMachineViewModel, ModalNavigationStore modalNavigationStore, MachineStore machineStore)
        {
            _editMachineViewModel = editMachineViewModel;
            _modalNavigationStore = modalNavigationStore;
            _machineStore = machineStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            var formViewModel = _editMachineViewModel.MachineDetailsFormViewModel;
            Machine machine = new Machine(
                _editMachineViewModel.MachineId,
                formViewModel.MachineName,
                formViewModel.MachineDescription,
                new Status(formViewModel.MachineStatus.Id, formViewModel.MachineStatus.Name));
            formViewModel.ErrorMessage = null;  
            try
            {
                await _machineStore.Update(machine);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Failed to update machine, please contact support";
            }
            
        }
    }
}
