using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineStatusTracker.ViewModels
{
    public class EditMachineViewModel:ViewModelBase
    {
        public MachineDetailsFormViewModel MachineDetailsFormViewModel { get; }

        public EditMachineViewModel()
        {
            MachineDetailsFormViewModel = new MachineDetailsFormViewModel();
        }
    }
}
