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

        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddMachineStatusCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object? parameter)
        {
            AddMachineViewModel addMachineViewModel = new AddMachineViewModel();
            _modalNavigationStore.CurrentViewModel = addMachineViewModel;
        }
    }
}
