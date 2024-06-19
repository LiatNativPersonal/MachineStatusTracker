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

        public ICommand LoadMachinesCommand { get; }
        public MachineStautsContainerViewModel(MachineStore machineStore, ModalNavigationStore modalNavigationStore)
        {
            _machineStore = machineStore;
            _modalNavigationStore = modalNavigationStore;
            _machineStatusViewModels = new ObservableCollection<MachineStatusViewModel>();
            
            LoadMachinesCommand = new LoadMachinesCommand(machineStore);

            _machineStore.MachinesLoaded += MachineStore_MachineLoaded;
            _machineStore.MachineAdded += MachineStore_MachineAdded;
            _machineStore.MachineUpdated += MachineStore_MachineUpdated;

           
            
        }

        private void MachineStore_MachineLoaded()
        {
            _machineStatusViewModels.Clear();
            foreach (Machine machine in _machineStore.Machines)
            {
                AddMachine(machine);
            }

        }

        public static MachineStautsContainerViewModel LoadViewModel (MachineStore machineStore, 
            ModalNavigationStore modalNavigationStore)
        {
            MachineStautsContainerViewModel viewModel = 
                new MachineStautsContainerViewModel (machineStore, modalNavigationStore);
            viewModel.LoadMachinesCommand.Execute(null);
            return viewModel;

        }
        protected override void Dispose() 
        {
            _machineStore.MachineAdded -= MachineStore_MachineAdded;
            _machineStore.MachineUpdated -= MachineStore_MachineUpdated;
            base.Dispose();
        }


        private void MachineStore_MachineAdded(Machine machine)
        {
            AddMachine(machine);
        }

        private void MachineStore_MachineUpdated(Machine machine)
        {
            var machineViewModel = _machineStatusViewModels.FirstOrDefault(y => y.Machine.Id == machine.Id);
            if (machineViewModel != null)
            {
                machineViewModel.Update(machine);
            }

            
        }
        private void AddMachine(Machine machine)
        {
            
            _machineStatusViewModels.Add(new MachineStatusViewModel(machine, _modalNavigationStore, _machineStore));
        }

        
    }
}
