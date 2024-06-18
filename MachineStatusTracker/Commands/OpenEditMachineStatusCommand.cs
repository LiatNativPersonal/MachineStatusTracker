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
    public class OpenEditMachineStatusCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private MachineStatusViewModel _machineStatusViewModel;
        private MachineStore _machineStore;

        public OpenEditMachineStatusCommand(MachineStatusViewModel machineStatusViewModel, ModalNavigationStore modalNavigationStore, MachineStore machineStore)
        {
            _machineStatusViewModel = machineStatusViewModel;
            _modalNavigationStore = modalNavigationStore;
            _machineStore = machineStore;
        }

        public override void Execute(object? parameter)
        {
            Machine machine = _machineStatusViewModel.Machine;
            EditMachineViewModel editMachineViewModel = new EditMachineViewModel(machine, _modalNavigationStore, _machineStore);
            _modalNavigationStore.CurrentViewModel = editMachineViewModel;
        }
    }
}
