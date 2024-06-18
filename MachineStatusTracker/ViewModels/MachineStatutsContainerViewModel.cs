using MachineStatusTracker.Commands;
using MachineStatusTracker.Models;
using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStautsContainerViewModel:ViewModelBase
    {
        private readonly ObservableCollection<MachineStatusViewModel> _machineStatusViewModels;
        public IEnumerable<MachineStatusViewModel> MachineStatusViewModels => _machineStatusViewModels;

        public MachineStautsContainerViewModel(ModalNavigationStore modalNavigationStore)
        {
            _machineStatusViewModels = new ObservableCollection<MachineStatusViewModel>();
            AddMachine(new Machine("Machine1", "bla lba", new Status("Idle")), modalNavigationStore);
            AddMachine(new Machine("Machine2", "some info", new Status("Offline")), modalNavigationStore);
            AddMachine(new Machine("Machine3", "bla lba", new Status("Online")), modalNavigationStore);
            
        }


        private void AddMachine(Machine machine, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditMachineStatusCommand(modalNavigationStore, machine);
            _machineStatusViewModels.Add(new MachineStatusViewModel(machine, editCommand));
        }
    }
}
