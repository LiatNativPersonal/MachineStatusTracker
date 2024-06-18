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
        private readonly MachineStore _machineStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ObservableCollection<MachineStatusViewModel> _machineStatusViewModels;
        public IEnumerable<MachineStatusViewModel> MachineStatusViewModels => _machineStatusViewModels;

        public MachineStautsContainerViewModel(MachineStore machineStore, ModalNavigationStore modalNavigationStore)
        {
            _machineStore = machineStore;
            _modalNavigationStore = modalNavigationStore;
            _machineStatusViewModels = new ObservableCollection<MachineStatusViewModel>();

            _machineStore.MachineAdded += MachineStore_MachineAdded;

            AddMachine(new Machine("Machine1", "bla lba", new Status("Idle")));
            AddMachine(new Machine("Machine2", "some info", new Status("Offline")));
            AddMachine(new Machine("Machine3", "bla lba", new Status("Online")));
            
        }
        protected override void Dispose() 
        {
            _machineStore.MachineAdded -= MachineStore_MachineAdded;
            base.Dispose();
        }


        private void MachineStore_MachineAdded(Machine machine)
        {
            AddMachine(machine);
        }
        private void AddMachine(Machine machine)
        {
            ICommand editCommand = new OpenEditMachineStatusCommand(_modalNavigationStore, machine);
            _machineStatusViewModels.Add(new MachineStatusViewModel(machine, editCommand));
        }
    }
}
