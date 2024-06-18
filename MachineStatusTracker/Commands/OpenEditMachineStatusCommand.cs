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
        private readonly Machine _machine;

        public OpenEditMachineStatusCommand(ModalNavigationStore modalNavigationStore, Machine machine)
        {
            _modalNavigationStore = modalNavigationStore;
            _machine = machine;
        }

        public override void Execute(object? parameter)
        {
            EditMachineViewModel editMachineViewModel = new EditMachineViewModel(_machine, _modalNavigationStore );
            _modalNavigationStore.CurrentViewModel = editMachineViewModel;
        }
    }
}
