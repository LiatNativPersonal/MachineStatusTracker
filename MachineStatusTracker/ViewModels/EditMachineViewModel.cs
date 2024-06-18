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
    public class EditMachineViewModel:ViewModelBase
    {
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get; }
     

        public EditMachineViewModel(ModalNavigationStore modalNavigationStore)
        {
            ICommand cancelCommand = new CLoseModelCommand(modalNavigationStore);
            MachineDetailsFormViewModel = new MachineDetailsFormViewModel(null, cancelCommand);
        }
    }
}
