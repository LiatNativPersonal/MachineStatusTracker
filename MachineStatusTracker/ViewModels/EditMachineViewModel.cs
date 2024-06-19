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
    public class EditMachineViewModel:ViewModelBase
    {

        public Guid MachineId { get; }
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get; }
     

        public EditMachineViewModel(Machine machine, ModalNavigationStore modalNavigationStore, MachineStore machineStore)
        {
            MachineId = machine.Id;
            
            ICommand submitCommand = new EditMachineCommand(this, modalNavigationStore, machineStore);
            ICommand cancelCommand = new CLoseModelCommand(modalNavigationStore);

            MachineDetailsFormViewModel = new MachineDetailsFormViewModel(submitCommand, cancelCommand, machineStore)
            {
                MachineName = machine.Name,
                MachineDescription = machine.Description,
                MachineStatus = new Status(machine.Status.Id, machine.Status.Name)
            };
        }
    }
}
