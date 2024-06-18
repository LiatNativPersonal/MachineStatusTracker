using MachineStatusTracker.Commands;
using MachineStatusTracker.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class AddMachineViewModel:ViewModelBase
    {
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get;  }

        public AddMachineViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CLoseModelCommand(modalNavigationStore);
            ICommand submitCommand = new AddMachineCommand(modalNavigationStore);
            MachineDetailsFormViewModel = new MachineDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
