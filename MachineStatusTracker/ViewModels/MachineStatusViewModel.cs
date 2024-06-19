using MachineStatusTracker.Commands;
using MachineStatusTracker.Models;
using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineStatusViewModel : ViewModelBase
    {
        private ModalNavigationStore _modalNavigationStore;
        private MachineStore _machineStore;

        public string MachineName => Machine.Name;

        public string MachineDescription => Machine.Description;

        public Status MachineStatus => Machine.Status;
        public Machine Machine { get; private set; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
      

        public MachineStatusViewModel(Machine machine, ModalNavigationStore modalNavigationStore, MachineStore machineStore)
        {
            Machine = machine;
            _modalNavigationStore = modalNavigationStore;
            _machineStore = machineStore;

            EditCommand = new OpenEditMachineStatusCommand(this, modalNavigationStore, machineStore);
            DeleteCommand = new DeleteMachineCommand(this, machineStore);
        }

        public void Update(Machine machine)
        {
            Machine = machine;
            OnPropertyChanged(nameof(MachineName));
            OnPropertyChanged(nameof(MachineStatus));
            OnPropertyChanged(nameof(MachineDescription));
        }
    }

    public class MachineStatus
    {
        public Guid StatusId { get; set; }
        public string StatusName { get; set; }
        public MachineStatus(string Name, Guid machineID)
        {
            StatusName = Name;
            StatusId = machineID;
            
        }

        public override string ToString()
        {
            return StatusName;
        }
    }
        


}
