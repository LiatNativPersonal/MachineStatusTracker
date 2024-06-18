using MachineStatusTracker.Stores;
using MachineStatusTracker.ViewModels;
using MachineStatusTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.Commands
{
    public class OpenAddMachineStatusCommand : CommandBase
    {
        private readonly MachineStore _machineStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddMachineStatusCommand(MachineStore machineStore, ModalNavigationStore modalNavigationStore)
        {
            _machineStore = machineStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddMachineViewModel addMachineViewModel = new AddMachineViewModel(_machineStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addMachineViewModel;
        }
    }
}
