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
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get; }
     

        public EditMachineViewModel(Machine machine, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand = new AddMachineCommand(modalNavigationStore);
            ICommand cancelCommand = new CLoseModelCommand(modalNavigationStore);

            MachineDetailsFormViewModel = new MachineDetailsFormViewModel(submitCommand, cancelCommand)
            {
                MachineName = machine.Name,
                MachineDescription = machine.Description,
                MachineStatus = new MachineStatus(machine.Status.Name, machine.Status.Id)
            };
        }
    }
}
